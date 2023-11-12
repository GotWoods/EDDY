using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class BOLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BOL*HR*0c*c*CbXKv939*vchA*U*q*p*mI*j7*ZI6";

		var expected = new BOL_BeginningSegmentForTheMotorCarrierBillOfLading()
		{
			StandardCarrierAlphaCode = "HR",
			ShipmentMethodOfPayment = "0c",
			ShipmentIdentificationNumber = "c",
			Date = "CbXKv939",
			Time = "vchA",
			ReferenceIdentification = "U",
			StatusReportRequestCode = "q",
			SectionSevenCode = "p",
			CustomsDocumentationHandlingCode = "mI",
			ShipmentMethodOfPayment2 = "j7",
			CurrencyCode = "ZI6",
		};

		var actual = Map.MapObject<BOL_BeginningSegmentForTheMotorCarrierBillOfLading>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("HR", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BOL_BeginningSegmentForTheMotorCarrierBillOfLading();
		//Required fields
		subject.ShipmentMethodOfPayment = "0c";
		subject.ShipmentIdentificationNumber = "c";
		subject.Date = "CbXKv939";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0c", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new BOL_BeginningSegmentForTheMotorCarrierBillOfLading();
		//Required fields
		subject.StandardCarrierAlphaCode = "HR";
		subject.ShipmentIdentificationNumber = "c";
		subject.Date = "CbXKv939";
		//Test Parameters
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredShipmentIdentificationNumber(string shipmentIdentificationNumber, bool isValidExpected)
	{
		var subject = new BOL_BeginningSegmentForTheMotorCarrierBillOfLading();
		//Required fields
		subject.StandardCarrierAlphaCode = "HR";
		subject.ShipmentMethodOfPayment = "0c";
		subject.Date = "CbXKv939";
		//Test Parameters
		subject.ShipmentIdentificationNumber = shipmentIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("CbXKv939", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BOL_BeginningSegmentForTheMotorCarrierBillOfLading();
		//Required fields
		subject.StandardCarrierAlphaCode = "HR";
		subject.ShipmentMethodOfPayment = "0c";
		subject.ShipmentIdentificationNumber = "c";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
