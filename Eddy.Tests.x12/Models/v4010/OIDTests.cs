using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class OIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "OID*z*c*I*pp*3*w*5*B*5";

		var expected = new OID_OrderIdentificationDetail()
		{
			ReferenceIdentification = "z",
			PurchaseOrderNumber = "c",
			ReferenceIdentification2 = "I",
			UnitOrBasisForMeasurementCode = "pp",
			Quantity = 3,
			WeightUnitCode = "w",
			Weight = 5,
			VolumeUnitQualifier = "B",
			Volume = 5,
		};

		var actual = Map.MapObject<OID_OrderIdentificationDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("z", "c", true)]
	[InlineData("z", "", true)]
	[InlineData("", "c", true)]
	public void Validation_AtLeastOneReferenceIdentification(string referenceIdentification, string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new OID_OrderIdentificationDetail();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "pp";
			subject.Quantity = 3;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "w";
			subject.Weight = 5;
		}
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "B";
			subject.Volume = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("I", "c", true)]
	[InlineData("I", "", false)]
	[InlineData("", "c", true)]
	public void Validation_ARequiresBReferenceIdentification2(string referenceIdentification2, string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new OID_OrderIdentificationDetail();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentification2 = referenceIdentification2;
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		//At Least one
		subject.ReferenceIdentification = "z";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "pp";
			subject.Quantity = 3;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "w";
			subject.Weight = 5;
		}
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "B";
			subject.Volume = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("pp", 3, true)]
	[InlineData("pp", 0, false)]
	[InlineData("", 3, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new OID_OrderIdentificationDetail();
		//Required fields
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity > 0) 
			subject.Quantity = quantity;
		//At Least one
		subject.ReferenceIdentification = "z";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "w";
			subject.Weight = 5;
		}
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "B";
			subject.Volume = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("w", 5, true)]
	[InlineData("w", 0, false)]
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
		subject.ReferenceIdentification = "z";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "pp";
			subject.Quantity = 3;
		}
		if(!string.IsNullOrEmpty(subject.VolumeUnitQualifier) || !string.IsNullOrEmpty(subject.VolumeUnitQualifier) || subject.Volume > 0)
		{
			subject.VolumeUnitQualifier = "B";
			subject.Volume = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("B", 5, true)]
	[InlineData("B", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredVolumeUnitQualifier(string volumeUnitQualifier, decimal volume, bool isValidExpected)
	{
		var subject = new OID_OrderIdentificationDetail();
		//Required fields
		//Test Parameters
		subject.VolumeUnitQualifier = volumeUnitQualifier;
		if (volume > 0) 
			subject.Volume = volume;
		//At Least one
		subject.ReferenceIdentification = "z";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "pp";
			subject.Quantity = 3;
		}
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "w";
			subject.Weight = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
