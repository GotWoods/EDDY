using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v4020;
using Eddy.x12.Models.v4020.Composites;

namespace Eddy.x12.Tests.Models.v4020.Composites;

public class C043Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "B*O*lY*x";

		var expected = new C043_HealthCareClaimStatus()
		{
			IndustryCode = "B",
			IndustryCode2 = "O",
			EntityIdentifierCode = "lY",
			CodeListQualifierCode = "x",
		};

		var actual = Map.MapObject<C043_HealthCareClaimStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredIndustryCode(string industryCode, bool isValidExpected)
	{
		var subject = new C043_HealthCareClaimStatus();
		//Required fields
		subject.IndustryCode2 = "O";
		//Test Parameters
		subject.IndustryCode = industryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredIndustryCode2(string industryCode2, bool isValidExpected)
	{
		var subject = new C043_HealthCareClaimStatus();
		//Required fields
		subject.IndustryCode = "B";
		//Test Parameters
		subject.IndustryCode2 = industryCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
