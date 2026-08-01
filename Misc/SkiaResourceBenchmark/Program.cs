namespace SkiaResourceBenchmark;

using System;
using System.Collections.Generic;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

using SkiaSharp;

// MacStatDisplay creates every SKFont / SKPaint per draw call and disposes it again
// (DrawHelper.MakeFont / MakeFillPaint / MakeStrokePaint). The resource set is tiny and fixed:
// 9 font sizes x bold-or-not, and a fixed colour palette. This measures what caching would buy.
//
//   PerCall : the current shape - new SKFont / new SKPaint per call, disposed immediately
//   Cached  : fonts held in a lookup, one mutable SKPaint reused (SKPaint.Color is settable)
public static class Program
{
    public static void Main()
    {
        BenchmarkRunner.Run<Benchmark>();
    }
}

public class BenchmarkConfig : ManualConfig
{
    public BenchmarkConfig()
    {
        AddExporter(MarkdownExporter.GitHub);
        AddColumn(
            StatisticColumn.Mean,
            StatisticColumn.Min,
            StatisticColumn.Max,
            StatisticColumn.P90,
            StatisticColumn.Error,
            StatisticColumn.StdDev);
        AddDiagnoser(MemoryDiagnoser.Default);
    }
}

#pragma warning disable CA1822
[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class Benchmark : IDisposable
{
    private const float SubLabel = 14f;
    private const float SubValue = 16f;
    private const float WidgetTitle = 20f;

    private static readonly SKColor TextPrimary = new(0xFF, 0xFF, 0xFF);
    private static readonly SKColor TextSecondary = new(0x9A, 0xA0, 0xA6);
    private static readonly SKColor PanelBackground = new(0x1E, 0x1E, 0x1E);
    private static readonly SKColor PanelBorder = new(0x2C, 0x2C, 0x2C);
    private static readonly SKColor ReadAccent = new(0x4F, 0xC3, 0xF7);
    private static readonly SKColor WriteAccent = new(0xFF, 0xB7, 0x4D);

    private SKSurface surface = default!;

    private SKTypeface typeface = default!;
    private SKTypeface typefaceBold = default!;

    // Cached form
    private Dictionary<(float Size, bool Bold), SKFont> fontCache = default!;
    private SKFont cachedTitleFont = default!;
    private SKPaint cachedFill = default!;
    private SKPaint cachedStroke = default!;

    private bool disposed;

    [GlobalSetup]
    public void Setup()
    {
        surface = SKSurface.Create(new SKImageInfo(480, 320));

        typeface = SKTypeface.Default;
        typefaceBold = SKTypeface.FromFamilyName(SKTypeface.Default.FamilyName, SKFontStyle.Bold) ?? SKTypeface.Default;

        fontCache = [];
        foreach (var size in new[] { SubLabel, SubValue, WidgetTitle })
        {
            foreach (var bold in new[] { false, true })
            {
                fontCache[(size, bold)] = MakeFont(size, bold);
            }
        }

        // Separate instance so the dictionary entry is not disposed twice
        cachedTitleFont = MakeFont(WidgetTitle, true);
        cachedFill = new SKPaint { IsAntialias = true };
        cachedStroke = new SKPaint { IsAntialias = true, Style = SKPaintStyle.Stroke };
    }

    [GlobalCleanup]
    public void Cleanup()
    {
        Dispose();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposed || !disposing)
        {
            return;
        }

        disposed = true;

        if (fontCache is not null)
        {
            foreach (var font in fontCache.Values)
            {
                font.Dispose();
            }
        }

        cachedTitleFont?.Dispose();
        cachedFill?.Dispose();
        cachedStroke?.Dispose();
        typeface?.Dispose();
        typefaceBold?.Dispose();
        surface?.Dispose();
    }

    //--------------------------------------------------------------------------------
    // Current shape (copied from MacStatDisplay DrawHelper)
    //--------------------------------------------------------------------------------

    private SKFont MakeFont(float size, bool bold = false) =>
        new(bold ? typefaceBold : typeface, size)
        {
            Edging = SKFontEdging.SubpixelAntialias
        };

    private static SKPaint MakeFillPaint(SKColor color) =>
        new()
        {
            Color = color, IsAntialias = true
        };

    private static SKPaint MakeStrokePaint(SKColor color, float width) =>
        new()
        {
            Color = color,
            IsAntialias = true,
            Style = SKPaintStyle.Stroke,
            StrokeWidth = width
        };

    //--------------------------------------------------------------------------------
    // Primitives: how expensive is one resource?
    //--------------------------------------------------------------------------------

    [Benchmark(Baseline = true)]
    public float Font_PerCall()
    {
        using var font = MakeFont(SubValue, true);
        return font.Size;
    }

    [Benchmark]
    public float Font_CachedLookup()
    {
        var font = fontCache[(SubValue, true)];
        return font.Size;
    }

    [Benchmark]
    public float Font_CachedField()
    {
        return cachedTitleFont.Size;
    }

    [Benchmark]
    public SKColor Paint_PerCall()
    {
        using var paint = MakeFillPaint(TextSecondary);
        return paint.Color;
    }

    [Benchmark]
    public SKColor Paint_CachedMutate()
    {
        cachedFill.Color = TextSecondary;
        return cachedFill.Color;
    }

    //--------------------------------------------------------------------------------
    // Realistic frame: one DiskIoWidget draw with 2 entries.
    // PerCall allocates 7 SKFont + 11 SKPaint; Cached allocates none.
    //--------------------------------------------------------------------------------

    [Benchmark]
    public void Widget_PerCall()
    {
        var canvas = surface.Canvas;
        var rect = new SKRect(8, 8, 472, 312);

        // DrawPanel
        using (var bg = MakeFillPaint(PanelBackground))
        {
            canvas.DrawRoundRect(rect, 8, 8, bg);
        }

        using (var border = MakeStrokePaint(PanelBorder, 1))
        {
            canvas.DrawRoundRect(rect, 8, 8, border);
        }

        // DrawTitle
        using (var font = MakeFont(WidgetTitle, true))
        using (var paint = MakeFillPaint(TextPrimary))
        {
            canvas.DrawText("Disk I/O", rect.Left + 12, rect.Top + 28, font, paint);
        }

        for (var i = 0; i < 2; i++)
        {
            var y = rect.Top + 60 + (i * 120);

            // Entry name
            using (var nameFont = MakeFont(SubLabel))
            using (var namePaint = MakeFillPaint(TextSecondary))
            {
                canvas.DrawText("nvme0n1", rect.Left + 12, y, nameFont, namePaint);
            }

            // DrawSparklineValues
            using (var valFont = MakeFont(SubValue, true))
            using (var labelFont = MakeFont(SubLabel))
            using (var labelPaint = MakeFillPaint(TextSecondary))
            using (var upperPaint = MakeFillPaint(WriteAccent))
            using (var lowerPaint = MakeFillPaint(ReadAccent))
            {
                canvas.DrawText("Write", rect.Right - 60 - labelFont.MeasureText("Write"), y + 20, labelFont, labelPaint);
                canvas.DrawText("1.2 MB/s", rect.Right - 60 - valFont.MeasureText("1.2 MB/s"), y + 38, valFont, upperPaint);
                canvas.DrawText("Read", rect.Right - 60 - labelFont.MeasureText("Read"), y + 62, labelFont, labelPaint);
                canvas.DrawText("845 KB/s", rect.Right - 60 - valFont.MeasureText("845 KB/s"), y + 80, valFont, lowerPaint);
            }
        }
    }

    [Benchmark]
    public void Widget_Cached()
    {
        var canvas = surface.Canvas;
        var rect = new SKRect(8, 8, 472, 312);

        // DrawPanel
        cachedFill.Color = PanelBackground;
        canvas.DrawRoundRect(rect, 8, 8, cachedFill);

        cachedStroke.Color = PanelBorder;
        cachedStroke.StrokeWidth = 1;
        canvas.DrawRoundRect(rect, 8, 8, cachedStroke);

        // DrawTitle
        var titleFont = fontCache[(WidgetTitle, true)];
        cachedFill.Color = TextPrimary;
        canvas.DrawText("Disk I/O", rect.Left + 12, rect.Top + 28, titleFont, cachedFill);

        var valFont = fontCache[(SubValue, true)];
        var labelFont = fontCache[(SubLabel, false)];

        for (var i = 0; i < 2; i++)
        {
            var y = rect.Top + 60 + (i * 120);

            // Entry name
            cachedFill.Color = TextSecondary;
            canvas.DrawText("nvme0n1", rect.Left + 12, y, labelFont, cachedFill);

            // DrawSparklineValues
            canvas.DrawText("Write", rect.Right - 60 - labelFont.MeasureText("Write"), y + 20, labelFont, cachedFill);
            cachedFill.Color = WriteAccent;
            canvas.DrawText("1.2 MB/s", rect.Right - 60 - valFont.MeasureText("1.2 MB/s"), y + 38, valFont, cachedFill);
            cachedFill.Color = TextSecondary;
            canvas.DrawText("Read", rect.Right - 60 - labelFont.MeasureText("Read"), y + 62, labelFont, cachedFill);
            cachedFill.Color = ReadAccent;
            canvas.DrawText("845 KB/s", rect.Right - 60 - valFont.MeasureText("845 KB/s"), y + 80, valFont, cachedFill);
        }
    }
}
#pragma warning restore CA1822
