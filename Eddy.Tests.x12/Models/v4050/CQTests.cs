using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class CQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CQ*n*Z*1*NC*tZ*i*9*c*BB*s3";

		var expected = new CQ_CredentialsAndQualifications()
		{
			CredentialTypeCode = "n",
			CredentialCategoryCode = "Z",
			IdentificationCodeQualifier = "1",
			IdentificationCode = "NC",
			LevelOfIndividualTestOrCourseCode = "tZ",
			BasisForAcademicCreditOrAwardOfCredentialCode = "i",
			CredentialRequirementCode = "9",
			YesNoConditionOrResponseCode = "c",
			ConditionIndicator = "BB",
			StateOrProvinceCode = "s3",
		};

		var actual = Map.MapObject<CQ_CredentialsAndQualifications>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredCredentialTypeCode(string credentialTypeCode, bool isValidExpected)
	{
		var subject = new CQ_CredentialsAndQualifications();
		//Required fields
		//Test Parameters
		subject.CredentialTypeCode = credentialTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "1";
			subject.IdentificationCode = "NC";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("1", "NC", true)]
	[InlineData("1", "", false)]
	[InlineData("", "NC", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new CQ_CredentialsAndQualifications();
		//Required fields
		subject.CredentialTypeCode = "n";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
