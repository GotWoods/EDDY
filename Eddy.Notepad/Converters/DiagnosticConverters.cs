using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;
using Eddy.Notepad.ViewModels;

namespace Eddy.Notepad.Converters;

/// <summary>Maps a <see cref="DiagnosticSeverity"/> to the glyph shown in the diagnostics list.</summary>
public sealed class SeverityToGlyphConverter : IValueConverter
{
    public static readonly SeverityToGlyphConverter Instance = new();

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture) => value switch
    {
        DiagnosticSeverity.Error => "✖",
        DiagnosticSeverity.Warning => "⚠",
        DiagnosticSeverity.Info => "ℹ",
        _ => "",
    };

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) =>
        throw new NotSupportedException();
}

/// <summary>Maps a <see cref="DiagnosticSeverity"/> to the brush used for its glyph and location text.</summary>
public sealed class SeverityToBrushConverter : IValueConverter
{
    public static readonly SeverityToBrushConverter Instance = new();

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture) => value switch
    {
        DiagnosticSeverity.Error => Brushes.IndianRed,
        DiagnosticSeverity.Warning => Brushes.Goldenrod,
        DiagnosticSeverity.Info => Brushes.SteelBlue,
        _ => Brushes.Gray,
    };

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) =>
        throw new NotSupportedException();
}
