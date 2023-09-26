using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class VADTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VAD*B*7*4*5*Cm*S*w*A*q*aEK*PYAm4aNK";

		var expected = new VAD_VehicleAdviceDetail()
		{
			VehicleIdentificationNumber = "B",
			InvoiceNumber = "7",
			MonetaryAmount = 4,
			Rate = 5,
			DealerCode = "Cm",
			ReferenceIdentification = "S",
			ApplicationErrorConditionCode = "w",
			ApplicationErrorConditionCode2 = "A",
			ApplicationErrorConditionCode3 = "q",
			DateTimeQualifier = "aEK",
			Date = "PYAm4aNK",
		};

		var actual = Map.MapObject<VAD_VehicleAdviceDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredVehicleIdentificationNumber(string vehicleIdentificationNumber, bool isValidExpected)
	{
		var subject = new VAD_VehicleAdviceDetail();
		//Required fields
		//Test Parameters
		subject.VehicleIdentificationNumber = vehicleIdentificationNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateTimeQualifier = "aEK";
			subject.Date = "PYAm4aNK";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("aEK", "PYAm4aNK", true)]
	[InlineData("aEK", "", false)]
	[InlineData("", "PYAm4aNK", false)]
	public void Validation_AllAreRequiredDateTimeQualifier(string dateTimeQualifier, string date, bool isValidExpected)
	{
		var subject = new VAD_VehicleAdviceDetail();
		//Required fields
		subject.VehicleIdentificationNumber = "B";
		//Test Parameters
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
