using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.Tests.Models.v4060;

public class AT7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AT7*4R*Qr*p1*mK*jBlNGAV3*sNIJ*Lc";

		var expected = new AT7_ShipmentStatusDetails()
		{
			ShipmentStatusIndicator = "4R",
			ShipmentStatusOrAppointmentReasonCode = "Qr",
			ShipmentAppointmentStatusCode = "p1",
			ShipmentStatusOrAppointmentReasonCode2 = "mK",
			Date = "jBlNGAV3",
			Time = "sNIJ",
			TimeCode = "Lc",
		};

		var actual = Map.MapObject<AT7_ShipmentStatusDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("4R", "p1", false)]
	[InlineData("4R", "", true)]
	[InlineData("", "p1", true)]
	public void Validation_OnlyOneOfShipmentStatusIndicator(string shipmentStatusIndicator, string shipmentAppointmentStatusCode, bool isValidExpected)
	{
		var subject = new AT7_ShipmentStatusDetails();
		//Required fields
		//Test Parameters
		subject.ShipmentStatusIndicator = shipmentStatusIndicator;
		subject.ShipmentAppointmentStatusCode = shipmentAppointmentStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Qr", "4R", true)]
	[InlineData("Qr", "", false)]
	[InlineData("", "4R", true)]
	public void Validation_ARequiresBShipmentStatusOrAppointmentReasonCode(string shipmentStatusOrAppointmentReasonCode, string shipmentStatusIndicator, bool isValidExpected)
	{
		var subject = new AT7_ShipmentStatusDetails();
		//Required fields
		//Test Parameters
		subject.ShipmentStatusOrAppointmentReasonCode = shipmentStatusOrAppointmentReasonCode;
		subject.ShipmentStatusIndicator = shipmentStatusIndicator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("mK", "p1", true)]
	[InlineData("mK", "", false)]
	[InlineData("", "p1", true)]
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
	[InlineData("sNIJ", "jBlNGAV3", true)]
	[InlineData("sNIJ", "", false)]
	[InlineData("", "jBlNGAV3", true)]
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
	[InlineData("Lc", "sNIJ", true)]
	[InlineData("Lc", "", false)]
	[InlineData("", "sNIJ", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new AT7_ShipmentStatusDetails();
		//Required fields
		//Test Parameters
		subject.TimeCode = timeCode;
		subject.Time = time;
		//A Requires B
		if (time != "")
			subject.Date = "jBlNGAV3";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
