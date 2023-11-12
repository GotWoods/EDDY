using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class OIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "OID*X*O*6*9lv*5*z*9*U*1*b*t";

		var expected = new OID_OrderIdentificationDetail()
		{
			ReferenceIdentification = "X",
			PurchaseOrderNumber = "O",
			ReferenceIdentification2 = "6",
			PackagingFormCode = "9lv",
			Quantity = 5,
			WeightUnitCode = "z",
			Weight = 9,
			VolumeUnitQualifier = "U",
			Volume = 1,
			ApplicationErrorConditionCode = "b",
			ReferenceIdentification3 = "t",
		};

		var actual = Map.MapObject<OID_OrderIdentificationDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("X", "O", true)]
	[InlineData("X", "", true)]
	[InlineData("", "O", true)]
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
			subject.PackagingFormCode = "9lv";
			subject.Quantity = 5;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "z";
			subject.Weight = 9;
		}
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "U";
			subject.Volume = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("6", "O", true)]
	[InlineData("6", "", false)]
	[InlineData("", "O", true)]
	public void Validation_ARequiresBReferenceIdentification2(string referenceIdentification2, string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new OID_OrderIdentificationDetail();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentification2 = referenceIdentification2;
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		//At Least one
		subject.ReferenceIdentification = "X";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PackagingFormCode) || !string.IsNullOrEmpty(subject.PackagingFormCode) || subject.Quantity > 0)
		{
			subject.PackagingFormCode = "9lv";
			subject.Quantity = 5;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "z";
			subject.Weight = 9;
		}
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "U";
			subject.Volume = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("9lv", 5, true)]
	[InlineData("9lv", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredPackagingFormCode(string packagingFormCode, decimal quantity, bool isValidExpected)
	{
		var subject = new OID_OrderIdentificationDetail();
		//Required fields
		//Test Parameters
		subject.PackagingFormCode = packagingFormCode;
		if (quantity > 0) 
			subject.Quantity = quantity;
		//At Least one
		subject.ReferenceIdentification = "X";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "z";
			subject.Weight = 9;
		}
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "U";
			subject.Volume = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("z", 9, true)]
	[InlineData("z", 0, false)]
	[InlineData("", 9, false)]
	public void Validation_AllAreRequiredWeightUnitCode(string weightUnitCode, decimal weight, bool isValidExpected)
	{
		var subject = new OID_OrderIdentificationDetail();
		//Required fields
		//Test Parameters
		subject.WeightUnitCode = weightUnitCode;
		if (weight > 0) 
			subject.Weight = weight;
		//At Least one
		subject.ReferenceIdentification = "X";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PackagingFormCode) || !string.IsNullOrEmpty(subject.PackagingFormCode) || subject.Quantity > 0)
		{
			subject.PackagingFormCode = "9lv";
			subject.Quantity = 5;
		}
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "U";
			subject.Volume = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("U", 1, true)]
	[InlineData("U", 0, false)]
	[InlineData("", 1, false)]
	public void Validation_AllAreRequiredVolumeUnitQualifier(string volumeUnitQualifier, decimal volume, bool isValidExpected)
	{
		var subject = new OID_OrderIdentificationDetail();
		//Required fields
		//Test Parameters
		subject.VolumeUnitQualifier = volumeUnitQualifier;
		if (volume > 0) 
			subject.Volume = volume;
		//At Least one
		subject.ReferenceIdentification = "X";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PackagingFormCode) || !string.IsNullOrEmpty(subject.PackagingFormCode) || subject.Quantity > 0)
		{
			subject.PackagingFormCode = "9lv";
			subject.Quantity = 5;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "z";
			subject.Weight = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
