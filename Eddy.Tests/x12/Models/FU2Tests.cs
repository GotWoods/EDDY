using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class FU2Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "FU2*XG*5*5*5*f*t*ZdY*A*U*5z*e";

        var expected = new FU2_DealValue
        {
            UnitOrBasisForMeasurementCode = "XG",
            Quantity = 5,
            MonetaryAmount = 5,
            Description = "5",
            YesNoConditionOrResponseCode = "f",
            YesNoConditionOrResponseCode2 = "t",
            TransportationTermsCode = "ZdY",
            LocationQualifier = "A",
            IdentificationCodeQualifier = "U",
            IdentificationCode = "5z",
            Description2 = "e"
        };

        var actual = Map.MapObject<FU2_DealValue>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("XG", true)]
    public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
    {
        var subject = new FU2_DealValue();
        subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
        subject.MonetaryAmount = 1;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData(0, 0, false)]
    [InlineData(0, 5, true)]
    [InlineData(5, 0, true)]
    public void Validation_AtLeastOneQuantity(decimal quantity, decimal monetaryAmount, bool isValidExpected)
    {
        var subject = new FU2_DealValue();
        subject.UnitOrBasisForMeasurementCode = "XG";
        if (quantity > 0)
            subject.Quantity = quantity;
        if (monetaryAmount > 0)
            subject.MonetaryAmount = monetaryAmount;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
    }

    [Theory]
    [InlineData(5, 5, false)]
    [InlineData(0, 5, true)]
    [InlineData(5, 0, true)]
    public void Validation_OnlyOneOfQuantity(decimal quantity, decimal monetaryAmount, bool isValidExpected)
    {
        var subject = new FU2_DealValue();
        subject.UnitOrBasisForMeasurementCode = "XG";
        if (quantity > 0)
            subject.Quantity = quantity;
        if (monetaryAmount > 0)
            subject.MonetaryAmount = monetaryAmount;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("ZdY", "A", true)]
    [InlineData("", "A", false)]
    [InlineData("ZdY", "", false)]
    public void Validation_AllAreRequiredTransportationTermsCode(string transportationTermsCode, string locationQualifier, bool isValidExpected)
    {
        var subject = new FU2_DealValue();
        subject.UnitOrBasisForMeasurementCode = "XG";
        subject.TransportationTermsCode = transportationTermsCode;
        subject.LocationQualifier = locationQualifier;
        subject.MonetaryAmount = 1;

        if (transportationTermsCode != "")
        {
            subject.Description2 = "AB";
        }
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    // TODO: this test
    // [Theory]
    // [InlineData("","", true)]
    // [InlineData("ZdY", "U", false)]
    // [InlineData("","U", true)]
    // [InlineData("ZdY", "", true)]
    // public void Validation_IfOneSpecifiedThenOneMoreRequired_TransportationTermsCode(string transportationTermsCode, string identificationCodeQualifier, string description2, bool isValidExpected)
    // {
    // 	var subject = new FU2_DealValue();
    // 	subject.UnitOrBasisForMeasurementCode = "XG";
    // 	subject.TransportationTermsCode = transportationTermsCode;
    // 	subject.IdentificationCodeQualifier = identificationCodeQualifier;
    // 	subject.Description2 = description2;
    //
    // 	TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
    // }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("U", "5z", true)]
    [InlineData("", "5z", false)]
    [InlineData("U", "", false)]
    public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
    {
        var subject = new FU2_DealValue();
        subject.UnitOrBasisForMeasurementCode = "XG";
        subject.IdentificationCodeQualifier = identificationCodeQualifier;
        subject.IdentificationCode = identificationCode;
        subject.MonetaryAmount = 1;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}