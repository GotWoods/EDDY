using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class OIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "OID*I*Y*0*xJv*3*h*6*A*3*c*g";

		var expected = new OID_OrderInformationDetail()
		{
			ReferenceIdentification = "I",
			PurchaseOrderNumber = "Y",
			ReferenceIdentification2 = "0",
			PackagingFormCode = "xJv",
			Quantity = 3,
			WeightUnitCode = "h",
			Weight = 6,
			VolumeUnitQualifier = "A",
			Volume = 3,
			ApplicationErrorConditionCode = "c",
			ReferenceIdentification3 = "g",
		};

		var actual = Map.MapObject<OID_OrderInformationDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("I", "Y", true)]
	[InlineData("I", "", true)]
	[InlineData("", "Y", true)]
	public void Validation_AtLeastOneReferenceIdentification(string referenceIdentification, string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new OID_OrderInformationDetail();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PackagingFormCode) || !string.IsNullOrEmpty(subject.PackagingFormCode) || subject.Quantity > 0)
		{
			subject.PackagingFormCode = "xJv";
			subject.Quantity = 3;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "h";
			subject.Weight = 6;
		}
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "A";
			subject.Volume = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0", "Y", true)]
	[InlineData("0", "", false)]
	[InlineData("", "Y", true)]
	public void Validation_ARequiresBReferenceIdentification2(string referenceIdentification2, string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new OID_OrderInformationDetail();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentification2 = referenceIdentification2;
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		//At Least one
		subject.ReferenceIdentification = "I";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PackagingFormCode) || !string.IsNullOrEmpty(subject.PackagingFormCode) || subject.Quantity > 0)
		{
			subject.PackagingFormCode = "xJv";
			subject.Quantity = 3;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "h";
			subject.Weight = 6;
		}
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "A";
			subject.Volume = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("xJv", 3, true)]
	[InlineData("xJv", 0, false)]
	[InlineData("", 3, false)]
	public void Validation_AllAreRequiredPackagingFormCode(string packagingFormCode, decimal quantity, bool isValidExpected)
	{
		var subject = new OID_OrderInformationDetail();
		//Required fields
		//Test Parameters
		subject.PackagingFormCode = packagingFormCode;
		if (quantity > 0) 
			subject.Quantity = quantity;
		//At Least one
		subject.ReferenceIdentification = "I";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "h";
			subject.Weight = 6;
		}
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "A";
			subject.Volume = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("h", 6, true)]
	[InlineData("h", 0, false)]
	[InlineData("", 6, false)]
	public void Validation_AllAreRequiredWeightUnitCode(string weightUnitCode, decimal weight, bool isValidExpected)
	{
		var subject = new OID_OrderInformationDetail();
		//Required fields
		//Test Parameters
		subject.WeightUnitCode = weightUnitCode;
		if (weight > 0) 
			subject.Weight = weight;
		//At Least one
		subject.ReferenceIdentification = "I";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PackagingFormCode) || !string.IsNullOrEmpty(subject.PackagingFormCode) || subject.Quantity > 0)
		{
			subject.PackagingFormCode = "xJv";
			subject.Quantity = 3;
		}
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "A";
			subject.Volume = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("A", 3, true)]
	[InlineData("A", 0, false)]
	[InlineData("", 3, false)]
	public void Validation_AllAreRequiredVolumeUnitQualifier(string volumeUnitQualifier, decimal volume, bool isValidExpected)
	{
		var subject = new OID_OrderInformationDetail();
		//Required fields
		//Test Parameters
		subject.VolumeUnitQualifier = volumeUnitQualifier;
		if (volume > 0) 
			subject.Volume = volume;
		//At Least one
		subject.ReferenceIdentification = "I";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PackagingFormCode) || !string.IsNullOrEmpty(subject.PackagingFormCode) || subject.Quantity > 0)
		{
			subject.PackagingFormCode = "xJv";
			subject.Quantity = 3;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "h";
			subject.Weight = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
