using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SCTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SCT*l*8*l*nI*T*g*T*3*7*s*d";

		var expected = new SCT_SchoolType()
		{
			AcademicCreditTypeCode = "l",
			Quantity = 8,
			SessionCode = "l",
			DateTimePeriodFormatQualifier = "nI",
			DateTimePeriod = "T",
			YesNoConditionOrResponseCode = "g",
			InstitutionalGovernanceOrFundingSourceLevelCode = "T",
			CodeListQualifierCode = "3",
			IndustryCode = "7",
			YesNoConditionOrResponseCode2 = "s",
			YesNoConditionOrResponseCode3 = "d",
		};

		var actual = Map.MapObject<SCT_SchoolType>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("nI", "T", true)]
	[InlineData("", "T", false)]
	[InlineData("nI", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new SCT_SchoolType();
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("3", "7", true)]
	[InlineData("", "7", false)]
	[InlineData("3", "", false)]
	public void Validation_AllAreRequiredCodeListQualifierCode(string codeListQualifierCode, string industryCode, bool isValidExpected)
	{
		var subject = new SCT_SchoolType();
		subject.CodeListQualifierCode = codeListQualifierCode;
		subject.IndustryCode = industryCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
