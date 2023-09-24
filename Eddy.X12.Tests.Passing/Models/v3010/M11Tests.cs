using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class M11Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M11*3*z*6*4*6*t*4*1*Rb*1*B*M4*rs";

		var expected = new M11_ManifestBillOfLadingDetails()
		{
			BillOfLadingWaybillNumber = "3",
			LocationIdentifier = "z",
			Quantity = 6,
			ManifestUnitCode = "4",
			Weight = 6,
			WeightUnitQualifier = "t",
			Volume = 4,
			VolumeUnitQualifier = "1",
			BillOfLadingStatusCode = "Rb",
			PlaceOfReceiptByPreCarrier = "1",
			BillOfLadingWaybillNumber2 = "B",
			StandardCarrierAlphaCode = "M4",
			StandardCarrierAlphaCode2 = "rs",
		};

		var actual = Map.MapObject<M11_ManifestBillOfLadingDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.LocationIdentifier = "z";
		subject.Quantity = 6;
		subject.ManifestUnitCode = "4";
		subject.Weight = 6;
		subject.WeightUnitQualifier = "t";
		subject.StandardCarrierAlphaCode = "M4";
		//Test Parameters
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "3";
		subject.Quantity = 6;
		subject.ManifestUnitCode = "4";
		subject.Weight = 6;
		subject.WeightUnitQualifier = "t";
		subject.StandardCarrierAlphaCode = "M4";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "3";
		subject.LocationIdentifier = "z";
		subject.ManifestUnitCode = "4";
		subject.Weight = 6;
		subject.WeightUnitQualifier = "t";
		subject.StandardCarrierAlphaCode = "M4";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredManifestUnitCode(string manifestUnitCode, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "3";
		subject.LocationIdentifier = "z";
		subject.Quantity = 6;
		subject.Weight = 6;
		subject.WeightUnitQualifier = "t";
		subject.StandardCarrierAlphaCode = "M4";
		//Test Parameters
		subject.ManifestUnitCode = manifestUnitCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredWeight(decimal weight, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "3";
		subject.LocationIdentifier = "z";
		subject.Quantity = 6;
		subject.ManifestUnitCode = "4";
		subject.WeightUnitQualifier = "t";
		subject.StandardCarrierAlphaCode = "M4";
		//Test Parameters
		if (weight > 0) 
			subject.Weight = weight;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredWeightUnitQualifier(string weightUnitQualifier, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "3";
		subject.LocationIdentifier = "z";
		subject.Quantity = 6;
		subject.ManifestUnitCode = "4";
		subject.Weight = 6;
		subject.StandardCarrierAlphaCode = "M4";
		//Test Parameters
		subject.WeightUnitQualifier = weightUnitQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M4", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "3";
		subject.LocationIdentifier = "z";
		subject.Quantity = 6;
		subject.ManifestUnitCode = "4";
		subject.Weight = 6;
		subject.WeightUnitQualifier = "t";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
