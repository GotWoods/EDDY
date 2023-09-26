using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class OIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "OID*k*P*T*FWE*1*z*5*s*2";

		var expected = new OID_OrderIdentificationDetail()
		{
			ReferenceIdentification = "k",
			PurchaseOrderNumber = "P",
			ReferenceIdentification2 = "T",
			PackagingFormCode = "FWE",
			Quantity = 1,
			WeightUnitCode = "z",
			Weight = 5,
			VolumeUnitQualifier = "s",
			Volume = 2,
		};

		var actual = Map.MapObject<OID_OrderIdentificationDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("k", "P", true)]
	[InlineData("k", "", true)]
	[InlineData("", "P", true)]
	public void Validation_AtLeastOneReferenceIdentification(string referenceIdentification, string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new OID_OrderIdentificationDetail();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PackagingFormCode) || !string.IsNullOrEmpty(subject.PackagingFormCode) || subject.Quantity > 0)
		{
			subject.PackagingFormCode = "FWE";
			subject.Quantity = 1;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "z";
			subject.Weight = 5;
		}
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "s";
			subject.Volume = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("T", "P", true)]
	[InlineData("T", "", false)]
	[InlineData("", "P", true)]
	public void Validation_ARequiresBReferenceIdentification2(string referenceIdentification2, string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new OID_OrderIdentificationDetail();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentification2 = referenceIdentification2;
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		//At Least one
		subject.ReferenceIdentification = "k";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PackagingFormCode) || !string.IsNullOrEmpty(subject.PackagingFormCode) || subject.Quantity > 0)
		{
			subject.PackagingFormCode = "FWE";
			subject.Quantity = 1;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "z";
			subject.Weight = 5;
		}
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "s";
			subject.Volume = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("FWE", 1, true)]
	[InlineData("FWE", 0, false)]
	[InlineData("", 1, false)]
	public void Validation_AllAreRequiredPackagingFormCode(string packagingFormCode, decimal quantity, bool isValidExpected)
	{
		var subject = new OID_OrderIdentificationDetail();
		//Required fields
		//Test Parameters
		subject.PackagingFormCode = packagingFormCode;
		if (quantity > 0) 
			subject.Quantity = quantity;
		//At Least one
		subject.ReferenceIdentification = "k";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "z";
			subject.Weight = 5;
		}
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "s";
			subject.Volume = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("z", 5, true)]
	[InlineData("z", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredWeightUnitCode(string weightUnitCode, decimal weight, bool isValidExpected)
	{
		var subject = new OID_OrderIdentificationDetail();
		//Required fields
		//Test Parameters
		subject.WeightUnitCode = weightUnitCode;
		if (weight > 0) 
			subject.Weight = weight;
		//At Least one
		subject.ReferenceIdentification = "k";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PackagingFormCode) || !string.IsNullOrEmpty(subject.PackagingFormCode) || subject.Quantity > 0)
		{
			subject.PackagingFormCode = "FWE";
			subject.Quantity = 1;
		}
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "s";
			subject.Volume = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("s", 2, true)]
	[InlineData("s", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredVolumeUnitQualifier(string volumeUnitQualifier, decimal volume, bool isValidExpected)
	{
		var subject = new OID_OrderIdentificationDetail();
		//Required fields
		//Test Parameters
		subject.VolumeUnitQualifier = volumeUnitQualifier;
		if (volume > 0) 
			subject.Volume = volume;
		//At Least one
		subject.ReferenceIdentification = "k";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PackagingFormCode) || !string.IsNullOrEmpty(subject.PackagingFormCode) || subject.Quantity > 0)
		{
			subject.PackagingFormCode = "FWE";
			subject.Quantity = 1;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "z";
			subject.Weight = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
