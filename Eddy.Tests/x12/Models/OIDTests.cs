using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class OIDTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "OID*e*j*U*Ttd*1*s*2*J*3*d*f*ocu*4";

        var expected = new OID_OrderInformationDetail()
        {
            ReferenceIdentification = "e",
            PurchaseOrderNumber = "j",
            ReferenceIdentification2 = "U",
            PackagingFormCode = "Ttd",
            Quantity = 1,
            WeightUnitCode = "s",
            Weight = 2,
            VolumeUnitQualifier = "J",
            Volume = 3,
            ApplicationErrorConditionCode = "d",
            ReferenceIdentification3 = "f",
            PackagingFormCode2 = "ocu",
            Quantity2 = 4,
        };

        var actual = Map.MapObject<OID_OrderInformationDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", "", false)]
    [InlineData("v1", "v2", true)]
    [InlineData("", "v2", true)]
    [InlineData("v1", "", true)]
    public void Validation_AtLeastOneReferenceIdentification(string referenceIdentification, string purchaseOrderNumber, bool isValidExpected)
    {
        var subject = new OID_OrderInformationDetail();
        subject.ReferenceIdentification = referenceIdentification;
        subject.PurchaseOrderNumber = purchaseOrderNumber;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
    }
    [Theory]
    [InlineData("", "v2", true)]
    [InlineData("v1", "", true)]
    public void Validation_ARequiresBReferenceIdentification(string referenceIdentification, string purchaseOrderNumber, bool isValidExpected)
    {
        var subject = new OID_OrderInformationDetail();
        subject.ReferenceIdentification = referenceIdentification;
        subject.PurchaseOrderNumber = purchaseOrderNumber;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
    [Theory]
    [InlineData("", 0, true)]
    [InlineData("123", 1, true)]
    [InlineData("", 1, false)]
    [InlineData("123", 0, false)]
    public void Validation_AllAreRequiredPackagingFormCode(string packagingFormCode, decimal quantity, bool isValidExpected)
    {
        var subject = new OID_OrderInformationDetail();
        subject.ReferenceIdentification = "ABC";
        subject.PackagingFormCode = packagingFormCode;

        if (quantity > 0)
            subject.Quantity = quantity;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
    [Theory]
    [InlineData("", 0, true)]
    [InlineData("1", 1, true)]
    [InlineData("", 1, false)]
    [InlineData("1", 0, false)]
    public void Validation_AllAreRequiredWeightUnitCode(string weightUnitCode, decimal weight, bool isValidExpected)
    {
        var subject = new OID_OrderInformationDetail();
        subject.ReferenceIdentification = "ABC";
        subject.WeightUnitCode = weightUnitCode;
        if (weight > 0)
            subject.Weight = weight;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
    [Theory]
    [InlineData("", 0, true)]
    [InlineData("1", 1, true)]
    [InlineData("", 1, false)]
    [InlineData("1", 0, false)]
    public void Validation_AllAreRequiredVolumeUnitQualifier(string volumeUnitQualifier, decimal volume, bool isValidExpected)
    {
        var subject = new OID_OrderInformationDetail();
        subject.ReferenceIdentification = "ABC";
        subject.VolumeUnitQualifier = volumeUnitQualifier;
        if (volume > 0)
            subject.Volume = volume;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
    [Theory]
    [InlineData("", 0, true)]
    [InlineData("123", 1, true)]
    [InlineData("", 1, false)]
    [InlineData("123", 0, false)]
    public void Validation_AllAreRequiredPackagingFormCode2(string packagingFormCode, decimal quantity, bool isValidExpected)
    {
        var subject = new OID_OrderInformationDetail();
        subject.ReferenceIdentification = "ABC";
        subject.PackagingFormCode2 = packagingFormCode;
        if (quantity > 0)
            subject.Quantity2 = quantity;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}