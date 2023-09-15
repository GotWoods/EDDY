using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class D9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "D9*Q*bD*qo*Dt*U*U8*hc*wJMByR*OeS";

		var expected = new D9_DestinationStation()
		{
			FreightStationAccountingCode = "Q",
			DestinationStation = "bD",
			StateOrProvinceCode = "qo",
			CountryCode = "Dt",
			FreightStationAccountingCode2 = "U",
			CityName = "U8",
			StateOrProvinceCode2 = "hc",
			StandardPointLocationCode = "wJMByR",
			PostalCode = "OeS",
		};

		var actual = Map.MapObject<D9_DestinationStation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bD", true)]
	public void Validation_RequiredDestinationStation(string destinationStation, bool isValidExpected)
	{
		var subject = new D9_DestinationStation();
		subject.StateOrProvinceCode = "qo";
		subject.DestinationStation = destinationStation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qo", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new D9_DestinationStation();
		subject.DestinationStation = "bD";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
