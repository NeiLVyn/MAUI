using NeilvynApp.Core.Helpers;
using NeilvynApp.Enums;
using SkiaSharp;
using SkiaSharp.Views.Maui;

namespace NeilvynApp.Views.Custom.ArcView;

public partial class ArcContentView : ContentView
{
    #region bindables
    // BindableProperty for StartLabel
    public static readonly BindableProperty RiseTimeProperty =
        BindableProperty.Create(nameof(RiseTime), typeof(string), typeof(ArcContentView), string.Empty, propertyChanged: OnRiseTimeChanged);

    public string RiseTime
    {
        get => (string)GetValue(RiseTimeProperty);
        set => SetValue(RiseTimeProperty, value);
    }

    // BindableProperty for EndLabel
    public static readonly BindableProperty SetTimeProperty =
        BindableProperty.Create(nameof(SetTime), typeof(string), typeof(ArcContentView), string.Empty, propertyChanged: OnSetTimeChanged);

    public string SetTime
    {
        get => (string)GetValue(SetTimeProperty);
        set => SetValue(SetTimeProperty, value);
    }

    // BindableProperty for ArcIconType
    public static readonly BindableProperty ArcIconProperty = BindableProperty.Create(
        nameof(ArcIcon),
        typeof(ArcIcon),
        typeof(ArcContentView),
        ArcIcon.Sun,
        propertyChanged: OnArcIconChanged);

    public ArcIcon ArcIcon
    {
        get => (ArcIcon)GetValue(ArcIconProperty);
        set => SetValue(ArcIconProperty, value);
    }

    // BindableProperty for title text label
    public static readonly BindableProperty TitleLabelProperty = BindableProperty.Create(
        nameof(TitleLabel),
        typeof(string),
        typeof(ArcContentView),
        default(string),
        propertyChanged: OnTitleLabelChanged);

    public string TitleLabel
    {
        get => (string)GetValue(TitleLabelProperty);
        set => SetValue(TitleLabelProperty, value);
    }

    // BindableProperty for center image
    public static readonly BindableProperty CenterImageProperty = BindableProperty.Create(
        nameof(CenterImage),
        typeof(ImageSource),
        typeof(ArcContentView),
        default(ImageSource),
        propertyChanged: OnCenterImageChanged);

    public ImageSource CenterImage
    {
        get => (ImageSource)GetValue(CenterImageProperty);
        set => SetValue(CenterImageProperty, value);
    }
    #endregion

    #region onchanged
    private static void OnRiseTimeChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is ArcContentView arcView && newValue is string newText)
        {
            arcView.lblStart.Text = newText.ToLocalDateTime().ToString("hh:mm tt");
            var control = (ArcContentView)bindable;
            control.ArcCanvasView.InvalidateSurface();
        }
    }

    private static void OnSetTimeChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is ArcContentView arcView && newValue is string newText)
        {
            arcView.lblEnd.Text = newText.ToLocalDateTime().ToString("hh:mm tt");
            var control = (ArcContentView)bindable;
            control.ArcCanvasView.InvalidateSurface();
        }
    }

    private static void OnArcIconChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (ArcContentView)bindable;
        control.ArcCanvasView.InvalidateSurface();
    }

    private static void OnCenterImageChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (ArcContentView)bindable;
        control.img.Source = (ImageSource)newValue;
    }

    private static void OnTitleLabelChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (ArcContentView)bindable;
        control.lblTitle.Text = (string)newValue;
    }
    #endregion

    readonly int SunMoonIconRadius = 20;

    public ArcContentView()
    {
        InitializeComponent();
        ArcCanvasView.InvalidateSurface();
    }

    private void OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
    {
        var canvas = e.Surface.Canvas;
        canvas.Clear();

        var paint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.Gray,
            StrokeWidth = 5
        };

        var rect = new SKRect(100, 100, e.Info.Width - 100, e.Info.Height - 100);
        var sweepAngle = 180;

        canvas.DrawArc(rect, 180, sweepAngle, false, paint);

        var progressPaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.Orange,
            StrokeWidth = 6
        };

        DateTime rise = RiseTime.ToLocalDateTime();
        DateTime set = SetTime.ToLocalDateTime();

        lblStart.Text = rise.ToString("hh:mm tt");
        lblEnd.Text = set.ToString("hh:mm tt");

        var totalDuration = set - rise;
        var descLabel = ArcIcon == ArcIcon.Sun ? "Daylight" : "Moonlight";
        lblDescription.Text = $"Total {descLabel}: {(int)totalDuration.TotalHours:D2} hours and {totalDuration.Minutes:D2} minutes";

        var elapsed = DateTime.Now - rise;
        var progress = elapsed.TotalMinutes / totalDuration.TotalMinutes;
        progress = progress < 0 ? 0 : progress;
        progress = progress > 1 ? 1 : progress;

        var progressSweepAngle = (float)(180 * progress);

        canvas.DrawArc(rect, 180, progressSweepAngle, false, progressPaint);

        var angle = progressSweepAngle;
        var radians = Math.PI * (angle - 180) / 180.0;
        var radius = rect.Width / 2;
        var centerX = rect.MidX;
        var iconX = centerX + radius * Math.Cos(radians);

        var iconY = SetIconY(progress);
        DrawIcon(canvas, (float)iconX, (float)iconY);
    }

    private float SetIconY(double progress)
    {
        int percentage = (int)Math.Round(progress * 100);
        
        if (percentage <= 5)
        {
            return 200;
        } else if (percentage <= 10)
        {
            return 180;
        }
        else if (percentage <= 15)
        {
            return 165;
        }
        else if (percentage <= 18)
        {
            return 158;
        }
        else if (percentage <= 20)
        {
            return 150;
        }
        else if (percentage <= 23)
        {
            return 140;
        }
        else if (percentage <= 25)
        {
            return 135;
        }
        else if (percentage <= 27)
        {
            return 130;
        }
        else if (percentage <= 30)
        {
            return 125;
        }
        else if (percentage <= 33)
        {
            return 115;
        }
        else if (percentage <= 35)
        {
            return 110;
        }
        else if (percentage <= 38)
        {
            return 105;
        }
        else if (percentage <= 40)
        {
            return 104;
        }
        else if (percentage <= 45)
        {
            return 102;
        }




        else if (percentage > 45 && percentage < 55)
        {
            return 100;
        }



        else if (percentage <= 57)
        {
            return 102;
        }
        else if (percentage <= 60)
        {
            return 104;
        }
        else if (percentage <= 63)
        {
            return 105;
        }
        else if (percentage <= 65)
        {
            return 110;
        }
        else if (percentage <= 68)
        {
            return 115;
        }
        else if (percentage <= 70)
        {
            return 125;
        }
        else if (percentage <= 72)
        {
            return 130;
        }
        else if (percentage <= 75)
        {
            return 135;
        }
        else if (percentage <= 78)
        {
            return 140;
        }
        else if (percentage <= 80)
        {
            return 150;
        }
        else if (percentage <= 83)
        {
            return 158;
        }
        else if (percentage <= 85)
        {
            return 165;
        }
        else if (percentage <= 90)
        {
            return 180;
        }
        else if (percentage >= 95)
        {
            return 200;
        }

        return 200;
    }

    private void DrawIcon(SKCanvas canvas, float centerX, float centerY)
    {
        switch (ArcIcon)
        {
            case ArcIcon.Sun:
                DrawSun(canvas, centerX, centerY);
                break;
            case ArcIcon.Moon:
                DrawMoon(canvas, centerX, centerY);
                break;
        }
    }

    private void DrawSun(SKCanvas canvas, float centerX, float centerY)
    {
        var sunPaint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.Yellow
        };

        canvas.DrawCircle(centerX, centerY, SunMoonIconRadius, sunPaint);

        var rayPaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.Yellow,
            StrokeWidth = 2
        };

        var rayLength = SunMoonIconRadius * 1.5f;
        for (int i = 0; i < 12; i++)
        {
            var angle = Math.PI * i / 6;
            var startX = centerX + SunMoonIconRadius * (float)Math.Cos(angle);
            var startY = centerY + SunMoonIconRadius * (float)Math.Sin(angle);
            var endX = centerX + rayLength * (float)Math.Cos(angle);
            var endY = centerY + rayLength * (float)Math.Sin(angle);

            canvas.DrawLine(startX, startY, endX, endY, rayPaint);
        }
    }

    private void DrawMoon(SKCanvas canvas, float centerX, float centerY)
    {
        var moonPaint = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.White
        };

        canvas.DrawCircle(centerX, centerY, SunMoonIconRadius, moonPaint);
    }
}