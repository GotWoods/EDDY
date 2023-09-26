using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class RU2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RU2*b*L*Za1hAV*Tw*j*Q*wI989o*jVHPFj";

		var expected = new RU2_EmployingCarrierResponse()
		{
			RailRetirementActivityCode = "b",
			ReferenceNumber = "L",
			Date = "Za1hAV",
			EmploymentStatusCode = "Tw",
			Amount = "j",
			FrequencyCode = "Q",
			Date2 = "wI989o",
			Date3 = "jVHPFj",
		};

		var actual = Map.MapObject<RU2_EmployingCarrierResponse>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredRailRetirementActivityCode(string railRetirementActivityCode, bool isValidExpected)
	{
		var subject = new RU2_EmployingCarrierResponse();
		//Required fields
		subject.ReferenceNumber = "L";
		//Test Parameters
		subject.RailRetirementActivityCode = railRetirementActivityCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.EmploymentStatusCode))
		{
			subject.Date = "Za1hAV";
			subject.EmploymentStatusCode = "Tw";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new RU2_EmployingCarrierResponse();
		//Required fields
		subject.RailRetirementActivityCode = "b";
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.EmploymentStatusCode))
		{
			subject.Date = "Za1hAV";
			subject.EmploymentStatusCode = "Tw";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Za1hAV", "Tw", true)]
	[InlineData("Za1hAV", "", false)]
	[InlineData("", "Tw", false)]
	public void Validation_AllAreRequiredDate(string date, string employmentStatusCode, bool isValidExpected)
	{
		var subject = new RU2_EmployingCarrierResponse();
		//Required fields
		subject.RailRetirementActivityCode = "b";
		subject.ReferenceNumber = "L";
		//Test Parameters
		subject.Date = date;
		subject.EmploymentStatusCode = employmentStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
