using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class BOLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BOL*CS*cb*L*W3dek2XN*Jmgx*g*J*s*Ar*T3*EEv";

		var expected = new BOL_BeginningSegmentForTheMotorCarrierBillOfLading()
		{
			StandardCarrierAlphaCode = "CS",
			ShipmentMethodOfPaymentCode = "cb",
			ShipmentIdentificationNumber = "L",
			Date = "W3dek2XN",
			Time = "Jmgx",
			ReferenceIdentification = "g",
			StatusReportRequestCode = "J",
			SectionSevenCode = "s",
			CustomsDocumentationHandlingCode = "Ar",
			ShipmentMethodOfPaymentCode2 = "T3",
			CurrencyCode = "EEv",
		};

		var actual = Map.MapObject<BOL_BeginningSegmentForTheMotorCarrierBillOfLading>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("CS", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BOL_BeginningSegmentForTheMotorCarrierBillOfLading();
		//Required fields
		subject.ShipmentMethodOfPaymentCode = "cb";
		subject.ShipmentIdentificationNumber = "L";
		subject.Date = "W3dek2XN";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cb", true)]
	public void Validation_RequiredShipmentMethodOfPaymentCode(string shipmentMethodOfPaymentCode, bool isValidExpected)
	{
		var subject = new BOL_BeginningSegmentForTheMotorCarrierBillOfLading();
		//Required fields
		subject.StandardCarrierAlphaCode = "CS";
		subject.ShipmentIdentificationNumber = "L";
		subject.Date = "W3dek2XN";
		//Test Parameters
		subject.ShipmentMethodOfPaymentCode = shipmentMethodOfPaymentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredShipmentIdentificationNumber(string shipmentIdentificationNumber, bool isValidExpected)
	{
		var subject = new BOL_BeginningSegmentForTheMotorCarrierBillOfLading();
		//Required fields
		subject.StandardCarrierAlphaCode = "CS";
		subject.ShipmentMethodOfPaymentCode = "cb";
		subject.Date = "W3dek2XN";
		//Test Parameters
		subject.ShipmentIdentificationNumber = shipmentIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W3dek2XN", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BOL_BeginningSegmentForTheMotorCarrierBillOfLading();
		//Required fields
		subject.StandardCarrierAlphaCode = "CS";
		subject.ShipmentMethodOfPaymentCode = "cb";
		subject.ShipmentIdentificationNumber = "L";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
