using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class UMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "UM*I*S*l*J**x*2*4*3*8";

		var expected = new UM_HealthCareServicesReviewInformation()
		{
			RequestCategoryCode = "I",
			CertificationTypeCode = "S",
			ServiceTypeCode = "l",
			PatientLocationCode = "J",
			RelatedCausesInformation = null,
			LevelOfServiceCode = "x",
			CurrentHealthConditionCode = "2",
			PrognosisCode = "4",
			ReleaseOfInformationCode = "3",
			DelayReasonCode = "8",
		};

		var actual = Map.MapObject<UM_HealthCareServicesReviewInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredRequestCategoryCode(string requestCategoryCode, bool isValidExpected)
	{
		var subject = new UM_HealthCareServicesReviewInformation();
		//Required fields
		//Test Parameters
		subject.RequestCategoryCode = requestCategoryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
