using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G4*Wg*A4*4y*BQ418F*vnvh*9";

		var expected = new G4_ScaleIdentificationSegment()
		{
			CityName = "Wg",
			StateOrProvinceCode = "A4",
			Name30CharacterFormat = "4y",
			EventDate = "BQ418F",
			EventTime = "vnvh",
			ScaleTypeCode = "9",
		};

		var actual = Map.MapObject<G4_ScaleIdentificationSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Wg", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new G4_ScaleIdentificationSegment();
		subject.StateOrProvinceCode = "A4";
		subject.EventDate = "BQ418F";
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A4", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new G4_ScaleIdentificationSegment();
		subject.CityName = "Wg";
		subject.EventDate = "BQ418F";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("BQ418F", true)]
	public void Validation_RequiredEventDate(string eventDate, bool isValidExpected)
	{
		var subject = new G4_ScaleIdentificationSegment();
		subject.CityName = "Wg";
		subject.StateOrProvinceCode = "A4";
		subject.EventDate = eventDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
