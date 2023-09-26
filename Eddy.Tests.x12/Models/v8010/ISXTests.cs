using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.Tests.Models.v8010;

public class ISXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ISX*G*B*7uhLRa*6";

		var expected = new ISX_InterchangeSyntaxExtension()
		{
			ReleaseCharacter = "G",
			CharacterEncoding = "B",
			OverridingX12VersionReleaseSubreleaseCode = "7uhLRa",
			IndustryIdentifier = "6",
		};

		var actual = Map.MapObject<ISX_InterchangeSyntaxExtension>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("6", "7uhLRa", true)]
	[InlineData("6", "", false)]
	[InlineData("", "7uhLRa", true)]
	public void Validation_ARequiresBIndustryIdentifier(string industryIdentifier, string overridingX12VersionReleaseSubreleaseCode, bool isValidExpected)
	{
		var subject = new ISX_InterchangeSyntaxExtension();
		//Required fields
		//Test Parameters
		subject.IndustryIdentifier = industryIdentifier;
		subject.OverridingX12VersionReleaseSubreleaseCode = overridingX12VersionReleaseSubreleaseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
