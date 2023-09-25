using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class LQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LQ*k*g";

		var expected = new LQ_IndustryCode()
		{
			CodeListQualifierCode = "k",
			IndustryCode = "g",
		};

		var actual = Map.MapObject<LQ_IndustryCode>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("k", "g", true)]
	[InlineData("k", "", false)]
	[InlineData("", "g", true)]
	public void Validation_ARequiresBCodeListQualifierCode(string codeListQualifierCode, string industryCode, bool isValidExpected)
	{
		var subject = new LQ_IndustryCode();
		//Required fields
		//Test Parameters
		subject.CodeListQualifierCode = codeListQualifierCode;
		subject.IndustryCode = industryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
