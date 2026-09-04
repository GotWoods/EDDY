using Eddy.Core.Validation;
using Xunit;

namespace Eddy.Tests.Validation;

public class ErrorSeverityTests
{
    [Fact]
    public void Error_DefaultsToErrorSeverity()
    {
        var error = new Error(ErrorCodes.Required, "X");
        Assert.Equal(ErrorSeverity.Error, error.Severity);
    }

    [Fact]
    public void IsValid_IsTrueWhenOnlyWarningsArePresent()
    {
        var result = new ValidationResult();
        result.Add(new Error(ErrorCodes.UnknownCodeValue, "X", "Y", "Z") { Severity = ErrorSeverity.Warning });

        Assert.True(result.IsValid);
        Assert.True(result.HasWarnings);
    }

    [Fact]
    public void IsValid_IsFalseWhenAnErrorSeverityEntryIsPresent()
    {
        var result = new ValidationResult();
        result.Add(new Error(ErrorCodes.UnknownCodeValue, "X", "Y", "Z") { Severity = ErrorSeverity.Warning });
        result.Add(new Error(ErrorCodes.Required, "X"));

        Assert.False(result.IsValid);
        Assert.True(result.HasWarnings);
    }

    [Fact]
    public void HasWarnings_IsFalseWithNoWarningEntries()
    {
        var result = new ValidationResult();
        result.Add(new Error(ErrorCodes.Required, "X"));

        Assert.False(result.HasWarnings);
        Assert.False(result.IsValid);
    }

    [Fact]
    public void HasWarnings_IsFalseWhenEmpty()
    {
        var result = new ValidationResult();

        Assert.False(result.HasWarnings);
        Assert.True(result.IsValid);
    }

    [Fact]
    public void ToString_PrefixesWarningEntriesButNotErrorEntries()
    {
        var result = new ValidationResult();
        result.Add(new Error(ErrorCodes.Required, "Plain"));
        result.Add(new Error(ErrorCodes.UnknownCodeValue, "Foo", "ZZ", "98") { Severity = ErrorSeverity.Warning });

        var lines = result.ToString().TrimEnd('\r', '\n').Split('\n');
        Assert.Equal(2, lines.Length);
        Assert.DoesNotContain("warning: ", lines[0]);
        Assert.StartsWith("warning: ", lines[1].TrimEnd('\r'));
    }
}
