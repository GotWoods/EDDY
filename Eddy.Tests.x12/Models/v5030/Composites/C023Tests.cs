using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v5030;
using Eddy.x12.Models.v5030.Composites;

namespace Eddy.x12.Tests.Models.v5030.Composites;

public class C023Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "8*8*k";

		var expected = new C023_HealthCareServiceLocationInformation()
		{
			FacilityCodeValue = "8",
			FacilityCodeQualifier = "8",
			ClaimFrequencyTypeCode = "k",
		};

		var actual = Map.MapObject<C023_HealthCareServiceLocationInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredFacilityCodeValue(string facilityCodeValue, bool isValidExpected)
	{
		var subject = new C023_HealthCareServiceLocationInformation();
		//Required fields
		//Test Parameters
		subject.FacilityCodeValue = facilityCodeValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
