using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class N8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N8*2*5gGqmV2I*H*M*Q*4*4NfESnXZ*ij*uC*vv*9";

		var expected = new N8_WaybillReference()
		{
			WaybillNumber = 2,
			Date = "5gGqmV2I",
			CrossReferenceTypeCode = "H",
			EquipmentInitial = "M",
			EquipmentNumber = "Q",
			WaybillNumber2 = 4,
			Date2 = "4NfESnXZ",
			CityName = "ij",
			StateOrProvinceCode = "uC",
			StandardCarrierAlphaCode = "vv",
			FreightStationAccountingCode = "9",
		};

		var actual = Map.MapObject<N8_WaybillReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredWaybillNumber(int waybillNumber, bool isValidExpected)
	{
		var subject = new N8_WaybillReference();
		subject.Date = "5gGqmV2I";
		if (waybillNumber > 0)
		subject.WaybillNumber = waybillNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5gGqmV2I", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new N8_WaybillReference();
		subject.WaybillNumber = 2;
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(4, "4NfESnXZ", true)]
	[InlineData(0, "4NfESnXZ", false)]
	[InlineData(4, "", false)]
	public void Validation_AllAreRequiredWaybillNumber2(int waybillNumber2, string date2, bool isValidExpected)
	{
		var subject = new N8_WaybillReference();
		subject.WaybillNumber = 2;
		subject.Date = "5gGqmV2I";
		if (waybillNumber2 > 0)
		subject.WaybillNumber2 = waybillNumber2;
		subject.Date2 = date2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("ij", "uC", true)]
	[InlineData("", "uC", false)]
	[InlineData("ij", "", false)]
	public void Validation_AllAreRequiredCityName(string cityName, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new N8_WaybillReference();
		subject.WaybillNumber = 2;
		subject.Date = "5gGqmV2I";
		subject.CityName = cityName;
		subject.StateOrProvinceCode = stateOrProvinceCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("vv", "9", true)]
	[InlineData("", "9", false)]
	[InlineData("vv", "", false)]
	public void Validation_AllAreRequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, string freightStationAccountingCode, bool isValidExpected)
	{
		var subject = new N8_WaybillReference();
		subject.WaybillNumber = 2;
		subject.Date = "5gGqmV2I";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		subject.FreightStationAccountingCode = freightStationAccountingCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
