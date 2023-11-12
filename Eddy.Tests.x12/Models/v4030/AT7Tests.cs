using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class AT7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AT7*i1*MP*tj*kp*cMwoTpi8*2W01*Cv";

		var expected = new AT7_ShipmentStatusDetails()
		{
			ShipmentStatusCode = "i1",
			ShipmentStatusOrAppointmentReasonCode = "MP",
			ShipmentAppointmentStatusCode = "tj",
			ShipmentStatusOrAppointmentReasonCode2 = "kp",
			Date = "cMwoTpi8",
			Time = "2W01",
			TimeCode = "Cv",
		};

		var actual = Map.MapObject<AT7_ShipmentStatusDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("i1", "tj", false)]
	[InlineData("i1", "", true)]
	[InlineData("", "tj", true)]
	public void Validation_OnlyOneOfShipmentStatusCode(string shipmentStatusCode, string shipmentAppointmentStatusCode, bool isValidExpected)
	{
		var subject = new AT7_ShipmentStatusDetails();
		//Required fields
		//Test Parameters
		subject.ShipmentStatusCode = shipmentStatusCode;
		subject.ShipmentAppointmentStatusCode = shipmentAppointmentStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("MP", "i1", true)]
	[InlineData("MP", "", false)]
	[InlineData("", "i1", true)]
	public void Validation_ARequiresBShipmentStatusOrAppointmentReasonCode(string shipmentStatusOrAppointmentReasonCode, string shipmentStatusCode, bool isValidExpected)
	{
		var subject = new AT7_ShipmentStatusDetails();
		//Required fields
		//Test Parameters
		subject.ShipmentStatusOrAppointmentReasonCode = shipmentStatusOrAppointmentReasonCode;
		subject.ShipmentStatusCode = shipmentStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("kp", "tj", true)]
	[InlineData("kp", "", false)]
	[InlineData("", "tj", true)]
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
	[InlineData("2W01", "cMwoTpi8", true)]
	[InlineData("2W01", "", false)]
	[InlineData("", "cMwoTpi8", true)]
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
	[InlineData("Cv", "2W01", true)]
	[InlineData("Cv", "", false)]
	[InlineData("", "2W01", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new AT7_ShipmentStatusDetails();
		//Required fields
		//Test Parameters
		subject.TimeCode = timeCode;
		subject.Time = time;
		//A Requires B
		if (time != "")
			subject.Date = "cMwoTpi8";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
