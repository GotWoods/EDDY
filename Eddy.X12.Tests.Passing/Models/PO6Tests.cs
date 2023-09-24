using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PO6Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "PO6**5*Ck*9*Va*5*OR*9*go";

        var expected = new PO6_NonPackagedItemPhyscialDetails
        {
            CompositeProductWeightBasis = null,
            Length = 5,
            UnitOrBasisForMeasurementCode = "Ck",
            Width = 9,
            UnitOrBasisForMeasurementCode2 = "Va",
            Height = 5,
            UnitOrBasisForMeasurementCode3 = "OR",
            ItemDepth = 9,
            UnitOrBasisForMeasurementCode4 = "go"
        };

        var actual = Map.MapObject<PO6_NonPackagedItemPhyscialDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(5, "Ck", true)]
    [InlineData(0, "Ck", false)]
    [InlineData(5, "", false)]
    public void Validation_AllAreRequiredLength(decimal length, string unitOrBasisForMeasurementCode, bool isValidExpected)
    {
        var subject = new PO6_NonPackagedItemPhyscialDetails();
        if (length > 0)
            subject.Length = length;
        subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData(0, 0, true)]
    [InlineData(5, 9, false)]
    [InlineData(0, 9, true)]
    [InlineData(5, 0, true)]
    public void Validation_OnlyOneOfLength(decimal length, decimal itemDepth, bool isValidExpected)
    {
        var subject = new PO6_NonPackagedItemPhyscialDetails();
        if (length > 0)
            subject.Length = length;
        if (itemDepth > 0)
            subject.ItemDepth = itemDepth;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(9, "Va", true)]
    [InlineData(0, "Va", false)]
    [InlineData(9, "", false)]
    public void Validation_AllAreRequiredWidth(decimal width, string unitOrBasisForMeasurementCode2, bool isValidExpected)
    {
        var subject = new PO6_NonPackagedItemPhyscialDetails();
        if (width > 0)
            subject.Width = width;
        subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(5, "OR", true)]
    [InlineData(0, "OR", false)]
    [InlineData(5, "", false)]
    public void Validation_AllAreRequiredHeight(decimal height, string unitOrBasisForMeasurementCode3, bool isValidExpected)
    {
        var subject = new PO6_NonPackagedItemPhyscialDetails();
        if (height > 0)
            subject.Height = height;
        subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(9, "go", true)]
    [InlineData(0, "go", false)]
    [InlineData(9, "", false)]
    public void Validation_AllAreRequiredItemDepth(decimal itemDepth, string unitOrBasisForMeasurementCode4, bool isValidExpected)
    {
        var subject = new PO6_NonPackagedItemPhyscialDetails();
        if (itemDepth > 0)
            subject.ItemDepth = itemDepth;
        subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}