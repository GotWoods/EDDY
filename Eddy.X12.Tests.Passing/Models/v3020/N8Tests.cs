using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class N8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N8*8*sdXxYw*M*z*h*2*xjTATZ*qg*JA*Bi*h";

		var expected = new N8_WaybillReference()
		{
			WaybillNumber = 8,
			Date = "sdXxYw",
			CrossReferenceTypeCode = "M",
			EquipmentInitial = "z",
			EquipmentNumber = "h",
			WaybillNumber2 = 2,
			Date2 = "xjTATZ",
			DestinationStation = "qg",
			StateOrProvinceCode = "JA",
			StandardCarrierAlphaCode = "Bi",
			FreightStationAccountingCode = "h",
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
		subject.Date = "sdXxYw";
		if (waybillNumber > 0)
			subject.WaybillNumber = waybillNumber;
		//If one is filled, all are required
		if(subject.WaybillNumber2 > 0 || subject.WaybillNumber2 > 0 || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.WaybillNumber2 = 2;
			subject.Date2 = "xjTATZ";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DestinationStation) || !string.IsNullOrEmpty(subject.DestinationStation) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.DestinationStation = "qg";
			subject.StateOrProvinceCode = "JA";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("sdXxYw", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new N8_WaybillReference();
		subject.WaybillNumber = 8;
		subject.Date = date;
		//If one is filled, all are required
		if(subject.WaybillNumber2 > 0 || subject.WaybillNumber2 > 0 || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.WaybillNumber2 = 2;
			subject.Date2 = "xjTATZ";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DestinationStation) || !string.IsNullOrEmpty(subject.DestinationStation) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.DestinationStation = "qg";
			subject.StateOrProvinceCode = "JA";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "xjTATZ", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "xjTATZ", false)]
	public void Validation_AllAreRequiredWaybillNumber2(int waybillNumber2, string date2, bool isValidExpected)
	{
		var subject = new N8_WaybillReference();
		subject.WaybillNumber = 8;
		subject.Date = "sdXxYw";
		if (waybillNumber2 > 0)
			subject.WaybillNumber2 = waybillNumber2;
		subject.Date2 = date2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.DestinationStation) || !string.IsNullOrEmpty(subject.DestinationStation) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.DestinationStation = "qg";
			subject.StateOrProvinceCode = "JA";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("qg", "JA", true)]
	[InlineData("qg", "", false)]
	[InlineData("", "JA", false)]
	public void Validation_AllAreRequiredDestinationStation(string destinationStation, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new N8_WaybillReference();
		subject.WaybillNumber = 8;
		subject.Date = "sdXxYw";
		subject.DestinationStation = destinationStation;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		//If one is filled, all are required
		if(subject.WaybillNumber2 > 0 || subject.WaybillNumber2 > 0 || !string.IsNullOrEmpty(subject.Date2))
		{
			subject.WaybillNumber2 = 2;
			subject.Date2 = "xjTATZ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
