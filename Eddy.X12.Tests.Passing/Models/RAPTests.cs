using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class RAPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RAP*B*P*1*W*w*OA*i";

		var expected = new RAP_RequirementAttributeAndProficiency()
		{
			EducationalTestOrRequirementCode = "B",
			Name = "P",
			Name2 = "1",
			UsageIndicatorCode = "W",
			YesNoConditionOrResponseCode = "w",
			DateTimePeriodFormatQualifier = "OA",
			DateTimePeriod = "i",
		};

		var actual = Map.MapObject<RAP_RequirementAttributeAndProficiency>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredEducationalTestOrRequirementCode(string educationalTestOrRequirementCode, bool isValidExpected)
	{
		var subject = new RAP_RequirementAttributeAndProficiency();
		subject.EducationalTestOrRequirementCode = educationalTestOrRequirementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("OA", "i", true)]
	[InlineData("", "i", false)]
	[InlineData("OA", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new RAP_RequirementAttributeAndProficiency();
		subject.EducationalTestOrRequirementCode = "B";
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
