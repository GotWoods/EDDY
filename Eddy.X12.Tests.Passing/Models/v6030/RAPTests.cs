using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class RAPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RAP*a*e*4*0*h*nA*T";

		var expected = new RAP_RequirementAttributeAndProficiency()
		{
			EducationalTestOrRequirementCode = "a",
			Name = "e",
			Name2 = "4",
			UsageIndicatorCode = "0",
			YesNoConditionOrResponseCode = "h",
			DateTimePeriodFormatQualifier = "nA",
			DateTimePeriod = "T",
		};

		var actual = Map.MapObject<RAP_RequirementAttributeAndProficiency>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredEducationalTestOrRequirementCode(string educationalTestOrRequirementCode, bool isValidExpected)
	{
		var subject = new RAP_RequirementAttributeAndProficiency();
		//Required fields
		//Test Parameters
		subject.EducationalTestOrRequirementCode = educationalTestOrRequirementCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "nA";
			subject.DateTimePeriod = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("nA", "T", true)]
	[InlineData("nA", "", false)]
	[InlineData("", "T", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new RAP_RequirementAttributeAndProficiency();
		//Required fields
		subject.EducationalTestOrRequirementCode = "a";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
