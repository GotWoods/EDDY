using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class RU2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RU2*R*4*vPAmg2zH*Oq*7*q*Z66cgK6V*5cgfgXl0";

		var expected = new RU2_EmployingCarrierResponse()
		{
			RailRetirementActivityCode = "R",
			ReferenceIdentification = "4",
			Date = "vPAmg2zH",
			EmploymentStatusCode = "Oq",
			Amount = "7",
			FrequencyCode = "q",
			Date2 = "Z66cgK6V",
			Date3 = "5cgfgXl0",
		};

		var actual = Map.MapObject<RU2_EmployingCarrierResponse>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredRailRetirementActivityCode(string railRetirementActivityCode, bool isValidExpected)
	{
		var subject = new RU2_EmployingCarrierResponse();
		subject.ReferenceIdentification = "4";
		subject.RailRetirementActivityCode = railRetirementActivityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new RU2_EmployingCarrierResponse();
		subject.RailRetirementActivityCode = "R";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("vPAmg2zH", "Oq", true)]
	[InlineData("", "Oq", false)]
	[InlineData("vPAmg2zH", "", false)]
	public void Validation_AllAreRequiredDate(string date, string employmentStatusCode, bool isValidExpected)
	{
		var subject = new RU2_EmployingCarrierResponse();
		subject.RailRetirementActivityCode = "R";
		subject.ReferenceIdentification = "4";
		subject.Date = date;
		subject.EmploymentStatusCode = employmentStatusCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
