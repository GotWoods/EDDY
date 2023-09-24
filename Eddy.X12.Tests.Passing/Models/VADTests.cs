using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class VADTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VAD*S*q*3*7*ml*B*o*N*i*uH8*axQnYf3C";

		var expected = new VAD_VehicleAdviceDetail()
		{
			VehicleIdentificationNumber = "S",
			InvoiceNumber = "q",
			MonetaryAmount = 3,
			Rate = 7,
			DealerCode = "ml",
			ReferenceIdentification = "B",
			ApplicationErrorConditionCode = "o",
			ApplicationErrorConditionCode2 = "N",
			ApplicationErrorConditionCode3 = "i",
			DateTimeQualifier = "uH8",
			Date = "axQnYf3C",
		};

		var actual = Map.MapObject<VAD_VehicleAdviceDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredVehicleIdentificationNumber(string vehicleIdentificationNumber, bool isValidExpected)
	{
		var subject = new VAD_VehicleAdviceDetail();
		subject.VehicleIdentificationNumber = vehicleIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("uH8", "axQnYf3C", true)]
	[InlineData("", "axQnYf3C", false)]
	[InlineData("uH8", "", false)]
	public void Validation_AllAreRequiredDateTimeQualifier(string dateTimeQualifier, string date, bool isValidExpected)
	{
		var subject = new VAD_VehicleAdviceDetail();
		subject.VehicleIdentificationNumber = "S";
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.Date = date;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
