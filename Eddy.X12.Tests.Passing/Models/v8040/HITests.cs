using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v8040.Composites;
using Eddy.x12.Models.v8040;

namespace Eddy.x12.Tests.Models.v8040;

public class HITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "HI*";

		var expected = new HI_HealthCareInformationCodes()
		{
			HealthCareCodeInformation = null,
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
