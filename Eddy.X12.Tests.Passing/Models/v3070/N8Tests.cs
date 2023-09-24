using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class N8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N8*7*Q16BJc*n*K*p*5*qtylFH*3j*5W*9f*0";

		var expected = new N8_WaybillReference()
		{
			WaybillNumber = 7,
			Date = "Q16BJc",
			CrossReferenceTypeCode = "n",
			EquipmentInitial = "K",
			EquipmentNumber = "p",
			WaybillNumber2 = 5,
			Date2 = "qtylFH",
			CityName = "3j",
			StateOrProvinceCode = "5W",
			StandardCarrierAlphaCode = "9f",
			FreightStationAccountingCode = "0",
		};

		var actual = Map.MapObject<N8_WaybillReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredWaybillNumber(int waybillNumber, bool isValidExpected)
	{
		var subject = new N8_WaybillReference();
		subject.Date = "Q16BJc";
		if (waybillNumber > 0)
			subject.WaybillNumber = waybillNumber;
		//If one is filled, all are required
		if(subject.WaybillNumber2 > 0 || subject.WaybillNumber2 > 0 || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.WaybillNumber2 = 5;
			subject.Date2 = "qtylFH";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "3j";
			subject.StateOrProvinceCode = "5W";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode) || !string.IsNullOrEmpty(subject.FreightStationAccountingCode))
		{
			subject.StandardCarrierAlphaCode = "9f";
			subject.FreightStationAccountingCode = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q16BJc", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new N8_WaybillReference();
		subject.WaybillNumber = 7;
		subject.Date = date;
		//If one is filled, all are required
		if(subject.WaybillNumber2 > 0 || subject.WaybillNumber2 > 0 || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.WaybillNumber2 = 5;
			subject.Date2 = "qtylFH";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "3j";
			subject.StateOrProvinceCode = "5W";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode) || !string.IsNullOrEmpty(subject.FreightStationAccountingCode))
		{
			subject.StandardCarrierAlphaCode = "9f";
			subject.FreightStationAccountingCode = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "qtylFH", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "qtylFH", false)]
	public void Validation_AllAreRequiredWaybillNumber2(int waybillNumber2, string date2, bool isValidExpected)
	{
		var subject = new N8_WaybillReference();
		subject.WaybillNumber = 7;
		subject.Date = "Q16BJc";
		if (waybillNumber2 > 0)
			subject.WaybillNumber2 = waybillNumber2;
		subject.Date2 = date2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "3j";
			subject.StateOrProvinceCode = "5W";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode) || !string.IsNullOrEmpty(subject.FreightStationAccountingCode))
		{
			subject.StandardCarrierAlphaCode = "9f";
			subject.FreightStationAccountingCode = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("3j", "5W", true)]
	[InlineData("3j", "", false)]
	[InlineData("", "5W", false)]
	public void Validation_AllAreRequiredCityName(string cityName, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new N8_WaybillReference();
		subject.WaybillNumber = 7;
		subject.Date = "Q16BJc";
		subject.CityName = cityName;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		//If one is filled, all are required
		if(subject.WaybillNumber2 > 0 || subject.WaybillNumber2 > 0 || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.WaybillNumber2 = 5;
			subject.Date2 = "qtylFH";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode) || !string.IsNullOrEmpty(subject.FreightStationAccountingCode))
		{
			subject.StandardCarrierAlphaCode = "9f";
			subject.FreightStationAccountingCode = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("9f", "0", true)]
	[InlineData("9f", "", false)]
	[InlineData("", "0", false)]
	public void Validation_AllAreRequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, string freightStationAccountingCode, bool isValidExpected)
	{
		var subject = new N8_WaybillReference();
		subject.WaybillNumber = 7;
		subject.Date = "Q16BJc";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		subject.FreightStationAccountingCode = freightStationAccountingCode;
		//If one is filled, all are required
		if(subject.WaybillNumber2 > 0 || subject.WaybillNumber2 > 0 || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.WaybillNumber2 = 5;
			subject.Date2 = "qtylFH";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "3j";
			subject.StateOrProvinceCode = "5W";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
