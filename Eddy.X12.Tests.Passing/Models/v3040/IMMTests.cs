using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class IMMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IMM*1jX*Fo*U*L*Q7";

		var expected = new IMM_ImmunizationStatusCode()
		{
			ImmunizationTypeCode = "1jX",
			DateTimePeriodFormatQualifier = "Fo",
			DateTimePeriod = "U",
			ImmunizationStatusCode = "L",
			ReportTypeCode = "Q7",
		};

		var actual = Map.MapObject<IMM_ImmunizationStatusCode>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1jX", true)]
	public void Validation_RequiredImmunizationTypeCode(string immunizationTypeCode, bool isValidExpected)
	{
		var subject = new IMM_ImmunizationStatusCode();
		//Required fields
		//Test Parameters
		subject.ImmunizationTypeCode = immunizationTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "Fo";
			subject.DateTimePeriod = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Fo", "U", true)]
	[InlineData("Fo", "", false)]
	[InlineData("", "U", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new IMM_ImmunizationStatusCode();
		//Required fields
		subject.ImmunizationTypeCode = "1jX";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		//A Requires B
		if (dateTimePeriod != "")
			subject.ImmunizationStatusCode = "L";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("U", "L", true)]
	[InlineData("U", "", false)]
	[InlineData("", "L", true)]
	public void Validation_ARequiresBDateTimePeriod(string dateTimePeriod, string immunizationStatusCode, bool isValidExpected)
	{
		var subject = new IMM_ImmunizationStatusCode();
		//Required fields
		subject.ImmunizationTypeCode = "1jX";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		subject.ImmunizationStatusCode = immunizationStatusCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "Fo";
			subject.DateTimePeriod = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
