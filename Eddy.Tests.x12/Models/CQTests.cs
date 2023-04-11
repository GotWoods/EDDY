using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class CQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CQ*q*8*y*eU*Pz*v*Z*1*mV*mj";

		var expected = new CQ_CredentialsAndQualifications()
		{
			CredentialTypeCode = "q",
			CredentialCategoryCode = "8",
			IdentificationCodeQualifier = "y",
			IdentificationCode = "eU",
			LevelOfIndividualTestOrCourseCode = "Pz",
			BasisForAcademicCreditOrAwardOfCredentialCode = "v",
			CredentialRequirementCode = "Z",
			YesNoConditionOrResponseCode = "1",
			ConditionIndicatorCode = "mV",
			StateOrProvinceCode = "mj",
		};

		var actual = Map.MapObject<CQ_CredentialsAndQualifications>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredCredentialTypeCode(string credentialTypeCode, bool isValidExpected)
	{
		var subject = new CQ_CredentialsAndQualifications();
		subject.CredentialTypeCode = credentialTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("y", "eU", true)]
	[InlineData("", "eU", false)]
	[InlineData("y", "", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new CQ_CredentialsAndQualifications();
		subject.CredentialTypeCode = "q";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
