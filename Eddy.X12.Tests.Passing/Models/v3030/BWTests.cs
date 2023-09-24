using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class BWTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BW*EQ*T*R*v";

		var expected = new BW_BeginningSegmentForWeightMessageSet()
		{
			OriginEDICarrierCode = "EQ",
			ShipmentIdentificationNumber = "T",
			WeightUnitCode = "R",
			ShipmentWeightCode = "v",
		};

		var actual = Map.MapObject<BW_BeginningSegmentForWeightMessageSet>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("EQ", true)]
	public void Validation_RequiredOriginEDICarrierCode(string originEDICarrierCode, bool isValidExpected)
	{
		var subject = new BW_BeginningSegmentForWeightMessageSet();
		subject.WeightUnitCode = "R";
		subject.ShipmentWeightCode = "v";
		subject.OriginEDICarrierCode = originEDICarrierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredWeightUnitCode(string weightUnitCode, bool isValidExpected)
	{
		var subject = new BW_BeginningSegmentForWeightMessageSet();
		subject.OriginEDICarrierCode = "EQ";
		subject.ShipmentWeightCode = "v";
		subject.WeightUnitCode = weightUnitCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredShipmentWeightCode(string shipmentWeightCode, bool isValidExpected)
	{
		var subject = new BW_BeginningSegmentForWeightMessageSet();
		subject.OriginEDICarrierCode = "EQ";
		subject.WeightUnitCode = "R";
		subject.ShipmentWeightCode = shipmentWeightCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
