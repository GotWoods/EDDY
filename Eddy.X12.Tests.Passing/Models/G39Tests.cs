using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G39Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "G39*bMQqSHpFNF6w*XP*I*a4*2*e*q*8*1D*8*ky*2*MN*4*FZ*195333*2*7*Lk*P*8*9*e6*a*I*4*7*ilW*M";

        var expected = new G39_ItemCharacteristicsVendorsSellingUnit
        {
            UPCCaseCode = "bMQqSHpFNF6w",
            ProductServiceIDQualifier = "XP",
            ProductServiceID = "I",
            SpecialHandlingCode = "a4",
            UnitWeight = 2,
            WeightQualifier = "e",
            WeightUnitCode = "q",
            Height = 8,
            UnitOrBasisForMeasurementCode = "1D",
            Width = 8,
            UnitOrBasisForMeasurementCode2 = "ky",
            Length = 2,
            UnitOrBasisForMeasurementCode3 = "MN",
            Volume = 4,
            UnitOrBasisForMeasurementCode4 = "FZ",
            PalletBlockAndTiers = 195333,
            Pack = 2,
            Size = 7,
            UnitOrBasisForMeasurementCode5 = "Lk",
            Color = "P",
            OrderSizingFactor = 8,
            AlternateTiersPerPallet = 9,
            ProductServiceIDQualifier2 = "e6",
            ProductServiceID2 = "a",
            WeightQualifier2 = "I",
            UnitWeight2 = 4,
            InnerPack = 7,
            PackagingCode = "ilW",
            CashRegisterItemDescription = "M"
        };

        var actual = Map.MapObject<G39_ItemCharacteristicsVendorsSellingUnit>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", "", false)]
    [InlineData("bMQqSHpFNF6w", "XP", true)]
    [InlineData("", "XP", true)]
    [InlineData("bMQqSHpFNF6w", "", true)]
    public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
    {
        var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
        subject.UPCCaseCode = uPCCaseCode;
        subject.ProductServiceIDQualifier = productServiceIDQualifier;

        if (productServiceIDQualifier != "")
            subject.ProductServiceID = "AB";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("XP", "I", true)]
    [InlineData("", "I", false)]
    [InlineData("XP", "", false)]
    public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
    {
        var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
        subject.ProductServiceIDQualifier = productServiceIDQualifier;
        subject.ProductServiceID = productServiceID;
        subject.UPCCaseCode = "123456789012";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(8, "1D", true)]
    [InlineData(0, "1D", false)]
    [InlineData(8, "", false)]
    public void Validation_AllAreRequiredHeight(decimal height, string unitOrBasisForMeasurementCode, bool isValidExpected)
    {
        var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
        if (height > 0)
            subject.Height = height;
        subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
        subject.UPCCaseCode = "123456789012";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(8, "ky", true)]
    [InlineData(0, "ky", false)]
    [InlineData(8, "", false)]
    public void Validation_AllAreRequiredWidth(decimal width, string unitOrBasisForMeasurementCode2, bool isValidExpected)
    {
        var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
        subject.UPCCaseCode = "123456789012";
        if (width > 0)
            subject.Width = width;
        subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(2, "MN", true)]
    [InlineData(0, "MN", false)]
    [InlineData(2, "", false)]
    public void Validation_AllAreRequiredLength(decimal length, string unitOrBasisForMeasurementCode3, bool isValidExpected)
    {
        var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
        subject.UPCCaseCode = "123456789012";
        if (length > 0)
            subject.Length = length;
        subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(4, "FZ", true)]
    [InlineData(0, "FZ", false)]
    [InlineData(4, "", false)]
    public void Validation_AllAreRequiredVolume(decimal volume, string unitOrBasisForMeasurementCode4, bool isValidExpected)
    {
        var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
        subject.UPCCaseCode = "123456789012";
        if (volume > 0)
            subject.Volume = volume;
        subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(7, "Lk", true)]
    [InlineData(0, "Lk", false)]
    [InlineData(7, "", false)]
    public void Validation_AllAreRequiredSize(decimal size, string unitOrBasisForMeasurementCode5, bool isValidExpected)
    {
        var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
        subject.UPCCaseCode = "123456789012";
        if (size > 0)
            subject.Size = size;
        subject.UnitOrBasisForMeasurementCode5 = unitOrBasisForMeasurementCode5;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("e6", "a", true)]
    [InlineData("", "a", false)]
    [InlineData("e6", "", false)]
    public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
    {
        var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
        subject.UPCCaseCode = "123456789012";
        subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
        subject.ProductServiceID2 = productServiceID2;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", 0, true)]
    [InlineData("I", 4, true)]
    [InlineData("", 4, false)]
    [InlineData("I", 0, false)]
    public void Validation_AllAreRequiredWeightQualifier2(string weightQualifier2, decimal unitWeight2, bool isValidExpected)
    {
        var subject = new G39_ItemCharacteristicsVendorsSellingUnit();
        subject.UPCCaseCode = "123456789012";
        subject.WeightQualifier2 = weightQualifier2;
        if (unitWeight2 > 0)
            subject.UnitWeight2 = unitWeight2;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}