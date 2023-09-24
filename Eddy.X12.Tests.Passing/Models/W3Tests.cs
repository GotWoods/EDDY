using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class W3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W3*1*Uct8D8zr*xc*Gu*TT*1";

		var expected = new W3_ConsigneeInformation()
		{
			WaybillNumber = 1,
			Date = "Uct8D8zr",
			AbbreviatedCustomerName = "xc",
			CityName = "Gu",
			StateOrProvinceCode = "TT",
			CityNameQualifierCode = "1",
		};

		var actual = Map.MapObject<W3_ConsigneeInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(1, "Uct8D8zr", true)]
	[InlineData(0, "Uct8D8zr", false)]
	[InlineData(1, "", false)]
	public void Validation_AllAreRequiredWaybillNumber(int waybillNumber, string date, bool isValidExpected)
	{
		var subject = new W3_ConsigneeInformation();
		if (waybillNumber > 0)
		subject.WaybillNumber = waybillNumber;
		subject.Date = date;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Gu", "TT", true)]
	[InlineData("", "TT", false)]
	[InlineData("Gu", "", false)]
	public void Validation_AllAreRequiredCityName(string cityName, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new W3_ConsigneeInformation();
		subject.CityName = cityName;
		subject.StateOrProvinceCode = stateOrProvinceCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "Gu", true)]
	[InlineData("1", "", false)]
	public void Validation_ARequiresBCityNameQualifierCode(string cityNameQualifierCode, string cityName, bool isValidExpected)
	{
		var subject = new W3_ConsigneeInformation();
		subject.CityNameQualifierCode = cityNameQualifierCode;
		subject.CityName = cityName;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
