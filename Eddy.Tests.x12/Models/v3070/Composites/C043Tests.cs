using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3070;
using Eddy.x12.Models.v3070.Composites;

namespace Eddy.x12.Tests.Models.v3070.Composites;

public class C043Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "K*4*KJ";

		var expected = new C043_HealthCareClaimStatus()
		{
			IndustryCode = "K",
			IndustryCode2 = "4",
			EntityIdentifierCode = "KJ",
		};

		var actual = Map.MapObject<C043_HealthCareClaimStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredIndustryCode(string industryCode, bool isValidExpected)
	{
		var subject = new C043_HealthCareClaimStatus();
		//Required fields
		subject.IndustryCode2 = "4";
		//Test Parameters
		subject.IndustryCode = industryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredIndustryCode2(string industryCode2, bool isValidExpected)
	{
		var subject = new C043_HealthCareClaimStatus();
		//Required fields
		subject.IndustryCode = "K";
		//Test Parameters
		subject.IndustryCode2 = industryCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
