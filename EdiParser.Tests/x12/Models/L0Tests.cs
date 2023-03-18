using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class L0Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "L0*S*1*5f*2*F*3*a*4*Er7*V0*r*H4*5*pQ1*M";

        var expected = new L0_LineItemQuantityAndWeight()
        {
            LadingLineItemNumber = "S",
            BilledOrRatedAsQuantity = 1,
            BilledOrRatedAsQualifier = "5f",
            Weight = 2,
            WeightQualifier = "F",
            Volume = 3,
            VolumeUnitQualifier = "a",
            LadingQuantity = 4,
            PackagingFormCode = "Er7",
            DunnageDescription = "V0",
            WeightUnitCode = "r",
            TypeOfServiceCode = "H4",
            Quantity = 5,
            PackagingFormCode2 = "pQ1",
            YesNoConditionorResponseCode = "M",
        };

        var actual = Map.MapObject<L0_LineItemQuantityAndWeight>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData(1.0, "AB", true)]
    [InlineData(0, null, true)]
    [InlineData(0, "AB", false)]
    [InlineData(1.0, null, false)]
    public void Validate_BilledRated(decimal quantity, string qualifier, bool isValidExpected)
    {
        var subject = new L0_LineItemQuantityAndWeight();
        subject.BilledOrRatedAsQualifier = qualifier;
        if (quantity != 0) //cant pass in a decimal? using [InlineData] so we use 0 to symbolize null
            subject.BilledOrRatedAsQuantity = quantity;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData(1.0, "AB", true)]
    [InlineData(0, null, true)]
    [InlineData(0, "AB", false)]
    [InlineData(1.0, null, false)]
    public void Validate_Weight(decimal quantity, string qualifier, bool isValidExpected)
    {
        var subject = new L0_LineItemQuantityAndWeight();
        subject.WeightQualifier = qualifier;
        if (quantity != 0) //cant pass in a decimal? using [InlineData] so we use 0 to symbolize null
            subject.Weight = quantity;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData(1.0, "A", true)]
    [InlineData(0, null, true)]
    [InlineData(0, "A", false)]
    [InlineData(1.0, null, false)]
    public void Validate_Volume(decimal quantity, string qualifier, bool isValidExpected)
    {
        var subject = new L0_LineItemQuantityAndWeight();
        subject.VolumeUnitQualifier = qualifier;
        if (quantity != 0) //cant pass in a decimal? using [InlineData] so we use 0 to symbolize null
            subject.Volume = quantity;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData(1, "ABC", true)]
    [InlineData(0, null, true)]
    [InlineData(0, "ABC", false)]
    [InlineData(1, null, false)]
    public void Validate_LadingQuantity(int quantity, string qualifier, bool isValidExpected)
    {
        var subject = new L0_LineItemQuantityAndWeight();
        subject.PackagingFormCode = qualifier;
        if (quantity != 0) //cant pass in a decimal? using [InlineData] so we use 0 to symbolize null
            subject.LadingQuantity = quantity;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData(1.0, "Y", true)]
    [InlineData(0, null, true)]
    [InlineData(0, "Y", false)]
    [InlineData(1.0, null, false)]
    public void Validate_Quantity(decimal quantity, string yesno, bool isValidExpected)
    {
        var subject = new L0_LineItemQuantityAndWeight();
        subject.YesNoConditionorResponseCode = yesno;
        if (quantity != 0) //cant pass in a decimal? using [InlineData] so we use 0 to symbolize null
            subject.Quantity = quantity;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }


}