using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class CRCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CRC*6v*B*oM*up*CJ*kh*jZ";

		var expected = new CRC_CertificationConditions()
		{
			CodeCategory = "6v",
			YesNoConditionOrResponseCode = "B",
			CertificationConditionCode = "oM",
			CertificationConditionCode2 = "up",
			CertificationConditionCode3 = "CJ",
			CertificationConditionCode4 = "kh",
			CertificationConditionCode5 = "jZ",
		};

		var actual = Map.MapObject<CRC_CertificationConditions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6v", true)]
	public void Validation_RequiredCodeCategory(string codeCategory, bool isValidExpected)
	{
		var subject = new CRC_CertificationConditions();
		//Required fields
		subject.YesNoConditionOrResponseCode = "B";
		subject.CertificationConditionCode = "oM";
		//Test Parameters
		subject.CodeCategory = codeCategory;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new CRC_CertificationConditions();
		//Required fields
		subject.CodeCategory = "6v";
		subject.CertificationConditionCode = "oM";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oM", true)]
	public void Validation_RequiredCertificationConditionCode(string certificationConditionCode, bool isValidExpected)
	{
		var subject = new CRC_CertificationConditions();
		//Required fields
		subject.CodeCategory = "6v";
		subject.YesNoConditionOrResponseCode = "B";
		//Test Parameters
		subject.CertificationConditionCode = certificationConditionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
