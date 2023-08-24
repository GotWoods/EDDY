using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class D9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "D9*x*b6*Qx*fk*T*UW*IM*26OKpf*4XUR";

		var expected = new D9_DestinationStation()
		{
			FreightStationAccountingCode = "x",
			DestinationStation = "b6",
			StateOrProvinceCode = "Qx",
			CountryCode = "fk",
			BilledAtStationCode = "T",
			CityName = "UW",
			StateOrProvinceCode2 = "IM",
			StandardPointLocationCode = "26OKpf",
			PostalCode = "4XUR",
		};

		var actual = Map.MapObject<D9_DestinationStation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b6", true)]
	public void Validation_RequiredDestinationStation(string destinationStation, bool isValidExpected)
	{
		var subject = new D9_DestinationStation();
		subject.StateOrProvinceCode = "Qx";
		subject.DestinationStation = destinationStation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Qx", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new D9_DestinationStation();
		subject.DestinationStation = "b6";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
