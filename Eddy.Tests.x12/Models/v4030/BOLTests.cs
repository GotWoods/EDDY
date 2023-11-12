using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class BOLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BOL*ta*my*r*UuLYyV42*n5p3*5*n*r*B2*U2*fFL";

		var expected = new BOL_BeginningSegmentForTheMotorCarrierBillOfLading()
		{
			StandardCarrierAlphaCode = "ta",
			ShipmentMethodOfPayment = "my",
			ShipmentIdentificationNumber = "r",
			Date = "UuLYyV42",
			Time = "n5p3",
			ReferenceIdentification = "5",
			StatusReportRequestCode = "n",
			SectionSevenCode = "r",
			CustomsDocumentationHandlingCode = "B2",
			ShipmentMethodOfPayment2 = "U2",
			CurrencyCode = "fFL",
		};

		var actual = Map.MapObject<BOL_BeginningSegmentForTheMotorCarrierBillOfLading>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ta", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BOL_BeginningSegmentForTheMotorCarrierBillOfLading();
		//Required fields
		subject.ShipmentMethodOfPayment = "my";
		subject.ShipmentIdentificationNumber = "r";
		subject.Date = "UuLYyV42";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("my", true)]
	public void Validation_RequiredShipmentMethodOfPayment(string shipmentMethodOfPayment, bool isValidExpected)
	{
		var subject = new BOL_BeginningSegmentForTheMotorCarrierBillOfLading();
		//Required fields
		subject.StandardCarrierAlphaCode = "ta";
		subject.ShipmentIdentificationNumber = "r";
		subject.Date = "UuLYyV42";
		//Test Parameters
		subject.ShipmentMethodOfPayment = shipmentMethodOfPayment;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredShipmentIdentificationNumber(string shipmentIdentificationNumber, bool isValidExpected)
	{
		var subject = new BOL_BeginningSegmentForTheMotorCarrierBillOfLading();
		//Required fields
		subject.StandardCarrierAlphaCode = "ta";
		subject.ShipmentMethodOfPayment = "my";
		subject.Date = "UuLYyV42";
		//Test Parameters
		subject.ShipmentIdentificationNumber = shipmentIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("UuLYyV42", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BOL_BeginningSegmentForTheMotorCarrierBillOfLading();
		//Required fields
		subject.StandardCarrierAlphaCode = "ta";
		subject.ShipmentMethodOfPayment = "my";
		subject.ShipmentIdentificationNumber = "r";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
