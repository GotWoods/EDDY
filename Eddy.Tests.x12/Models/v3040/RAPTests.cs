using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class RAPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RAP*X*i*W*n*K*Ga*C";

		var expected = new RAP_RequirementAttributeAndProficiency()
		{
			StudentTestCode = "X",
			Name = "i",
			Name2 = "W",
			UsageIndicator = "n",
			YesNoConditionOrResponseCode = "K",
			DateTimePeriodFormatQualifier = "Ga",
			DateTimePeriod = "C",
		};

		var actual = Map.MapObject<RAP_RequirementAttributeAndProficiency>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredStudentTestCode(string studentTestCode, bool isValidExpected)
	{
		var subject = new RAP_RequirementAttributeAndProficiency();
		//Required fields
		//Test Parameters
		subject.StudentTestCode = studentTestCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "Ga";
			subject.DateTimePeriod = "C";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ga", "C", true)]
	[InlineData("Ga", "", false)]
	[InlineData("", "C", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new RAP_RequirementAttributeAndProficiency();
		//Required fields
		subject.StudentTestCode = "X";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
