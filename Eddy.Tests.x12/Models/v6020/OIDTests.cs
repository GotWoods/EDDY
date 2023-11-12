using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6020;

namespace Eddy.x12.Tests.Models.v6020;

public class OIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "OID*L*u*P*XUp*8*t*7*m*6*K*R*ZgP*2";

		var expected = new OID_OrderInformationDetail()
		{
			ReferenceIdentification = "L",
			PurchaseOrderNumber = "u",
			ReferenceIdentification2 = "P",
			PackagingFormCode = "XUp",
			Quantity = 8,
			WeightUnitCode = "t",
			Weight = 7,
			VolumeUnitQualifier = "m",
			Volume = 6,
			ApplicationErrorConditionCode = "K",
			ReferenceIdentification3 = "R",
			PackagingFormCode2 = "ZgP",
			Quantity2 = 2,
		};

		var actual = Map.MapObject<OID_OrderInformationDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("L", "u", true)]
	[InlineData("L", "", true)]
	[InlineData("", "u", true)]
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
			subject.PackagingFormCode = "XUp";
			subject.Quantity = 8;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "t";
			subject.Weight = 7;
		}
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "m";
			subject.Volume = 6;
		}
		if(!string.IsNullOrEmpty(subject.PackagingFormCode2) || !string.IsNullOrEmpty(subject.PackagingFormCode2) || subject.Quantity2 > 0)
		{
			subject.PackagingFormCode2 = "ZgP";
			subject.Quantity2 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("P", "u", true)]
	[InlineData("P", "", false)]
	[InlineData("", "u", true)]
	public void Validation_ARequiresBReferenceIdentification2(string referenceIdentification2, string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new OID_OrderInformationDetail();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentification2 = referenceIdentification2;
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		//At Least one
		subject.ReferenceIdentification = "L";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PackagingFormCode) || !string.IsNullOrEmpty(subject.PackagingFormCode) || subject.Quantity > 0)
		{
			subject.PackagingFormCode = "XUp";
			subject.Quantity = 8;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "t";
			subject.Weight = 7;
		}
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "m";
			subject.Volume = 6;
		}
		if(!string.IsNullOrEmpty(subject.PackagingFormCode2) || !string.IsNullOrEmpty(subject.PackagingFormCode2) || subject.Quantity2 > 0)
		{
			subject.PackagingFormCode2 = "ZgP";
			subject.Quantity2 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("XUp", 8, true)]
	[InlineData("XUp", 0, false)]
	[InlineData("", 8, false)]
	public void Validation_AllAreRequiredPackagingFormCode(string packagingFormCode, decimal quantity, bool isValidExpected)
	{
		var subject = new OID_OrderInformationDetail();
		//Required fields
		//Test Parameters
		subject.PackagingFormCode = packagingFormCode;
		if (quantity > 0) 
			subject.Quantity = quantity;
		//At Least one
		subject.ReferenceIdentification = "L";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "t";
			subject.Weight = 7;
		}
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "m";
			subject.Volume = 6;
		}
		if(!string.IsNullOrEmpty(subject.PackagingFormCode2) || !string.IsNullOrEmpty(subject.PackagingFormCode2) || subject.Quantity2 > 0)
		{
			subject.PackagingFormCode2 = "ZgP";
			subject.Quantity2 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("t", 7, true)]
	[InlineData("t", 0, false)]
	[InlineData("", 7, false)]
	public void Validation_AllAreRequiredWeightUnitCode(string weightUnitCode, decimal weight, bool isValidExpected)
	{
		var subject = new OID_OrderInformationDetail();
		//Required fields
		//Test Parameters
		subject.WeightUnitCode = weightUnitCode;
		if (weight > 0) 
			subject.Weight = weight;
		//At Least one
		subject.ReferenceIdentification = "L";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PackagingFormCode) || !string.IsNullOrEmpty(subject.PackagingFormCode) || subject.Quantity > 0)
		{
			subject.PackagingFormCode = "XUp";
			subject.Quantity = 8;
		}
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "m";
			subject.Volume = 6;
		}
		if(!string.IsNullOrEmpty(subject.PackagingFormCode2) || !string.IsNullOrEmpty(subject.PackagingFormCode2) || subject.Quantity2 > 0)
		{
			subject.PackagingFormCode2 = "ZgP";
			subject.Quantity2 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("m", 6, true)]
	[InlineData("m", 0, false)]
	[InlineData("", 6, false)]
	public void Validation_AllAreRequiredVolumeUnitQualifier(string volumeUnitQualifier, decimal volume, bool isValidExpected)
	{
		var subject = new OID_OrderInformationDetail();
		//Required fields
		//Test Parameters
		subject.VolumeUnitQualifier = volumeUnitQualifier;
		if (volume > 0) 
			subject.Volume = volume;
		//At Least one
		subject.ReferenceIdentification = "L";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PackagingFormCode) || !string.IsNullOrEmpty(subject.PackagingFormCode) || subject.Quantity > 0)
		{
			subject.PackagingFormCode = "XUp";
			subject.Quantity = 8;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "t";
			subject.Weight = 7;
		}
		if(!string.IsNullOrEmpty(subject.PackagingFormCode2) || !string.IsNullOrEmpty(subject.PackagingFormCode2) || subject.Quantity2 > 0)
		{
			subject.PackagingFormCode2 = "ZgP";
			subject.Quantity2 = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("ZgP", 2, true)]
	[InlineData("ZgP", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredPackagingFormCode2(string packagingFormCode2, decimal quantity2, bool isValidExpected)
	{
		var subject = new OID_OrderInformationDetail();
		//Required fields
		//Test Parameters
		subject.PackagingFormCode2 = packagingFormCode2;
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		//At Least one
		subject.ReferenceIdentification = "L";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PackagingFormCode) || !string.IsNullOrEmpty(subject.PackagingFormCode) || subject.Quantity > 0)
		{
			subject.PackagingFormCode = "XUp";
			subject.Quantity = 8;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "t";
			subject.Weight = 7;
		}
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "m";
			subject.Volume = 6;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
