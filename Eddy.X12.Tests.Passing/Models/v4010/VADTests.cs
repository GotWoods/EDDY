using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class VADTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VAD*8*5*5*5*0f*d*d*n*u*FYg*8mTTWO9b";

		var expected = new VAD_VehicleAdviceDetail()
		{
			VehicleIdentificationNumber = "8",
			InvoiceNumber = "5",
			MonetaryAmount = 5,
			Rate = 5,
			DealerCode = "0f",
			ReferenceIdentification = "d",
			ApplicationErrorConditionCode = "d",
			ApplicationErrorConditionCode2 = "n",
			ApplicationErrorConditionCode3 = "u",
			DateTimeQualifier = "FYg",
			Date = "8mTTWO9b",
		};

		var actual = Map.MapObject<VAD_VehicleAdviceDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredVehicleIdentificationNumber(string vehicleIdentificationNumber, bool isValidExpected)
	{
		var subject = new VAD_VehicleAdviceDetail();
		//Required fields
		//Test Parameters
		subject.VehicleIdentificationNumber = vehicleIdentificationNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateTimeQualifier = "FYg";
			subject.Date = "8mTTWO9b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("FYg", "8mTTWO9b", true)]
	[InlineData("FYg", "", false)]
	[InlineData("", "8mTTWO9b", false)]
	public void Validation_AllAreRequiredDateTimeQualifier(string dateTimeQualifier, string date, bool isValidExpected)
	{
		var subject = new VAD_VehicleAdviceDetail();
		//Required fields
		subject.VehicleIdentificationNumber = "8";
		//Test Parameters
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
