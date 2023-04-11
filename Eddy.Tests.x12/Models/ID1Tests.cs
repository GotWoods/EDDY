using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ID1Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "ID1*JhwiRq76mvnm*la*b*l*4*2R*3*4*6*GW*2*We*o*O*5*In*2*6*Y5*Y2HDtwcn*y*5*GX*b*HS*v*8*9*y*9*9*S*3*7";

        var expected = new ID1_ItemDetailDimensions
        {
            UPCEANConsumerPackageCode = "JhwiRq76mvnm",
            ProductServiceIDQualifier = "la",
            ProductServiceID = "b",
            FreeFormDescription = "l",
            Size = 4,
            UnitOrBasisForMeasurementCode = "2R",
            Height = 3,
            Width = 4,
            ItemDepth = 6,
            UnitOrBasisForMeasurementCode2 = "GW",
            Weight = 2,
            UnitOrBasisForMeasurementCode3 = "We",
            CategoryReferenceCode = "o",
            Category = "O",
            Subcategory = "5",
            UnitOrBasisForMeasurementCode4 = "In",
            Pack = 2,
            InnerPack = 6,
            DateQualifier = "Y5",
            Date = "Y2HDtwcn",
            NestingCode = "y",
            Nesting = 5,
            UnitOrBasisForMeasurementCode5 = "GX",
            PegCode = "b",
            UnitOrBasisForMeasurementCode6 = "HS",
            ReferenceIdentification = "v",
            XPeg = 8,
            YPeg = 9,
            ReferenceIdentification2 = "y",
            XPeg2 = 9,
            YPeg2 = 9,
            ReferenceIdentification3 = "S",
            XPeg3 = 3,
            YPeg3 = 7
        };

        var actual = Map.MapObject<ID1_ItemDetailDimensions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", "", false)]
    [InlineData("JhwiRq76mvnm", "la", true)]
    [InlineData("", "la", true)]
    [InlineData("JhwiRq76mvnm", "", true)]
    public void Validation_AtLeastOneUPCEANConsumerPackageCode(string uPCEANConsumerPackageCode, string productServiceIDQualifier, bool isValidExpected)
    {
        var subject = new ID1_ItemDetailDimensions();
        subject.FreeFormDescription = "l";
        subject.Size = 4;
        subject.UnitOrBasisForMeasurementCode = "2R";
        subject.Height = 3;
        subject.Width = 4;
        subject.ItemDepth = 6;
        subject.UnitOrBasisForMeasurementCode2 = "GW";
        subject.UPCEANConsumerPackageCode = uPCEANConsumerPackageCode;
        subject.ProductServiceIDQualifier = productServiceIDQualifier;

        if (productServiceIDQualifier != "")
            subject.ProductServiceID = "AB";

        subject.UPCEANConsumerPackageCode = "123456789012";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("la", "b", true)]
    [InlineData("", "b", false)]
    [InlineData("la", "", false)]
    public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
    {
        var subject = new ID1_ItemDetailDimensions();
        subject.FreeFormDescription = "l";
        subject.Size = 4;
        subject.UnitOrBasisForMeasurementCode = "2R";
        subject.Height = 3;
        subject.Width = 4;
        subject.ItemDepth = 6;
        subject.UnitOrBasisForMeasurementCode2 = "GW";
        subject.ProductServiceIDQualifier = productServiceIDQualifier;
        subject.ProductServiceID = productServiceID;
        subject.UPCEANConsumerPackageCode = "123456789012";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("l", true)]
    public void Validation_RequiredFreeFormDescription(string freeFormDescription, bool isValidExpected)
    {
        var subject = new ID1_ItemDetailDimensions();
        subject.Size = 4;
        subject.UnitOrBasisForMeasurementCode = "2R";
        subject.Height = 3;
        subject.Width = 4;
        subject.ItemDepth = 6;
        subject.UnitOrBasisForMeasurementCode2 = "GW";
        subject.FreeFormDescription = freeFormDescription;
        subject.UPCEANConsumerPackageCode = "123456789012";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData(0, false)]
    [InlineData(4, true)]
    public void Validation_RequiredSize(decimal size, bool isValidExpected)
    {
        var subject = new ID1_ItemDetailDimensions();
        subject.FreeFormDescription = "l";
        subject.UnitOrBasisForMeasurementCode = "2R";
        subject.Height = 3;
        subject.Width = 4;
        subject.ItemDepth = 6;
        subject.UnitOrBasisForMeasurementCode2 = "GW";
        if (size > 0)
            subject.Size = size;
        subject.UPCEANConsumerPackageCode = "123456789012";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("2R", true)]
    public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
    {
        var subject = new ID1_ItemDetailDimensions();
        subject.FreeFormDescription = "l";
        subject.Size = 4;
        subject.Height = 3;
        subject.Width = 4;
        subject.ItemDepth = 6;
        subject.UnitOrBasisForMeasurementCode2 = "GW";
        subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
        subject.UPCEANConsumerPackageCode = "123456789012";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData(0, false)]
    [InlineData(3, true)]
    public void Validation_RequiredHeight(decimal height, bool isValidExpected)
    {
        var subject = new ID1_ItemDetailDimensions();
        subject.FreeFormDescription = "l";
        subject.Size = 4;
        subject.UnitOrBasisForMeasurementCode = "2R";
        subject.Width = 4;
        subject.ItemDepth = 6;
        subject.UnitOrBasisForMeasurementCode2 = "GW";
        if (height > 0)
            subject.Height = height;
        subject.UPCEANConsumerPackageCode = "123456789012";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData(0, false)]
    [InlineData(4, true)]
    public void Validation_RequiredWidth(decimal width, bool isValidExpected)
    {
        var subject = new ID1_ItemDetailDimensions();
        subject.FreeFormDescription = "l";
        subject.Size = 4;
        subject.UnitOrBasisForMeasurementCode = "2R";
        subject.Height = 3;
        subject.ItemDepth = 6;
        subject.UnitOrBasisForMeasurementCode2 = "GW";
        if (width > 0)
            subject.Width = width;
        subject.UPCEANConsumerPackageCode = "123456789012";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData(0, false)]
    [InlineData(6, true)]
    public void Validation_RequiredItemDepth(decimal itemDepth, bool isValidExpected)
    {
        var subject = new ID1_ItemDetailDimensions();
        subject.FreeFormDescription = "l";
        subject.Size = 4;
        subject.UnitOrBasisForMeasurementCode = "2R";
        subject.Height = 3;
        subject.Width = 4;
        subject.UnitOrBasisForMeasurementCode2 = "GW";
        if (itemDepth > 0)
            subject.ItemDepth = itemDepth;
        subject.UPCEANConsumerPackageCode = "123456789012";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("GW", true)]
    public void Validation_RequiredUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, bool isValidExpected)
    {
        var subject = new ID1_ItemDetailDimensions();
        subject.FreeFormDescription = "l";
        subject.Size = 4;
        subject.UnitOrBasisForMeasurementCode = "2R";
        subject.Height = 3;
        subject.Width = 4;
        subject.ItemDepth = 6;
        subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
        subject.UPCEANConsumerPackageCode = "123456789012";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(2, "We", true)]
    [InlineData(0, "We", false)]
    [InlineData(2, "", false)]
    public void Validation_AllAreRequiredWeight(decimal weight, string unitOrBasisForMeasurementCode3, bool isValidExpected)
    {
        var subject = new ID1_ItemDetailDimensions();
        subject.FreeFormDescription = "l";
        subject.Size = 4;
        subject.UnitOrBasisForMeasurementCode = "2R";
        subject.Height = 3;
        subject.Width = 4;
        subject.ItemDepth = 6;
        subject.UnitOrBasisForMeasurementCode2 = "GW";
        if (weight > 0)
            subject.Weight = weight;
        subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
        subject.UPCEANConsumerPackageCode = "123456789012";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("o", "O", true)]
    [InlineData("", "O", false)]
    [InlineData("o", "", false)]
    public void Validation_AllAreRequiredCategoryReferenceCode(string categoryReferenceCode, string category, bool isValidExpected)
    {
        var subject = new ID1_ItemDetailDimensions();
        subject.FreeFormDescription = "l";
        subject.Size = 4;
        subject.UnitOrBasisForMeasurementCode = "2R";
        subject.Height = 3;
        subject.Width = 4;
        subject.ItemDepth = 6;
        subject.UnitOrBasisForMeasurementCode2 = "GW";
        subject.CategoryReferenceCode = categoryReferenceCode;
        subject.Category = category;

        subject.UPCEANConsumerPackageCode = "123456789012";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("Y5", "Y2HDtwcn", true)]
    [InlineData("", "Y2HDtwcn", false)]
    [InlineData("Y5", "", false)]
    public void Validation_AllAreRequiredDateQualifier(string dateQualifier, string date, bool isValidExpected)
    {
        var subject = new ID1_ItemDetailDimensions();
        subject.FreeFormDescription = "l";
        subject.Size = 4;
        subject.UnitOrBasisForMeasurementCode = "2R";
        subject.Height = 3;
        subject.Width = 4;
        subject.ItemDepth = 6;
        subject.UnitOrBasisForMeasurementCode2 = "GW";
        subject.DateQualifier = dateQualifier;
        subject.Date = date;

        subject.UPCEANConsumerPackageCode = "123456789012";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "HS", true)]
    [InlineData("v", "", false)]
    public void Validation_ARequiresBReferenceIdentification(string referenceIdentification, string unitOrBasisForMeasurementCode6, bool isValidExpected)
    {
        var subject = new ID1_ItemDetailDimensions();
        subject.FreeFormDescription = "l";
        subject.Size = 4;
        subject.UnitOrBasisForMeasurementCode = "2R";
        subject.Height = 3;
        subject.Width = 4;
        subject.ItemDepth = 6;
        subject.UnitOrBasisForMeasurementCode2 = "GW";
        subject.ReferenceIdentification = referenceIdentification;
        subject.UnitOrBasisForMeasurementCode6 = unitOrBasisForMeasurementCode6;

        subject.UPCEANConsumerPackageCode = "123456789012";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "HS", true)]
    [InlineData("y", "", false)]
    public void Validation_ARequiresBReferenceIdentification2(string referenceIdentification2, string unitOrBasisForMeasurementCode6, bool isValidExpected)
    {
        var subject = new ID1_ItemDetailDimensions();
        subject.FreeFormDescription = "l";
        subject.Size = 4;
        subject.UnitOrBasisForMeasurementCode = "2R";
        subject.Height = 3;
        subject.Width = 4;
        subject.ItemDepth = 6;
        subject.UnitOrBasisForMeasurementCode2 = "GW";
        subject.ReferenceIdentification2 = referenceIdentification2;
        subject.UnitOrBasisForMeasurementCode6 = unitOrBasisForMeasurementCode6;

        subject.UPCEANConsumerPackageCode = "123456789012";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "HS", true)]
    [InlineData("S", "", false)]
    public void Validation_ARequiresBReferenceIdentification3(string referenceIdentification3, string unitOrBasisForMeasurementCode6, bool isValidExpected)
    {
        var subject = new ID1_ItemDetailDimensions();
        subject.FreeFormDescription = "l";
        subject.Size = 4;
        subject.UnitOrBasisForMeasurementCode = "2R";
        subject.Height = 3;
        subject.Width = 4;
        subject.ItemDepth = 6;
        subject.UnitOrBasisForMeasurementCode2 = "GW";
        subject.ReferenceIdentification3 = referenceIdentification3;
        subject.UnitOrBasisForMeasurementCode6 = unitOrBasisForMeasurementCode6;

        subject.UPCEANConsumerPackageCode = "123456789012";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
}