using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ISXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ISX*o*R*NkH4EH*5";

		var expected = new ISX_InterchangeSyntaxExtension()
		{
			ReleaseCharacter = "o",
			CharacterEncoding = "R",
			OverridingX12VersionReleaseCode = "NkH4EH",
			IndustryIdentifier = "5",
		};

		var actual = Map.MapObject<ISX_InterchangeSyntaxExtension>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "NkH4EH", true)]
	[InlineData("5", "", false)]
	public void Validation_ARequiresBIndustryIdentifier(string industryIdentifier, string overridingX12VersionReleaseCode, bool isValidExpected)
	{
		var subject = new ISX_InterchangeSyntaxExtension();
		subject.IndustryIdentifier = industryIdentifier;
		subject.OverridingX12VersionReleaseCode = overridingX12VersionReleaseCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
