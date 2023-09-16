using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class N8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N8*4*aFYva0RO*D*s*l*5*Bbo56KkT*GI*Ke*mg*u";

		var expected = new N8_WaybillReference()
		{
			WaybillNumber = 4,
			Date = "aFYva0RO",
			CrossReferenceTypeCode = "D",
			EquipmentInitial = "s",
			EquipmentNumber = "l",
			WaybillNumber2 = 5,
			Date2 = "Bbo56KkT",
			CityName = "GI",
			StateOrProvinceCode = "Ke",
			StandardCarrierAlphaCode = "mg",
			FreightStationAccountingCode = "u",
		};

		var actual = Map.MapObject<N8_WaybillReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredWaybillNumber(int waybillNumber, bool isValidExpected)
	{
		var subject = new N8_WaybillReference();
		subject.Date = "aFYva0RO";
		if (waybillNumber > 0)
			subject.WaybillNumber = waybillNumber;
		//If one is filled, all are required
		if(subject.WaybillNumber2 > 0 || subject.WaybillNumber2 > 0 || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.WaybillNumber2 = 5;
			subject.Date2 = "Bbo56KkT";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "GI";
			subject.StateOrProvinceCode = "Ke";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode) || !string.IsNullOrEmpty(subject.FreightStationAccountingCode))
		{
			subject.StandardCarrierAlphaCode = "mg";
			subject.FreightStationAccountingCode = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("aFYva0RO", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new N8_WaybillReference();
		subject.WaybillNumber = 4;
		subject.Date = date;
		//If one is filled, all are required
		if(subject.WaybillNumber2 > 0 || subject.WaybillNumber2 > 0 || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.WaybillNumber2 = 5;
			subject.Date2 = "Bbo56KkT";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "GI";
			subject.StateOrProvinceCode = "Ke";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode) || !string.IsNullOrEmpty(subject.FreightStationAccountingCode))
		{
			subject.StandardCarrierAlphaCode = "mg";
			subject.FreightStationAccountingCode = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "Bbo56KkT", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "Bbo56KkT", false)]
	public void Validation_AllAreRequiredWaybillNumber2(int waybillNumber2, string date2, bool isValidExpected)
	{
		var subject = new N8_WaybillReference();
		subject.WaybillNumber = 4;
		subject.Date = "aFYva0RO";
		if (waybillNumber2 > 0)
			subject.WaybillNumber2 = waybillNumber2;
		subject.Date2 = date2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "GI";
			subject.StateOrProvinceCode = "Ke";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode) || !string.IsNullOrEmpty(subject.FreightStationAccountingCode))
		{
			subject.StandardCarrierAlphaCode = "mg";
			subject.FreightStationAccountingCode = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("GI", "Ke", true)]
	[InlineData("GI", "", false)]
	[InlineData("", "Ke", false)]
	public void Validation_AllAreRequiredCityName(string cityName, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new N8_WaybillReference();
		subject.WaybillNumber = 4;
		subject.Date = "aFYva0RO";
		subject.CityName = cityName;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		//If one is filled, all are required
		if(subject.WaybillNumber2 > 0 || subject.WaybillNumber2 > 0 || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.WaybillNumber2 = 5;
			subject.Date2 = "Bbo56KkT";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode) || !string.IsNullOrEmpty(subject.FreightStationAccountingCode))
		{
			subject.StandardCarrierAlphaCode = "mg";
			subject.FreightStationAccountingCode = "u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("mg", "u", true)]
	[InlineData("mg", "", false)]
	[InlineData("", "u", false)]
	public void Validation_AllAreRequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, string freightStationAccountingCode, bool isValidExpected)
	{
		var subject = new N8_WaybillReference();
		subject.WaybillNumber = 4;
		subject.Date = "aFYva0RO";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		subject.FreightStationAccountingCode = freightStationAccountingCode;
		//If one is filled, all are required
		if(subject.WaybillNumber2 > 0 || subject.WaybillNumber2 > 0 || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.WaybillNumber2 = 5;
			subject.Date2 = "Bbo56KkT";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "GI";
			subject.StateOrProvinceCode = "Ke";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
