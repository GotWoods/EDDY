using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class G4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G4*r2*Ut*Lj*zib8Du*7Hn4*v";

		var expected = new G4_ScaleIdentification()
		{
			CityName = "r2",
			StateOrProvinceCode = "Ut",
			Name30CharacterFormat = "Lj",
			Date = "zib8Du",
			Time = "7Hn4",
			ScaleTypeCode = "v",
		};

		var actual = Map.MapObject<G4_ScaleIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r2", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new G4_ScaleIdentification();
		subject.StateOrProvinceCode = "Ut";
		subject.Date = "zib8Du";
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ut", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new G4_ScaleIdentification();
		subject.CityName = "r2";
		subject.Date = "zib8Du";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zib8Du", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new G4_ScaleIdentification();
		subject.CityName = "r2";
		subject.StateOrProvinceCode = "Ut";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
