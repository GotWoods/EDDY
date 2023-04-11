using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G4*wZ*Lb*C*4NQkwGHo*1gwX*L";

		var expected = new G4_ScaleIdentification()
		{
			CityName = "wZ",
			StateOrProvinceCode = "Lb",
			Name = "C",
			Date = "4NQkwGHo",
			Time = "1gwX",
			ScaleTypeCode = "L",
		};

		var actual = Map.MapObject<G4_ScaleIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wZ", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new G4_ScaleIdentification();
		subject.StateOrProvinceCode = "Lb";
		subject.Date = "4NQkwGHo";
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Lb", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new G4_ScaleIdentification();
		subject.CityName = "wZ";
		subject.Date = "4NQkwGHo";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4NQkwGHo", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new G4_ScaleIdentification();
		subject.CityName = "wZ";
		subject.StateOrProvinceCode = "Lb";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
