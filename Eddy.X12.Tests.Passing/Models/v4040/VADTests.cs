using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class VADTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VAD*P*b*1*5*8Z*r*H*S*w*AzC*84eBDQBA";

		var expected = new VAD_VehicleAdviceDetail()
		{
			VehicleIdentificationNumber = "P",
			InvoiceNumber = "b",
			MonetaryAmount = 1,
			Rate = 5,
			DealerCode = "8Z",
			ReferenceIdentification = "r",
			ApplicationErrorConditionCode = "H",
			ApplicationErrorConditionCode2 = "S",
			ApplicationErrorConditionCode3 = "w",
			DateTimeQualifier = "AzC",
			Date = "84eBDQBA",
		};

		var actual = Map.MapObject<VAD_VehicleAdviceDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredVehicleIdentificationNumber(string vehicleIdentificationNumber, bool isValidExpected)
	{
		var subject = new VAD_VehicleAdviceDetail();
		//Required fields
		//Test Parameters
		subject.VehicleIdentificationNumber = vehicleIdentificationNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateTimeQualifier = "AzC";
			subject.Date = "84eBDQBA";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("AzC", "84eBDQBA", true)]
	[InlineData("AzC", "", false)]
	[InlineData("", "84eBDQBA", false)]
	public void Validation_AllAreRequiredDateTimeQualifier(string dateTimeQualifier, string date, bool isValidExpected)
	{
		var subject = new VAD_VehicleAdviceDetail();
		//Required fields
		subject.VehicleIdentificationNumber = "P";
		//Test Parameters
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
