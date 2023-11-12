using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3050.Composites;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

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
	[InlineData("A", true)]
	public void Validation_RequiredHealthCareCodeInformation(string healthCareCodeInformation, bool isValidExpected)
	{
		var subject = new HI_HealthCareInformationCodes();
		//Required fields
		//Test Parameters
		if (healthCareCodeInformation != "") 
			subject.HealthCareCodeInformation = new C022_HealthCareCodeInformation();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
