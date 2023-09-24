using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class N8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N8*8*yzhvOA5X*0*c*l*8*bPiVeNhC*Xj*HC*l2*2";

		var expected = new N8_WaybillReference()
		{
			WaybillNumber = 8,
			Date = "yzhvOA5X",
			CrossReferenceTypeCode = "0",
			EquipmentInitial = "c",
			EquipmentNumber = "l",
			WaybillNumber2 = 8,
			Date2 = "bPiVeNhC",
			CityName = "Xj",
			StateOrProvinceCode = "HC",
			StandardCarrierAlphaCode = "l2",
			FreightStationAccountingCode = "2",
		};

		var actual = Map.MapObject<N8_WaybillReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredWaybillNumber(int waybillNumber, bool isValidExpected)
	{
		var subject = new N8_WaybillReference();
		subject.Date = "yzhvOA5X";
		if (waybillNumber > 0)
			subject.WaybillNumber = waybillNumber;
		//If one is filled, all are required
		if(subject.WaybillNumber2 > 0 || subject.WaybillNumber2 > 0 || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.WaybillNumber2 = 8;
			subject.Date2 = "bPiVeNhC";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "Xj";
			subject.StateOrProvinceCode = "HC";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode) || !string.IsNullOrEmpty(subject.FreightStationAccountingCode))
		{
			subject.StandardCarrierAlphaCode = "l2";
			subject.FreightStationAccountingCode = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yzhvOA5X", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new N8_WaybillReference();
		subject.WaybillNumber = 8;
		subject.Date = date;
		//If one is filled, all are required
		if(subject.WaybillNumber2 > 0 || subject.WaybillNumber2 > 0 || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.WaybillNumber2 = 8;
			subject.Date2 = "bPiVeNhC";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "Xj";
			subject.StateOrProvinceCode = "HC";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode) || !string.IsNullOrEmpty(subject.FreightStationAccountingCode))
		{
			subject.StandardCarrierAlphaCode = "l2";
			subject.FreightStationAccountingCode = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "bPiVeNhC", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "bPiVeNhC", false)]
	public void Validation_AllAreRequiredWaybillNumber2(int waybillNumber2, string date2, bool isValidExpected)
	{
		var subject = new N8_WaybillReference();
		subject.WaybillNumber = 8;
		subject.Date = "yzhvOA5X";
		if (waybillNumber2 > 0)
			subject.WaybillNumber2 = waybillNumber2;
		subject.Date2 = date2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "Xj";
			subject.StateOrProvinceCode = "HC";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode) || !string.IsNullOrEmpty(subject.FreightStationAccountingCode))
		{
			subject.StandardCarrierAlphaCode = "l2";
			subject.FreightStationAccountingCode = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Xj", "HC", true)]
	[InlineData("Xj", "", false)]
	[InlineData("", "HC", false)]
	public void Validation_AllAreRequiredCityName(string cityName, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new N8_WaybillReference();
		subject.WaybillNumber = 8;
		subject.Date = "yzhvOA5X";
		subject.CityName = cityName;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		//If one is filled, all are required
		if(subject.WaybillNumber2 > 0 || subject.WaybillNumber2 > 0 || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.WaybillNumber2 = 8;
			subject.Date2 = "bPiVeNhC";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode) || !string.IsNullOrEmpty(subject.FreightStationAccountingCode))
		{
			subject.StandardCarrierAlphaCode = "l2";
			subject.FreightStationAccountingCode = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("l2", "2", true)]
	[InlineData("l2", "", false)]
	[InlineData("", "2", false)]
	public void Validation_AllAreRequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, string freightStationAccountingCode, bool isValidExpected)
	{
		var subject = new N8_WaybillReference();
		subject.WaybillNumber = 8;
		subject.Date = "yzhvOA5X";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		subject.FreightStationAccountingCode = freightStationAccountingCode;
		//If one is filled, all are required
		if(subject.WaybillNumber2 > 0 || subject.WaybillNumber2 > 0 || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.WaybillNumber2 = 8;
			subject.Date2 = "bPiVeNhC";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "Xj";
			subject.StateOrProvinceCode = "HC";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
