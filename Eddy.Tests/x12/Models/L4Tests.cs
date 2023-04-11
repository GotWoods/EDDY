using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class L4Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "L4*1*2*3*4*5*6";

        var expected = new L4_Measurement()
        {
            Length = 1,
            Width = 2,
            Height = 3,
            MeasurementUnitQualifier = "4",
            Quantity = 5,
            IndustryCode = "6",
        };

        var actual = Map.MapObject<L4_Measurement>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData(0, false)]
    [InlineData(1, true)]
    public void Validation_RequiredLength(decimal length, bool isValidExpected)
    {
        var subject = new L4_Measurement();
        subject.Width = 1;
        subject.Height = 1;
        subject.MeasurementUnitQualifier = "M";

        if (length > 0)
            subject.Length = length;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData(0, false)]
    [InlineData(1, true)]
    public void Validation_RequiredWidth(decimal width, bool isValidExpected)
    {
        var subject = new L4_Measurement();
        subject.Length = 1;
        subject.Height = 1;
        subject.MeasurementUnitQualifier = "M";

        if (width > 0)
            subject.Width = width;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData(0, false)]
    [InlineData(1, true)]
    public void Validation_RequiredHeight(decimal height, bool isValidExpected)
    {
        var subject = new L4_Measurement();
        subject.Length = 1;
        subject.Width = 1;
        subject.MeasurementUnitQualifier = "M";

        if (height > 0)
            subject.Height = height;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("1", true)]
    public void Validation_RequiredMeasurementUnitQualifier(string measurementUnitQualifier, bool isValidExpected)
    {
        var subject = new L4_Measurement();
        subject.Length = 1;
        subject.Width = 1;
        subject.Height = 1;

        subject.MeasurementUnitQualifier = measurementUnitQualifier;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}