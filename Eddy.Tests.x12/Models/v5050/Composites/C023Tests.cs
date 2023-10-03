using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v5050;
using Eddy.x12.Models.v5050.Composites;

namespace Eddy.x12.Tests.Models.v5050.Composites;

public class C023Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "k*g*3";

		var expected = new C023_HealthCareServiceLocationInformation()
		{
			FacilityCodeValue = "k",
			FacilityCodeQualifier = "g",
			ClaimFrequencyTypeCode = "3",
		};

		var actual = Map.MapObject<C023_HealthCareServiceLocationInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredFacilityCodeValue(string facilityCodeValue, bool isValidExpected)
	{
		var subject = new C023_HealthCareServiceLocationInformation();
		//Required fields
		subject.FacilityCodeQualifier = "g";
		//Test Parameters
		subject.FacilityCodeValue = facilityCodeValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredFacilityCodeQualifier(string facilityCodeQualifier, bool isValidExpected)
	{
		var subject = new C023_HealthCareServiceLocationInformation();
		//Required fields
		subject.FacilityCodeValue = "k";
		//Test Parameters
		subject.FacilityCodeQualifier = facilityCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
