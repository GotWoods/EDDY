using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class G4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G4*D5*GQ*1*ZEk2xNMw*nZdx*p";

		var expected = new G4_ScaleIdentification()
		{
			CityName = "D5",
			StateOrProvinceCode = "GQ",
			Name = "1",
			Date = "ZEk2xNMw",
			Time = "nZdx",
			ScaleTypeCode = "p",
		};

		var actual = Map.MapObject<G4_ScaleIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D5", true)]
	public void Validation_RequiredCityName(string cityName, bool isValidExpected)
	{
		var subject = new G4_ScaleIdentification();
		subject.StateOrProvinceCode = "GQ";
		subject.Date = "ZEk2xNMw";
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("GQ", true)]
	public void Validation_RequiredStateOrProvinceCode(string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new G4_ScaleIdentification();
		subject.CityName = "D5";
		subject.Date = "ZEk2xNMw";
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZEk2xNMw", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new G4_ScaleIdentification();
		subject.CityName = "D5";
		subject.StateOrProvinceCode = "GQ";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
