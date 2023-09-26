using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class RU2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RU2*k*S*awYBzVqm*5g*t*C*LrIUT2Dg*W7AhsYju";

		var expected = new RU2_EmployingCarrierResponse()
		{
			RailRetirementActivityCode = "k",
			ReferenceIdentification = "S",
			Date = "awYBzVqm",
			EmploymentStatusCode = "5g",
			Amount = "t",
			FrequencyCode = "C",
			Date2 = "LrIUT2Dg",
			Date3 = "W7AhsYju",
		};

		var actual = Map.MapObject<RU2_EmployingCarrierResponse>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredRailRetirementActivityCode(string railRetirementActivityCode, bool isValidExpected)
	{
		var subject = new RU2_EmployingCarrierResponse();
		//Required fields
		subject.ReferenceIdentification = "S";
		//Test Parameters
		subject.RailRetirementActivityCode = railRetirementActivityCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.EmploymentStatusCode))
		{
			subject.Date = "awYBzVqm";
			subject.EmploymentStatusCode = "5g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new RU2_EmployingCarrierResponse();
		//Required fields
		subject.RailRetirementActivityCode = "k";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.EmploymentStatusCode))
		{
			subject.Date = "awYBzVqm";
			subject.EmploymentStatusCode = "5g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("awYBzVqm", "5g", true)]
	[InlineData("awYBzVqm", "", false)]
	[InlineData("", "5g", false)]
	public void Validation_AllAreRequiredDate(string date, string employmentStatusCode, bool isValidExpected)
	{
		var subject = new RU2_EmployingCarrierResponse();
		//Required fields
		subject.RailRetirementActivityCode = "k";
		subject.ReferenceIdentification = "S";
		//Test Parameters
		subject.Date = date;
		subject.EmploymentStatusCode = employmentStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
