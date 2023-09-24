using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BWTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BW*3J*L*P*E";

		var expected = new BW_BeginningSegmentForWeightMessageSet()
		{
			OriginEDICarrierCode = "3J",
			ShipmentIdentificationNumber = "L",
			WeightUnitQualifier = "P",
			ShipmentWeightCode = "E",
		};

		var actual = Map.MapObject<BW_BeginningSegmentForWeightMessageSet>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredWeightUnitQualifier(string weightUnitQualifier, bool isValidExpected)
	{
		var subject = new BW_BeginningSegmentForWeightMessageSet();
		subject.ShipmentWeightCode = "E";
		subject.WeightUnitQualifier = weightUnitQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredShipmentWeightCode(string shipmentWeightCode, bool isValidExpected)
	{
		var subject = new BW_BeginningSegmentForWeightMessageSet();
		subject.WeightUnitQualifier = "P";
		subject.ShipmentWeightCode = shipmentWeightCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
