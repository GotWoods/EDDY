using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class Q5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Q5*x*1I3Ssa*Oorr*wo*t1o*nk*mW*uB*q*s";

		var expected = new Q5_StatusDetails()
		{
			StatusCode = "x",
			StatusDate = "1I3Ssa",
			StatusTime = "Oorr",
			TimeCode = "wo",
			StatusReasonCode = "t1o",
			CityName = "nk",
			StateOrProvinceCode = "mW",
			CountryCode = "uB",
			EquipmentInitial = "q",
			EquipmentNumber = "s",
		};

		var actual = Map.MapObject<Q5_StatusDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("nk", "mW", true)]
	[InlineData("nk", "", false)]
	[InlineData("", "mW", false)]
	public void Validation_AllAreRequiredCityName(string cityName, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new Q5_StatusDetails();
		subject.CityName = cityName;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
