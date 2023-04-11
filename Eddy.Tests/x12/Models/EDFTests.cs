using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class EDFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EDF*p*6*t*E*7*C*gN*dP*1*3*3";

		var expected = new EDF_EducationalFeeInformation()
		{
			CodeListQualifierCode = "p",
			IndustryCode = "6",
			InstitutionalGovernanceOrFundingSourceLevelCode = "t",
			CodeListQualifierCode2 = "E",
			IndustryCode2 = "7",
			Description = "C",
			LevelOfIndividualTestOrCourseCode = "gN",
			IdentificationCode = "dP",
			Quantity = 1,
			Quantity2 = 3,
			MonetaryAmount = 3,
		};

		var actual = Map.MapObject<EDF_EducationalFeeInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredCodeListQualifierCode(string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new EDF_EducationalFeeInformation();
		subject.IndustryCode = "6";
		subject.CodeListQualifierCode = codeListQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredIndustryCode(string industryCode, bool isValidExpected)
	{
		var subject = new EDF_EducationalFeeInformation();
		subject.CodeListQualifierCode = "p";
		subject.IndustryCode = industryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("E", "7", true)]
	[InlineData("", "7", false)]
	[InlineData("E", "", false)]
	public void Validation_AllAreRequiredCodeListQualifierCode2(string codeListQualifierCode2, string industryCode2, bool isValidExpected)
	{
		var subject = new EDF_EducationalFeeInformation();
		subject.CodeListQualifierCode = "p";
		subject.IndustryCode = "6";
		subject.CodeListQualifierCode2 = codeListQualifierCode2;
		subject.IndustryCode2 = industryCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "E", true)]
	[InlineData("C", "", false)]
	public void Validation_ARequiresBDescription(string description, string codeListQualifierCode2, bool isValidExpected)
	{
		var subject = new EDF_EducationalFeeInformation();
		subject.CodeListQualifierCode = "p";
		subject.IndustryCode = "6";
		subject.Description = description;
		subject.CodeListQualifierCode2 = codeListQualifierCode2;

		if (codeListQualifierCode2 != "")
			subject.IndustryCode2 = "6";

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
