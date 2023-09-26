using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class AT7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AT7*mM*j9*iD*7O*z8flRg*47*hOKy*hd";

		var expected = new AT7_ShipmentStatusDetails()
		{
			ShipmentStatusCode = "mM",
			ShipmentStatusReasonCode = "j9",
			ShipmentAppointmentStatusCode = "iD",
			ShipmentAppointmentReasonCode = "7O",
			Date = "z8flRg",
			Century = 47,
			Time = "hOKy",
			TimeCode = "hd",
		};

		var actual = Map.MapObject<AT7_ShipmentStatusDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("mM", "j9", true)]
	[InlineData("mM", "", false)]
	[InlineData("", "j9", false)]
	public void Validation_AllAreRequiredShipmentStatusCode(string shipmentStatusCode, string shipmentStatusReasonCode, bool isValidExpected)
	{
		var subject = new AT7_ShipmentStatusDetails();
		//Required fields
		//Test Parameters
		subject.ShipmentStatusCode = shipmentStatusCode;
		subject.ShipmentStatusReasonCode = shipmentStatusReasonCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ShipmentAppointmentStatusCode) || !string.IsNullOrEmpty(subject.ShipmentAppointmentStatusCode) || !string.IsNullOrEmpty(subject.ShipmentAppointmentReasonCode))
		{
			subject.ShipmentAppointmentStatusCode = "iD";
			subject.ShipmentAppointmentReasonCode = "7O";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("iD", "7O", true)]
	[InlineData("iD", "", false)]
	[InlineData("", "7O", false)]
	public void Validation_AllAreRequiredShipmentAppointmentStatusCode(string shipmentAppointmentStatusCode, string shipmentAppointmentReasonCode, bool isValidExpected)
	{
		var subject = new AT7_ShipmentStatusDetails();
		//Required fields
		//Test Parameters
		subject.ShipmentAppointmentStatusCode = shipmentAppointmentStatusCode;
		subject.ShipmentAppointmentReasonCode = shipmentAppointmentReasonCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ShipmentStatusCode) || !string.IsNullOrEmpty(subject.ShipmentStatusCode) || !string.IsNullOrEmpty(subject.ShipmentStatusReasonCode))
		{
			subject.ShipmentStatusCode = "mM";
			subject.ShipmentStatusReasonCode = "j9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(47, "z8flRg", true)]
	[InlineData(47, "", false)]
	[InlineData(0, "z8flRg", true)]
	public void Validation_ARequiresBCentury(int century, string date, bool isValidExpected)
	{
		var subject = new AT7_ShipmentStatusDetails();
		//Required fields
		//Test Parameters
		if (century > 0) 
			subject.Century = century;
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ShipmentStatusCode) || !string.IsNullOrEmpty(subject.ShipmentStatusCode) || !string.IsNullOrEmpty(subject.ShipmentStatusReasonCode))
		{
			subject.ShipmentStatusCode = "mM";
			subject.ShipmentStatusReasonCode = "j9";
		}
		if(!string.IsNullOrEmpty(subject.ShipmentAppointmentStatusCode) || !string.IsNullOrEmpty(subject.ShipmentAppointmentStatusCode) || !string.IsNullOrEmpty(subject.ShipmentAppointmentReasonCode))
		{
			subject.ShipmentAppointmentStatusCode = "iD";
			subject.ShipmentAppointmentReasonCode = "7O";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("hOKy", "z8flRg", true)]
	[InlineData("hOKy", "", false)]
	[InlineData("", "z8flRg", true)]
	public void Validation_ARequiresBTime(string time, string date, bool isValidExpected)
	{
		var subject = new AT7_ShipmentStatusDetails();
		//Required fields
		//Test Parameters
		subject.Time = time;
		subject.Date = date;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ShipmentStatusCode) || !string.IsNullOrEmpty(subject.ShipmentStatusCode) || !string.IsNullOrEmpty(subject.ShipmentStatusReasonCode))
		{
			subject.ShipmentStatusCode = "mM";
			subject.ShipmentStatusReasonCode = "j9";
		}
		if(!string.IsNullOrEmpty(subject.ShipmentAppointmentStatusCode) || !string.IsNullOrEmpty(subject.ShipmentAppointmentStatusCode) || !string.IsNullOrEmpty(subject.ShipmentAppointmentReasonCode))
		{
			subject.ShipmentAppointmentStatusCode = "iD";
			subject.ShipmentAppointmentReasonCode = "7O";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("hd", "hOKy", true)]
	[InlineData("hd", "", false)]
	[InlineData("", "hOKy", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new AT7_ShipmentStatusDetails();
		//Required fields
		//Test Parameters
		subject.TimeCode = timeCode;
		subject.Time = time;
		//A Requires B
		if (time != "")
			subject.Date = "z8flRg";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ShipmentStatusCode) || !string.IsNullOrEmpty(subject.ShipmentStatusCode) || !string.IsNullOrEmpty(subject.ShipmentStatusReasonCode))
		{
			subject.ShipmentStatusCode = "mM";
			subject.ShipmentStatusReasonCode = "j9";
		}
		if(!string.IsNullOrEmpty(subject.ShipmentAppointmentStatusCode) || !string.IsNullOrEmpty(subject.ShipmentAppointmentStatusCode) || !string.IsNullOrEmpty(subject.ShipmentAppointmentReasonCode))
		{
			subject.ShipmentAppointmentStatusCode = "iD";
			subject.ShipmentAppointmentReasonCode = "7O";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
