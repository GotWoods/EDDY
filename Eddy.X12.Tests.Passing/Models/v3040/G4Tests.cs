using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class G4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G4*r1*7D*es*TqmDLf*r1AN*A";

		var expected = new G4_ScaleIdentification()
		{
			CityName = "r1",
			StateOrProvinceCode = "7D",
			Name30CharacterFormat = "es",
			Date = "TqmDLf",
			Time = "r1AN",
			ScaleTypeCode = "A",
		};

		var actual = Map.MapObject<G4_ScaleIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r1", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new G4_ScaleIdentification();
		subject.StateOrProvinceCode = "7D";
		subject.Date = "TqmDLf";
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7D", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new G4_ScaleIdentification();
		subject.CityName = "r1";
		subject.Date = "TqmDLf";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("TqmDLf", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new G4_ScaleIdentification();
		subject.CityName = "r1";
		subject.StateOrProvinceCode = "7D";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
