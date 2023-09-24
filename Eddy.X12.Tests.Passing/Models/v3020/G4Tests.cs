using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class G4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G4*Bp*td*7x*4nBVR4*ABPz*L";

		var expected = new G4_ScaleIdentificationSegment()
		{
			CityName = "Bp",
			StateOrProvinceCode = "td",
			Name30CharacterFormat = "7x",
			Date = "4nBVR4",
			Time = "ABPz",
			ScaleTypeCode = "L",
		};

		var actual = Map.MapObject<G4_ScaleIdentificationSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Bp", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new G4_ScaleIdentificationSegment();
		subject.StateOrProvinceCode = "td";
		subject.Date = "4nBVR4";
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("td", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new G4_ScaleIdentificationSegment();
		subject.CityName = "Bp";
		subject.Date = "4nBVR4";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4nBVR4", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new G4_ScaleIdentificationSegment();
		subject.CityName = "Bp";
		subject.StateOrProvinceCode = "td";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
