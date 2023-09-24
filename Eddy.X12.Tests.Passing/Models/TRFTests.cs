using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models;

public class TRFTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "TRF*o6**5**2";

        var expected = new TRF_RatingFactors
        {
            QuantityQualifier = "o6",
            CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure(),
            Quantity = 5,
            CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure(),
            Quantity2 = 2
        };

        var actual = Map.MapObject<TRF_RatingFactors>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("o6", true)]
    public void Validation_RequiredQuantityQualifier(string quantityQualifier, bool isValidExpected)
    {
        var subject = new TRF_RatingFactors();
        subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
        subject.Quantity = 5;
        subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
        subject.Quantity2 = 2;
        subject.QuantityQualifier = quantityQualifier;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("AA", true)]
    public void Validation_RequiredCompositeUnitOfMeasure(string compositeUnitOfMeasure, bool isValidExpected)
    {
        var subject = new TRF_RatingFactors();
        subject.QuantityQualifier = "o6";
        subject.Quantity = 5;
        subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
        subject.Quantity2 = 2;

        if (compositeUnitOfMeasure != "")
            subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure { UnitOrBasisForMeasurementCode = compositeUnitOfMeasure };

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData(0, false)]
    [InlineData(5, true)]
    public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
    {
        var subject = new TRF_RatingFactors();
        subject.QuantityQualifier = "o6";
        subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
        subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
        subject.Quantity2 = 2;
        if (quantity > 0)
            subject.Quantity = quantity;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("AA", true)]
    public void Validation_RequiredCompositeUnitOfMeasure2(string compositeUnitOfMeasure2, bool isValidExpected)
    {
        var subject = new TRF_RatingFactors();
        subject.QuantityQualifier = "o6";
        subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
        subject.Quantity = 5;
        subject.Quantity2 = 2;
        if (compositeUnitOfMeasure2 != "")
            subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure { UnitOrBasisForMeasurementCode = compositeUnitOfMeasure2 };
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData(0, false)]
    [InlineData(2, true)]
    public void Validation_RequiredQuantity2(decimal quantity2, bool isValidExpected)
    {
        var subject = new TRF_RatingFactors();
        subject.QuantityQualifier = "o6";
        subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
        subject.Quantity = 5;
        subject.CompositeUnitOfMeasure2 = new C001_CompositeUnitOfMeasure();
        if (quantity2 > 0)
            subject.Quantity2 = quantity2;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}