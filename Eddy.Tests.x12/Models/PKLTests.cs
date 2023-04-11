using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PKLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PKL*Hg*A*vA*2*4*8*2*Wq*7*3i*7*cp*M";

		var expected = new PKL_MultiPackConfiguration()
		{
			ProductServiceIDQualifier = "Hg",
			ProductServiceID = "A",
			UnitOrBasisForMeasurementCode = "vA",
			Quantity = 2,
			Height = 4,
			Width = 8,
			ItemDepth = 2,
			UnitOrBasisForMeasurementCode2 = "Wq",
			GrossWeightPerPack = 7,
			UnitOrBasisForMeasurementCode3 = "3i",
			GrossVolumePerPack = 7,
			UnitOrBasisForMeasurementCode4 = "cp",
			YesNoConditionOrResponseCode = "M",
		};

		var actual = Map.MapObject<PKL_MultiPackConfiguration>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Hg", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		subject.ProductServiceID = "A";
		subject.UnitOrBasisForMeasurementCode = "vA";
		subject.Quantity = 2;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		subject.ProductServiceIDQualifier = "Hg";
		subject.UnitOrBasisForMeasurementCode = "vA";
		subject.Quantity = 2;
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vA", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		subject.ProductServiceIDQualifier = "Hg";
		subject.ProductServiceID = "A";
		subject.Quantity = 2;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		subject.ProductServiceIDQualifier = "Hg";
		subject.ProductServiceID = "A";
		subject.UnitOrBasisForMeasurementCode = "vA";
		if (quantity > 0)
		subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "Wq", true)]
	[InlineData(4, "", false)]
	public void Validation_ARequiresBHeight(decimal height, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		subject.ProductServiceIDQualifier = "Hg";
		subject.ProductServiceID = "A";
		subject.UnitOrBasisForMeasurementCode = "vA";
		subject.Quantity = 2;
		if (height > 0)
		subject.Height = height;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "Wq", true)]
	[InlineData(8, "", false)]
	public void Validation_ARequiresBWidth(decimal width, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		subject.ProductServiceIDQualifier = "Hg";
		subject.ProductServiceID = "A";
		subject.UnitOrBasisForMeasurementCode = "vA";
		subject.Quantity = 2;
		if (width > 0)
		subject.Width = width;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "Wq", true)]
	[InlineData(2, "", false)]
	public void Validation_ARequiresBItemDepth(decimal itemDepth, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		subject.ProductServiceIDQualifier = "Hg";
		subject.ProductServiceID = "A";
		subject.UnitOrBasisForMeasurementCode = "vA";
		subject.Quantity = 2;
		if (itemDepth > 0)
		subject.ItemDepth = itemDepth;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("",0, 0, 0, true)]
	[InlineData("Wq", 4, 0, 0, true)]
	[InlineData("",4, 0, 0, true)]
	[InlineData("Wq", 0, 0, 0, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_UnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, decimal height, decimal width, decimal itemDepth, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		subject.ProductServiceIDQualifier = "Hg";
		subject.ProductServiceID = "A";
		subject.UnitOrBasisForMeasurementCode = "vA";
		subject.Quantity = 2;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		if (height > 0)
		subject.Height = height;
		if (width > 0)
		subject.Width = width;
		if (itemDepth > 0)
		subject.ItemDepth = itemDepth;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(7, "3i", true)]
	[InlineData(0, "3i", false)]
	[InlineData(7, "", false)]
	public void Validation_AllAreRequiredGrossWeightPerPack(decimal grossWeightPerPack, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		subject.ProductServiceIDQualifier = "Hg";
		subject.ProductServiceID = "A";
		subject.UnitOrBasisForMeasurementCode = "vA";
		subject.Quantity = 2;
		if (grossWeightPerPack > 0)
		subject.GrossWeightPerPack = grossWeightPerPack;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(7, "cp", true)]
	[InlineData(0, "cp", false)]
	[InlineData(7, "", false)]
	public void Validation_AllAreRequiredGrossVolumePerPack(decimal grossVolumePerPack, string unitOrBasisForMeasurementCode4, bool isValidExpected)
	{
		var subject = new PKL_MultiPackConfiguration();
		subject.ProductServiceIDQualifier = "Hg";
		subject.ProductServiceID = "A";
		subject.UnitOrBasisForMeasurementCode = "vA";
		subject.Quantity = 2;
		if (grossVolumePerPack > 0)
		subject.GrossVolumePerPack = grossVolumePerPack;
		subject.UnitOrBasisForMeasurementCode4 = unitOrBasisForMeasurementCode4;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
