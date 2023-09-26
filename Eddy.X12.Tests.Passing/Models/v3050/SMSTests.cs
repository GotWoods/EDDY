using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class SMSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SMS*Cd*e*jvkwcw*g*FkK*1*XY*P*V";

		var expected = new SMS_StationCodesSegment()
		{
			StandardCarrierAlphaCode = "Cd",
			FreightStationAccountingCode = "e",
			Date = "jvkwcw",
			Rule260JunctionCode = "g",
			PostalCode = "FkK",
			ReciprocalSwitchCode = "1",
			TimeCode = "XY",
			LocationIdentifier = "P",
			LocationIdentifier2 = "V",
		};

		var actual = Map.MapObject<SMS_StationCodesSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Cd", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new SMS_StationCodesSegment();
		//Required fields
		subject.FreightStationAccountingCode = "e";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredFreightStationAccountingCode(string freightStationAccountingCode, bool isValidExpected)
	{
		var subject = new SMS_StationCodesSegment();
		//Required fields
		subject.StandardCarrierAlphaCode = "Cd";
		//Test Parameters
		subject.FreightStationAccountingCode = freightStationAccountingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
