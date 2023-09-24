using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models;

public class HITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "HI************";

		var expected = new HI_HealthCareInformationCodes()
		{
			HealthCareCodeInformation = null,
			HealthCareCodeInformation2 = null,
			HealthCareCodeInformation3 = null,
			HealthCareCodeInformation4 = null,
			HealthCareCodeInformation5 = null,
			HealthCareCodeInformation6 = null,
			HealthCareCodeInformation7 = null,
			HealthCareCodeInformation8 = null,
			HealthCareCodeInformation9 = null,
			HealthCareCodeInformation10 = null,
			HealthCareCodeInformation11 = null,
			HealthCareCodeInformation12 = null,
		};

		var actual = Map.MapObject<HI_HealthCareInformationCodes>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("AB", true)]
	public void Validation_RequiredHealthCareCodeInformation(string healthCareCodeInformation, bool isValidExpected)
	{
		var subject = new HI_HealthCareInformationCodes();
		if (healthCareCodeInformation != "")
		    subject.HealthCareCodeInformation = new C022_HealthCareCodeInformation() { CodeListQualifierCode = healthCareCodeInformation };
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
