using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class AT7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AT7*i8*rU*fz*Eu*BcytykSK*smFJ*np";

		var expected = new AT7_ShipmentStatusDetails()
		{
			ShipmentStatusIndicatorCode = "i8",
			ShipmentStatusOrAppointmentReasonCode = "rU",
			ShipmentAppointmentStatusCode = "fz",
			ShipmentStatusOrAppointmentReasonCode2 = "Eu",
			Date = "BcytykSK",
			Time = "smFJ",
			TimeCode = "np",
		};

		var actual = Map.MapObject<AT7_ShipmentStatusDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("i8", "fz", false)]
	[InlineData("i8", "", true)]
	[InlineData("", "fz", true)]
	public void Validation_OnlyOneOfShipmentStatusIndicatorCode(string shipmentStatusIndicatorCode, string shipmentAppointmentStatusCode, bool isValidExpected)
	{
		var subject = new AT7_ShipmentStatusDetails();
		//Required fields
		//Test Parameters
		subject.ShipmentStatusIndicatorCode = shipmentStatusIndicatorCode;
		subject.ShipmentAppointmentStatusCode = shipmentAppointmentStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("rU", "i8", true)]
	[InlineData("rU", "", false)]
	[InlineData("", "i8", true)]
	public void Validation_ARequiresBShipmentStatusOrAppointmentReasonCode(string shipmentStatusOrAppointmentReasonCode, string shipmentStatusIndicatorCode, bool isValidExpected)
	{
		var subject = new AT7_ShipmentStatusDetails();
		//Required fields
		//Test Parameters
		subject.ShipmentStatusOrAppointmentReasonCode = shipmentStatusOrAppointmentReasonCode;
		subject.ShipmentStatusIndicatorCode = shipmentStatusIndicatorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Eu", "fz", true)]
	[InlineData("Eu", "", false)]
	[InlineData("", "fz", true)]
	public void Validation_ARequiresBShipmentStatusOrAppointmentReasonCode2(string shipmentStatusOrAppointmentReasonCode2, string shipmentAppointmentStatusCode, bool isValidExpected)
	{
		var subject = new AT7_ShipmentStatusDetails();
		//Required fields
		//Test Parameters
		subject.ShipmentStatusOrAppointmentReasonCode2 = shipmentStatusOrAppointmentReasonCode2;
		subject.ShipmentAppointmentStatusCode = shipmentAppointmentStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("smFJ", "BcytykSK", true)]
	[InlineData("smFJ", "", false)]
	[InlineData("", "BcytykSK", true)]
	public void Validation_ARequiresBTime(string time, string date, bool isValidExpected)
	{
		var subject = new AT7_ShipmentStatusDetails();
		//Required fields
		//Test Parameters
		subject.Time = time;
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("np", "smFJ", true)]
	[InlineData("np", "", false)]
	[InlineData("", "smFJ", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new AT7_ShipmentStatusDetails();
		//Required fields
		//Test Parameters
		subject.TimeCode = timeCode;
		subject.Time = time;
		//A Requires B
		if (time != "")
			subject.Date = "BcytykSK";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
