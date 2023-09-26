using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class UMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "UM*4*X*I***f*Z*S*L*E";

		var expected = new UM_HealthCareServicesReviewInformation()
		{
			RequestCategoryCode = "4",
			CertificationTypeCode = "X",
			IndustryCode = "I",
			HealthCareServiceLocationInformation = null,
			RelatedCausesInformation = null,
			LevelOfServiceCode = "f",
			CurrentHealthConditionCode = "Z",
			PrognosisCode = "S",
			ReleaseOfInformationCode = "L",
			DelayReasonCode = "E",
		};

		var actual = Map.MapObject<UM_HealthCareServicesReviewInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredRequestCategoryCode(string requestCategoryCode, bool isValidExpected)
	{
		var subject = new UM_HealthCareServicesReviewInformation();
		//Required fields
		//Test Parameters
		subject.RequestCategoryCode = requestCategoryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
