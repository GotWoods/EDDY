using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class VADTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VAD*Z*O*3*9*rT*b*n*C*M*xpz*0ZNjIwFE";

		var expected = new VAD_VehicleAdviceDetail()
		{
			VehicleIdentificationNumber = "Z",
			InvoiceNumber = "O",
			MonetaryAmount = 3,
			Rate = 9,
			DealerCode = "rT",
			ReferenceIdentification = "b",
			ApplicationErrorConditionCode = "n",
			ApplicationErrorConditionCode2 = "C",
			ApplicationErrorConditionCode3 = "M",
			DateTimeQualifier = "xpz",
			Date = "0ZNjIwFE",
		};

		var actual = Map.MapObject<VAD_VehicleAdviceDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredVehicleIdentificationNumber(string vehicleIdentificationNumber, bool isValidExpected)
	{
		var subject = new VAD_VehicleAdviceDetail();
		//Required fields
		//Test Parameters
		subject.VehicleIdentificationNumber = vehicleIdentificationNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.DateTimeQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateTimeQualifier = "xpz";
			subject.Date = "0ZNjIwFE";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("xpz", "0ZNjIwFE", true)]
	[InlineData("xpz", "", false)]
	[InlineData("", "0ZNjIwFE", false)]
	public void Validation_AllAreRequiredDateTimeQualifier(string dateTimeQualifier, string date, bool isValidExpected)
	{
		var subject = new VAD_VehicleAdviceDetail();
		//Required fields
		subject.VehicleIdentificationNumber = "Z";
		//Test Parameters
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
