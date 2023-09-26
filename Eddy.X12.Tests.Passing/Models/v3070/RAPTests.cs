using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class RAPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RAP*d*4*k*J*6*dI*N";

		var expected = new RAP_RequirementAttributeAndProficiency()
		{
			EducationalTestOrRequirementCode = "d",
			Name = "4",
			Name2 = "k",
			UsageIndicator = "J",
			YesNoConditionOrResponseCode = "6",
			DateTimePeriodFormatQualifier = "dI",
			DateTimePeriod = "N",
		};

		var actual = Map.MapObject<RAP_RequirementAttributeAndProficiency>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredEducationalTestOrRequirementCode(string educationalTestOrRequirementCode, bool isValidExpected)
	{
		var subject = new RAP_RequirementAttributeAndProficiency();
		//Required fields
		//Test Parameters
		subject.EducationalTestOrRequirementCode = educationalTestOrRequirementCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "dI";
			subject.DateTimePeriod = "N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("dI", "N", true)]
	[InlineData("dI", "", false)]
	[InlineData("", "N", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new RAP_RequirementAttributeAndProficiency();
		//Required fields
		subject.EducationalTestOrRequirementCode = "d";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
