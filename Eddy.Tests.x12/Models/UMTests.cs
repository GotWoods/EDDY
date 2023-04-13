using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class UMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "UM*5*w*d***Y*u*4*Y*s";

		var expected = new UM_HealthCareServicesReviewInformation()
		{
			RequestCategoryCode = "5",
			CertificationTypeCode = "w",
			IndustryCode = "d",
			HealthCareServiceLocationInformation = null,
			RelatedCausesInformation = null,
			LevelOfServiceCode = "Y",
			CurrentHealthConditionCode = "u",
			PrognosisCode = "4",
			ReleaseOfInformationCode = "Y",
			DelayReasonCode = "s",
		};

		var actual = Map.MapObject<UM_HealthCareServicesReviewInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredRequestCategoryCode(string requestCategoryCode, bool isValidExpected)
	{
		var subject = new UM_HealthCareServicesReviewInformation();
		subject.RequestCategoryCode = requestCategoryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
