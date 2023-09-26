using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class AT7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AT7*XP*u9*xo*46*7CxvpGfU*lgVp*hu";

		var expected = new AT7_ShipmentStatusDetails()
		{
			ShipmentStatusCode = "XP",
			ShipmentStatusOrAppointmentReasonCode = "u9",
			ShipmentAppointmentStatusCode = "xo",
			ShipmentStatusOrAppointmentReasonCode2 = "46",
			Date = "7CxvpGfU",
			Time = "lgVp",
			TimeCode = "hu",
		};

		var actual = Map.MapObject<AT7_ShipmentStatusDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("XP", "u9", true)]
	[InlineData("XP", "", false)]
	[InlineData("", "u9", false)]
	public void Validation_AllAreRequiredShipmentStatusCode(string shipmentStatusCode, string shipmentStatusOrAppointmentReasonCode, bool isValidExpected)
	{
		var subject = new AT7_ShipmentStatusDetails();
		//Required fields
		//Test Parameters
		subject.ShipmentStatusCode = shipmentStatusCode;
		subject.ShipmentStatusOrAppointmentReasonCode = shipmentStatusOrAppointmentReasonCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ShipmentAppointmentStatusCode) || !string.IsNullOrEmpty(subject.ShipmentAppointmentStatusCode) || !string.IsNullOrEmpty(subject.ShipmentStatusOrAppointmentReasonCode2))
		{
			subject.ShipmentAppointmentStatusCode = "xo";
			subject.ShipmentStatusOrAppointmentReasonCode2 = "46";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}



	[Theory]
	[InlineData("", "", true)]
	[InlineData("xo", "46", true)]
	[InlineData("xo", "", false)]
	[InlineData("", "46", false)]
	public void Validation_AllAreRequiredShipmentAppointmentStatusCode(string shipmentAppointmentStatusCode, string shipmentStatusOrAppointmentReasonCode2, bool isValidExpected)
	{
		var subject = new AT7_ShipmentStatusDetails();
		//Required fields
		//Test Parameters
		subject.ShipmentAppointmentStatusCode = shipmentAppointmentStatusCode;
		subject.ShipmentStatusOrAppointmentReasonCode2 = shipmentStatusOrAppointmentReasonCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ShipmentStatusCode) || !string.IsNullOrEmpty(subject.ShipmentStatusCode) || !string.IsNullOrEmpty(subject.ShipmentStatusOrAppointmentReasonCode))
		{
			subject.ShipmentStatusCode = "XP";
			subject.ShipmentStatusOrAppointmentReasonCode = "u9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("lgVp", "7CxvpGfU", true)]
	[InlineData("lgVp", "", false)]
	[InlineData("", "7CxvpGfU", true)]
	public void Validation_ARequiresBTime(string time, string date, bool isValidExpected)
	{
		var subject = new AT7_ShipmentStatusDetails();
		//Required fields
		//Test Parameters
		subject.Time = time;
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ShipmentStatusCode) || !string.IsNullOrEmpty(subject.ShipmentStatusCode) || !string.IsNullOrEmpty(subject.ShipmentStatusOrAppointmentReasonCode))
		{
			subject.ShipmentStatusCode = "XP";
			subject.ShipmentStatusOrAppointmentReasonCode = "u9";
		}
		if(!string.IsNullOrEmpty(subject.ShipmentAppointmentStatusCode) || !string.IsNullOrEmpty(subject.ShipmentAppointmentStatusCode) || !string.IsNullOrEmpty(subject.ShipmentStatusOrAppointmentReasonCode2))
		{
			subject.ShipmentAppointmentStatusCode = "xo";
			subject.ShipmentStatusOrAppointmentReasonCode2 = "46";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("hu", "lgVp", true)]
	[InlineData("hu", "", false)]
	[InlineData("", "lgVp", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new AT7_ShipmentStatusDetails();
		//Required fields
		//Test Parameters
		subject.TimeCode = timeCode;
		subject.Time = time;
		//A Requires B
		if (time != "")
			subject.Date = "7CxvpGfU";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ShipmentStatusCode) || !string.IsNullOrEmpty(subject.ShipmentStatusCode) || !string.IsNullOrEmpty(subject.ShipmentStatusOrAppointmentReasonCode))
		{
			subject.ShipmentStatusCode = "XP";
			subject.ShipmentStatusOrAppointmentReasonCode = "u9";
		}
		if(!string.IsNullOrEmpty(subject.ShipmentAppointmentStatusCode) || !string.IsNullOrEmpty(subject.ShipmentAppointmentStatusCode) || !string.IsNullOrEmpty(subject.ShipmentStatusOrAppointmentReasonCode2))
		{
			subject.ShipmentAppointmentStatusCode = "xo";
			subject.ShipmentStatusOrAppointmentReasonCode2 = "46";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
