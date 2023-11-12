using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class UMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "UM*Q*N*Z***X*7*m*M*u";

		var expected = new UM_HealthCareServicesReviewInformation()
		{
			RequestCategoryCode = "Q",
			CertificationTypeCode = "N",
			ServiceTypeCode = "Z",
			HealthCareServiceLocationInformation = null,
			RelatedCausesInformation = null,
			LevelOfServiceCode = "X",
			CurrentHealthConditionCode = "7",
			PrognosisCode = "m",
			ReleaseOfInformationCode = "M",
			DelayReasonCode = "u",
		};

		var actual = Map.MapObject<UM_HealthCareServicesReviewInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredRequestCategoryCode(string requestCategoryCode, bool isValidExpected)
	{
		var subject = new UM_HealthCareServicesReviewInformation();
		//Required fields
		//Test Parameters
		subject.RequestCategoryCode = requestCategoryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
