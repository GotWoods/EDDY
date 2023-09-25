using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class RU2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RU2*4*f*y4SBBG40*En*B*a*29pZzeJd*D6zNHX4U";

		var expected = new RU2_EmployingCarrierResponse()
		{
			RailRetirementActivityCode = "4",
			ReferenceIdentification = "f",
			Date = "y4SBBG40",
			EmploymentStatusCode = "En",
			Amount = "B",
			FrequencyCode = "a",
			Date2 = "29pZzeJd",
			Date3 = "D6zNHX4U",
		};

		var actual = Map.MapObject<RU2_EmployingCarrierResponse>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredRailRetirementActivityCode(string railRetirementActivityCode, bool isValidExpected)
	{
		var subject = new RU2_EmployingCarrierResponse();
		//Required fields
		subject.ReferenceIdentification = "f";
		//Test Parameters
		subject.RailRetirementActivityCode = railRetirementActivityCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.EmploymentStatusCode))
		{
			subject.Date = "y4SBBG40";
			subject.EmploymentStatusCode = "En";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new RU2_EmployingCarrierResponse();
		//Required fields
		subject.RailRetirementActivityCode = "4";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.EmploymentStatusCode))
		{
			subject.Date = "y4SBBG40";
			subject.EmploymentStatusCode = "En";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("y4SBBG40", "En", true)]
	[InlineData("y4SBBG40", "", false)]
	[InlineData("", "En", false)]
	public void Validation_AllAreRequiredDate(string date, string employmentStatusCode, bool isValidExpected)
	{
		var subject = new RU2_EmployingCarrierResponse();
		//Required fields
		subject.RailRetirementActivityCode = "4";
		subject.ReferenceIdentification = "f";
		//Test Parameters
		subject.Date = date;
		subject.EmploymentStatusCode = employmentStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
