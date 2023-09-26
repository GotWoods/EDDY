using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class BOLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BOL*e0*6w*U*tZQamO3T*01Ap*I*8*g*Fd*zC*f0i";

		var expected = new BOL_BeginningSegmentForTheMotorCarrierBillOfLading()
		{
			StandardCarrierAlphaCode = "e0",
			ShipmentMethodOfPayment = "6w",
			ShipmentIdentificationNumber = "U",
			Date = "tZQamO3T",
			Time = "01Ap",
			ReferenceIdentification = "I",
			StatusReportRequestCode = "8",
			SectionSevenCode = "g",
			CustomsDocumentationHandlingCode = "Fd",
			ShipmentMethodOfPayment2 = "zC",
			CurrencyCode = "f0i",
		};

		var actual = Map.MapObject<BOL_BeginningSegmentForTheMotorCarrierBillOfLading>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e0", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BOL_BeginningSegmentForTheMotorCarrierBillOfLading();
		//Required fields
		subject.ShipmentMethodOfPayment = "6w";
		subject.ShipmentIdentificationNumber = "U";
		subject.Date = "tZQamO3T";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6w", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new BOL_BeginningSegmentForTheMotorCarrierBillOfLading();
		//Required fields
		subject.StandardCarrierAlphaCode = "e0";
		subject.ShipmentIdentificationNumber = "U";
		subject.Date = "tZQamO3T";
		//Test Parameters
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredShipmentIdentificationNumber(string shipmentIdentificationNumber, bool isValidExpected)
	{
		var subject = new BOL_BeginningSegmentForTheMotorCarrierBillOfLading();
		//Required fields
		subject.StandardCarrierAlphaCode = "e0";
		subject.ShipmentMethodOfPayment = "6w";
		subject.Date = "tZQamO3T";
		//Test Parameters
		subject.ShipmentIdentificationNumber = shipmentIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tZQamO3T", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BOL_BeginningSegmentForTheMotorCarrierBillOfLading();
		//Required fields
		subject.StandardCarrierAlphaCode = "e0";
		subject.ShipmentMethodOfPayment = "6w";
		subject.ShipmentIdentificationNumber = "U";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
