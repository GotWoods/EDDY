using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.Tests.Models.v8020;

public class ISXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ISX*L*Y*ktl96I*F";

		var expected = new ISX_InterchangeSyntaxExtension()
		{
			ReleaseCharacter = "L",
			CharacterEncoding = "Y",
			OverridingX12VersionReleaseCode = "ktl96I",
			IndustryIdentifier = "F",
		};

		var actual = Map.MapObject<ISX_InterchangeSyntaxExtension>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("F", "ktl96I", true)]
	[InlineData("F", "", false)]
	[InlineData("", "ktl96I", true)]
	public void Validation_ARequiresBIndustryIdentifier(string industryIdentifier, string overridingX12VersionReleaseCode, bool isValidExpected)
	{
		var subject = new ISX_InterchangeSyntaxExtension();
		//Required fields
		//Test Parameters
		subject.IndustryIdentifier = industryIdentifier;
		subject.OverridingX12VersionReleaseCode = overridingX12VersionReleaseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
