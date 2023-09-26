using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class BOLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BOL*kw*3Q*j*Q6YQFc*ncdT*q*h*e*g2*D0*6u1";

		var expected = new BOL_BeginningSegmentForTheMotorCarrierBillOfLading()
		{
			StandardCarrierAlphaCode = "kw",
			ShipmentMethodOfPayment = "3Q",
			ShipmentIdentificationNumber = "j",
			Date = "Q6YQFc",
			Time = "ncdT",
			ReferenceIdentification = "q",
			StatusReportRequestCode = "h",
			SectionSevenCode = "e",
			CustomsDocumentationHandlingCode = "g2",
			ShipmentMethodOfPayment2 = "D0",
			CurrencyCode = "6u1",
		};

		var actual = Map.MapObject<BOL_BeginningSegmentForTheMotorCarrierBillOfLading>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kw", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BOL_BeginningSegmentForTheMotorCarrierBillOfLading();
		//Required fields
		subject.ShipmentMethodOfPayment = "3Q";
		subject.ShipmentIdentificationNumber = "j";
		subject.Date = "Q6YQFc";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3Q", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new BOL_BeginningSegmentForTheMotorCarrierBillOfLading();
		//Required fields
		subject.StandardCarrierAlphaCode = "kw";
		subject.ShipmentIdentificationNumber = "j";
		subject.Date = "Q6YQFc";
		//Test Parameters
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredShipmentIdentificationNumber(string shipmentIdentificationNumber, bool isValidExpected)
	{
		var subject = new BOL_BeginningSegmentForTheMotorCarrierBillOfLading();
		//Required fields
		subject.StandardCarrierAlphaCode = "kw";
		subject.ShipmentMethodOfPayment = "3Q";
		subject.Date = "Q6YQFc";
		//Test Parameters
		subject.ShipmentIdentificationNumber = shipmentIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q6YQFc", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BOL_BeginningSegmentForTheMotorCarrierBillOfLading();
		//Required fields
		subject.StandardCarrierAlphaCode = "kw";
		subject.ShipmentMethodOfPayment = "3Q";
		subject.ShipmentIdentificationNumber = "j";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
