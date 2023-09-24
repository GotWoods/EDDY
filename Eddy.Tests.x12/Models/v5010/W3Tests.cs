using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5010;

namespace Eddy.x12.Tests.Models.v5010;

public class W3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W3*6*02hMUGU4*aV*Ok*ke*w";

		var expected = new W3_ConsigneeInformation()
		{
			WaybillNumber = 6,
			Date = "02hMUGU4",
			AbbreviatedCustomerName = "aV",
			CityName = "Ok",
			StateOrProvinceCode = "ke",
			CityNameQualifierCode = "w",
		};

		var actual = Map.MapObject<W3_ConsigneeInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "02hMUGU4", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "02hMUGU4", false)]
	public void Validation_AllAreRequiredWaybillNumber(int waybillNumber, string date, bool isValidExpected)
	{
		var subject = new W3_ConsigneeInformation();
		//Required fields
		//Test Parameters
		if (waybillNumber > 0) 
			subject.WaybillNumber = waybillNumber;
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "Ok";
			subject.StateOrProvinceCode = "ke";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ok", "ke", true)]
	[InlineData("Ok", "", false)]
	[InlineData("", "ke", false)]
	public void Validation_AllAreRequiredCityName(string cityName, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new W3_ConsigneeInformation();
		//Required fields
		//Test Parameters
		subject.CityName = cityName;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		//If one filled, all required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 6;
			subject.Date = "02hMUGU4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("w", "Ok", true)]
	[InlineData("w", "", false)]
	[InlineData("", "Ok", true)]
	public void Validation_ARequiresBCityNameQualifierCode(string cityNameQualifierCode, string cityName, bool isValidExpected)
	{
		var subject = new W3_ConsigneeInformation();
		//Required fields
		//Test Parameters
		subject.CityNameQualifierCode = cityNameQualifierCode;
		subject.CityName = cityName;
		//If one filled, all required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 6;
			subject.Date = "02hMUGU4";
		}
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "Ok";
			subject.StateOrProvinceCode = "ke";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
