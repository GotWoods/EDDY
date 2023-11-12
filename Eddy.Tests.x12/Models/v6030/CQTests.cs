using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class CQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CQ*X*V*6*d0*8N*v*x*8*x0*HD";

		var expected = new CQ_CredentialsAndQualifications()
		{
			CredentialTypeCode = "X",
			CredentialCategoryCode = "V",
			IdentificationCodeQualifier = "6",
			IdentificationCode = "d0",
			LevelOfIndividualTestOrCourseCode = "8N",
			BasisForAcademicCreditOrAwardOfCredentialCode = "v",
			CredentialRequirementCode = "x",
			YesNoConditionOrResponseCode = "8",
			ConditionIndicatorCode = "x0",
			StateOrProvinceCode = "HD",
		};

		var actual = Map.MapObject<CQ_CredentialsAndQualifications>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredCredentialTypeCode(string credentialTypeCode, bool isValidExpected)
	{
		var subject = new CQ_CredentialsAndQualifications();
		//Required fields
		//Test Parameters
		subject.CredentialTypeCode = credentialTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "6";
			subject.IdentificationCode = "d0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("6", "d0", true)]
	[InlineData("6", "", false)]
	[InlineData("", "d0", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new CQ_CredentialsAndQualifications();
		//Required fields
		subject.CredentialTypeCode = "X";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
