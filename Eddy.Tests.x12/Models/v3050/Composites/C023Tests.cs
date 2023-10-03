using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3050;
using Eddy.x12.Models.v3050.Composites;

namespace Eddy.x12.Tests.Models.v3050.Composites;

public class C023Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "c*Q*F";

		var expected = new C023_HealthCareServiceLocationInformation()
		{
			FacilityCodeValue = "c",
			FacilityCodeQualifier = "Q",
			ClaimFrequencyTypeCode = "F",
		};

		var actual = Map.MapObject<C023_HealthCareServiceLocationInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredFacilityCodeValue(string facilityCodeValue, bool isValidExpected)
	{
		var subject = new C023_HealthCareServiceLocationInformation();
		//Required fields
		//Test Parameters
		subject.FacilityCodeValue = facilityCodeValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
