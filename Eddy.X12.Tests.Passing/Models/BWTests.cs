using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class BWTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BW*hs*z*H";

		var expected = new BW_BeginningSegmentForWeightMessageSet()
		{
			OriginEDICarrierCode = "hs",
			ShipmentIdentificationNumber = "z",
			WeightUnitCode = "H",
		};

		var actual = Map.MapObject<BW_BeginningSegmentForWeightMessageSet>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hs", true)]
	public void Validation_RequiredOriginEDICarrierCode(string originEDICarrierCode, bool isValidExpected)
	{
		var subject = new BW_BeginningSegmentForWeightMessageSet();
		subject.WeightUnitCode = "H";
		subject.OriginEDICarrierCode = originEDICarrierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredWeightUnitCode(string weightUnitCode, bool isValidExpected)
	{
		var subject = new BW_BeginningSegmentForWeightMessageSet();
		subject.OriginEDICarrierCode = "hs";
		subject.WeightUnitCode = weightUnitCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
