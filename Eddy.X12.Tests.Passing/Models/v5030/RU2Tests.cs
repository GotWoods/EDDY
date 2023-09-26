using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class RU2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RU2*h*T*V9PT9Utm*nK*g*r*5qBKXHKF*oHwmroko";

		var expected = new RU2_EmployingCarrierResponse()
		{
			RailRetirementActivityCode = "h",
			ReferenceIdentification = "T",
			Date = "V9PT9Utm",
			EmploymentStatusCode = "nK",
			Amount = "g",
			FrequencyCode = "r",
			Date2 = "5qBKXHKF",
			Date3 = "oHwmroko",
		};

		var actual = Map.MapObject<RU2_EmployingCarrierResponse>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredRailRetirementActivityCode(string railRetirementActivityCode, bool isValidExpected)
	{
		var subject = new RU2_EmployingCarrierResponse();
		//Required fields
		subject.ReferenceIdentification = "T";
		//Test Parameters
		subject.RailRetirementActivityCode = railRetirementActivityCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.EmploymentStatusCode))
		{
			subject.Date = "V9PT9Utm";
			subject.EmploymentStatusCode = "nK";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new RU2_EmployingCarrierResponse();
		//Required fields
		subject.RailRetirementActivityCode = "h";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.EmploymentStatusCode))
		{
			subject.Date = "V9PT9Utm";
			subject.EmploymentStatusCode = "nK";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("V9PT9Utm", "nK", true)]
	[InlineData("V9PT9Utm", "", false)]
	[InlineData("", "nK", false)]
	public void Validation_AllAreRequiredDate(string date, string employmentStatusCode, bool isValidExpected)
	{
		var subject = new RU2_EmployingCarrierResponse();
		//Required fields
		subject.RailRetirementActivityCode = "h";
		subject.ReferenceIdentification = "T";
		//Test Parameters
		subject.Date = date;
		subject.EmploymentStatusCode = employmentStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
