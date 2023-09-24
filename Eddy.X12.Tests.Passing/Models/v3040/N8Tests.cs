using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class N8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N8*8*B8K4pP*b*b*z*4*2b51Ld*4A*PK*x0*9";

		var expected = new N8_WaybillReference()
		{
			WaybillNumber = 8,
			Date = "B8K4pP",
			CrossReferenceTypeCode = "b",
			EquipmentInitial = "b",
			EquipmentNumber = "z",
			WaybillNumber2 = 4,
			Date2 = "2b51Ld",
			CityName = "4A",
			StateOrProvinceCode = "PK",
			StandardCarrierAlphaCode = "x0",
			FreightStationAccountingCode = "9",
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
		subject.Date = "B8K4pP";
		if (waybillNumber > 0)
			subject.WaybillNumber = waybillNumber;
		//If one is filled, all are required
		if(subject.WaybillNumber2 > 0 || subject.WaybillNumber2 > 0 || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.WaybillNumber2 = 4;
			subject.Date2 = "2b51Ld";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "4A";
			subject.StateOrProvinceCode = "PK";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B8K4pP", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new N8_WaybillReference();
		subject.WaybillNumber = 8;
		subject.Date = date;
		//If one is filled, all are required
		if(subject.WaybillNumber2 > 0 || subject.WaybillNumber2 > 0 || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.WaybillNumber2 = 4;
			subject.Date2 = "2b51Ld";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "4A";
			subject.StateOrProvinceCode = "PK";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "2b51Ld", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "2b51Ld", false)]
	public void Validation_AllAreRequiredWaybillNumber2(int waybillNumber2, string date2, bool isValidExpected)
	{
		var subject = new N8_WaybillReference();
		subject.WaybillNumber = 8;
		subject.Date = "B8K4pP";
		if (waybillNumber2 > 0)
			subject.WaybillNumber2 = waybillNumber2;
		subject.Date2 = date2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "4A";
			subject.StateOrProvinceCode = "PK";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("4A", "PK", true)]
	[InlineData("4A", "", false)]
	[InlineData("", "PK", false)]
	public void Validation_AllAreRequiredCityName(string cityName, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new N8_WaybillReference();
		subject.WaybillNumber = 8;
		subject.Date = "B8K4pP";
		subject.CityName = cityName;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		//If one is filled, all are required
		if(subject.WaybillNumber2 > 0 || subject.WaybillNumber2 > 0 || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.WaybillNumber2 = 4;
			subject.Date2 = "2b51Ld";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
