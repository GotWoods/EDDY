using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class D9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "D9*g*8c*Ln*nH*S*y2*tH*hxG8Km*xM5B";

		var expected = new D9_DestinationStation()
		{
			FreightStationAccountingCode = "g",
			DestinationStation = "8c",
			StateOrProvinceCode = "Ln",
			CountryCode = "nH",
			BilledAtStationCode = "S",
			CityName = "y2",
			StateOrProvinceCode2 = "tH",
			StandardPointLocationCode = "hxG8Km",
			PostalCode = "xM5B",
		};

		var actual = Map.MapObject<D9_DestinationStation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8c", true)]
	public void Validation_RequiredDestinationStation(string destinationStation, bool isValidExpected)
	{
		var subject = new D9_DestinationStation();
		subject.StateOrProvinceCode = "Ln";
		subject.DestinationStation = destinationStation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ln", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new D9_DestinationStation();
		subject.DestinationStation = "8c";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
