using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class EDFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EDF*S*H*D*Y*x*F*GU*rT*1*8*1";

		var expected = new EDF_EducationalFeeInformation()
		{
			CodeListQualifierCode = "S",
			IndustryCode = "H",
			InstitutionalGovernanceOrFundingSourceLevelCode = "D",
			CodeListQualifierCode2 = "Y",
			IndustryCode2 = "x",
			Description = "F",
			LevelOfIndividualTestOrCourseCode = "GU",
			IdentificationCode = "rT",
			Quantity = 1,
			Quantity2 = 8,
			MonetaryAmount = 1,
		};

		var actual = Map.MapObject<EDF_EducationalFeeInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredCodeListQualifierCode(string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new EDF_EducationalFeeInformation();
		//Required fields
		subject.IndustryCode = "H";
		//Test Parameters
		subject.CodeListQualifierCode = codeListQualifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CodeListQualifierCode2) || !string.IsNullOrEmpty(subject.CodeListQualifierCode2) || !string.IsNullOrEmpty(subject.IndustryCode2))
		{
			subject.CodeListQualifierCode2 = "Y";
			subject.IndustryCode2 = "x";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredIndustryCode(string industryCode, bool isValidExpected)
	{
		var subject = new EDF_EducationalFeeInformation();
		//Required fields
		subject.CodeListQualifierCode = "S";
		//Test Parameters
		subject.IndustryCode = industryCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CodeListQualifierCode2) || !string.IsNullOrEmpty(subject.CodeListQualifierCode2) || !string.IsNullOrEmpty(subject.IndustryCode2))
		{
			subject.CodeListQualifierCode2 = "Y";
			subject.IndustryCode2 = "x";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Y", "x", true)]
	[InlineData("Y", "", false)]
	[InlineData("", "x", false)]
	public void Validation_AllAreRequiredCodeListQualifierCode2(string codeListQualifierCode2, string industryCode2, bool isValidExpected)
	{
		var subject = new EDF_EducationalFeeInformation();
		//Required fields
		subject.CodeListQualifierCode = "S";
		subject.IndustryCode = "H";
		//Test Parameters
		subject.CodeListQualifierCode2 = codeListQualifierCode2;
		subject.IndustryCode2 = industryCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("F", "Y", true)]
	[InlineData("F", "", false)]
	[InlineData("", "Y", true)]
	public void Validation_ARequiresBDescription(string description, string codeListQualifierCode2, bool isValidExpected)
	{
		var subject = new EDF_EducationalFeeInformation();
		//Required fields
		subject.CodeListQualifierCode = "S";
		subject.IndustryCode = "H";
		//Test Parameters
		subject.Description = description;
		subject.CodeListQualifierCode2 = codeListQualifierCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CodeListQualifierCode2) || !string.IsNullOrEmpty(subject.CodeListQualifierCode2) || !string.IsNullOrEmpty(subject.IndustryCode2))
		{
			subject.CodeListQualifierCode2 = "Y";
			subject.IndustryCode2 = "x";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
