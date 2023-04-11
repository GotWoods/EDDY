using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ID3Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "ID3*0FApnNkzIA56*2f*H*3*1*9*3*5*04*5*Qm*1*PT*6*3*5*5*SP*v*1*qn";

        var expected = new ID3_DimensionsDetail
        {
            UPCCaseCode = "0FApnNkzIA56",
            ProductServiceIDQualifier = "2f",
            ProductServiceID = "H",
            Pack = 3,
            InnerPack = 1,
            Height = 9,
            Width = 3,
            ItemDepth = 5,
            UnitOrBasisForMeasurementCode = "04",
            Weight = 5,
            UnitOrBasisForMeasurementCode2 = "Qm",
            Volume = 1,
            UnitOrBasisForMeasurementCode3 = "PT",
            TrayCount = 6,
            Height2 = 3,
            Width2 = 5,
            ItemDepth2 = 5,
            UnitOrBasisForMeasurementCode4 = "SP",
            NestingCode = "v",
            Nesting = 1,
            UnitOrBasisForMeasurementCode5 = "qn"
        };

        var actual = Map.MapObject<ID3_DimensionsDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", "", false)]
    [InlineData("0FApnNkzIA56", "2f", true)]
    [InlineData("", "2f", true)]
    [InlineData("0FApnNkzIA56", "", true)]
    public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
    {
        var subject = new ID3_DimensionsDetail();
        subject.UPCCaseCode = uPCCaseCode;
        subject.ProductServiceIDQualifier = productServiceIDQualifier;
        subject.UPCCaseCode = "123456789012";

        if (productServiceIDQualifier != "")
            subject.ProductServiceID = "AA";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("2f", "H", true)]
    [InlineData("", "H", false)]
    [InlineData("2f", "", false)]
    public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
    {
        var subject = new ID3_DimensionsDetail();
        subject.ProductServiceIDQualifier = productServiceIDQualifier;
        subject.ProductServiceID = productServiceID;
        subject.UPCCaseCode = "123456789012";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(5, "Qm", true)]
    [InlineData(0, "Qm", false)]
    [InlineData(5, "", false)]
    public void Validation_AllAreRequiredWeight(decimal weight, string unitOrBasisForMeasurementCode2, bool isValidExpected)
    {
        var subject = new ID3_DimensionsDetail();
        if (weight > 0)
            subject.Weight = weight;
        subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
        subject.UPCCaseCode = "123456789012";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(1, "PT", true)]
    [InlineData(0, "PT", false)]
    [InlineData(1, "", false)]
    public void Validation_AllAreRequiredVolume(decimal volume, string unitOrBasisForMeasurementCode3, bool isValidExpected)
    {
        var subject = new ID3_DimensionsDetail();
        if (volume > 0)
            subject.Volume = volume;
        subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
        subject.UPCCaseCode = "123456789012";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(1, "qn", true)]
    [InlineData(0, "qn", false)]
    [InlineData(1, "", false)]
    public void Validation_AllAreRequiredNesting(decimal nesting, string unitOrBasisForMeasurementCode5, bool isValidExpected)
    {
        var subject = new ID3_DimensionsDetail();
        if (nesting > 0)
            subject.Nesting = nesting;
        subject.UnitOrBasisForMeasurementCode5 = unitOrBasisForMeasurementCode5;

        subject.UPCCaseCode = "123456789012";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}