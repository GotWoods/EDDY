using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class BWTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BW*HK*a*t*3";

		var expected = new BW_BeginningSegmentForWeightMessageSet()
		{
			OriginEDICarrierCode = "HK",
			ShipmentIdentificationNumber = "a",
			WeightUnitQualifier = "t",
			ShipmentWeightCode = "3",
		};

		var actual = Map.MapObject<BW_BeginningSegmentForWeightMessageSet>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("HK", true)]
	public void Validation_RequiredOriginEDICarrierCode(string originEDICarrierCode, bool isValidExpected)
	{
		var subject = new BW_BeginningSegmentForWeightMessageSet();
		subject.WeightUnitQualifier = "t";
		subject.ShipmentWeightCode = "3";
		subject.OriginEDICarrierCode = originEDICarrierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredWeightUnitQualifier(string weightUnitQualifier, bool isValidExpected)
	{
		var subject = new BW_BeginningSegmentForWeightMessageSet();
		subject.OriginEDICarrierCode = "HK";
		subject.ShipmentWeightCode = "3";
		subject.WeightUnitQualifier = weightUnitQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredShipmentWeightCode(string shipmentWeightCode, bool isValidExpected)
	{
		var subject = new BW_BeginningSegmentForWeightMessageSet();
		subject.OriginEDICarrierCode = "HK";
		subject.WeightUnitQualifier = "t";
		subject.ShipmentWeightCode = shipmentWeightCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
