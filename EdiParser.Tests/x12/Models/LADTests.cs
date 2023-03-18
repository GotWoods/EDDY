using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class LADTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "LAD*Q5O*9*p*4*A*4*wo*wxWGpEsjyS94SJvAUdDCnBe54AhfdykcK1sdiBrPOlDdbTiOPEetjd0CSi0j5UEvMebJ9bMJG7yemeKO*my*BXMUWHh1qMt1CibeiYTHY9F9Ie38bVdUpTsnU0wsu6rfNRXWmEhvwx7CYgPqKLSNp9azkhY1Ba5IBk9s*eQ*neig6AaCt0vXVSoEEzAL7IV6R6lYsBskQpMwPV5AMPIslWN7ZXANF6eQx7kZFL4iPpxDAeh5qP1OrUoM*7ROLjsZk3bkIF38ajUwkVewydJUQu6H1EA0UEnWY6IeCEegF6q*11";

        var expected = new LAD_LadingDetail()
        {
            PackagingFormCode = "Q5O",
            LadingQuantity = 9,
            WeightUnitCode = "p",
            UnitWeight = 4,
            WeightUnitCode2 = "A",
            Weight = 4,
            ProductServiceIDQualifier = "wo",
            ProductServiceID = "wxWGpEsjyS94SJvAUdDCnBe54AhfdykcK1sdiBrPOlDdbTiOPEetjd0CSi0j5UEvMebJ9bMJG7yemeKO",
            ProductServiceIDQualifier2 = "my",
            ProductServiceID2 = "BXMUWHh1qMt1CibeiYTHY9F9Ie38bVdUpTsnU0wsu6rfNRXWmEhvwx7CYgPqKLSNp9azkhY1Ba5IBk9s",
            ProductServiceIDQualifier3 = "eQ",
            ProductServiceID3 = "neig6AaCt0vXVSoEEzAL7IV6R6lYsBskQpMwPV5AMPIslWN7ZXANF6eQx7kZFL4iPpxDAeh5qP1OrUoM",
            LadingDescription = "7ROLjsZk3bkIF38ajUwkVewydJUQu6H1EA0UEnWY6IeCEegF6q",
            LadingValue = 11,
        };

        var actual = Map.MapObject<LAD_LadingDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", 0, true)]
    [InlineData("123", 1, true)]
    [InlineData("", 1, false)]
    [InlineData("123", 0, false)]
    public void Validation_AllAreRequiredPackagingFormCode(string packagingFormCode, int ladingQuantity, bool isValidExpected)
    {
        var subject = new LAD_LadingDetail();
        subject.PackagingFormCode = packagingFormCode;
        if (ladingQuantity > 0)
            subject.LadingQuantity = ladingQuantity;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
    [Theory]
    [InlineData("", 0, true)]
    [InlineData("1", 1, true)]
    [InlineData("", 1, false)]
    [InlineData("1", 0, false)]
    public void Validation_AllAreRequiredWeightUnitCode(string weightUnitCode, decimal unitWeight, bool isValidExpected)
    {
        var subject = new LAD_LadingDetail();
        subject.WeightUnitCode = weightUnitCode;
        if (unitWeight > 0)
            subject.UnitWeight = unitWeight;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
    [Theory]
    [InlineData("", 0, true)]
    [InlineData("1", 1, true)]
    [InlineData("", 1, false)]
    [InlineData("1", 0, false)]
    public void Validation_AllAreRequiredWeightUnitCode2(string weightUnitCode2, decimal weight, bool isValidExpected)
    {
        var subject = new LAD_LadingDetail();
        subject.WeightUnitCode2 = weightUnitCode2;
        if (weight > 0)
            subject.Weight = weight;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("v1", "v2", true)]
    [InlineData("", "v2", false)]
    [InlineData("v1", "", false)]
    public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
    {
        var subject = new LAD_LadingDetail();
        subject.ProductServiceIDQualifier = productServiceIDQualifier;
        subject.ProductServiceID = productServiceID;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("v1", "v2", true)]
    [InlineData("", "v2", false)]
    [InlineData("v1", "", false)]
    public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
    {
        var subject = new LAD_LadingDetail();
        subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
        subject.ProductServiceID2 = productServiceID2;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("v1", "v2", true)]
    [InlineData("", "v2", false)]
    [InlineData("v1", "", false)]
    public void Validation_AllAreRequiredProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
    {
        var subject = new LAD_LadingDetail();
        subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
        subject.ProductServiceID3 = productServiceID3;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}