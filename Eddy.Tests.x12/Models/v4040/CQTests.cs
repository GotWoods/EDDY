using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class CQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CQ*a*Q*s*vp*wr*v*B*U*zk*pd";

		var expected = new CQ_CredentialsAndQualifications()
		{
			CredentialTypeCode = "a",
			CredentialCategoryCode = "Q",
			IdentificationCodeQualifier = "s",
			IdentificationCode = "vp",
			LevelOfIndividualTestOrCourseCode = "wr",
			BasisForAcademicCreditOrAwardOfCredentialCode = "v",
			CredentialIssuanceOrRenewalRequirementCode = "B",
			YesNoConditionOrResponseCode = "U",
			ConditionIndicator = "zk",
			StateOrProvinceCode = "pd",
		};

		var actual = Map.MapObject<CQ_CredentialsAndQualifications>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredCredentialTypeCode(string credentialTypeCode, bool isValidExpected)
	{
		var subject = new CQ_CredentialsAndQualifications();
		//Required fields
		//Test Parameters
		subject.CredentialTypeCode = credentialTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "s";
			subject.IdentificationCode = "vp";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("s", "vp", true)]
	[InlineData("s", "", false)]
	[InlineData("", "vp", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new CQ_CredentialsAndQualifications();
		//Required fields
		subject.CredentialTypeCode = "a";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
