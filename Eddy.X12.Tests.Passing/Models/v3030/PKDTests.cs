using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class PKDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PKD*6QwGY*4*A8*y";

		var expected = new PKD_PackagingDescription()
		{
			PackagingCode = "6QwGY",
			SourceSubqualifier = "4",
			AgencyQualifierCode = "A8",
			PackagingDescriptionCode = "y",
		};

		var actual = Map.MapObject<PKD_PackagingDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("4", "6QwGY", true)]
	[InlineData("4", "", false)]
	[InlineData("", "6QwGY", true)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string packagingCode, bool isValidExpected)
	{
		var subject = new PKD_PackagingDescription();
		//Required fields
		//Test Parameters
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.PackagingCode = packagingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("A8", "4", true)]
	[InlineData("A8", "", false)]
	[InlineData("", "4", true)]
	public void Validation_ARequiresBAgencyQualifierCode(string agencyQualifierCode, string sourceSubqualifier, bool isValidExpected)
	{
		var subject = new PKD_PackagingDescription();
		//Required fields
		//Test Parameters
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.SourceSubqualifier = sourceSubqualifier;
		//A Requires B
		if (sourceSubqualifier != "")
			subject.PackagingCode = "6QwGY";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
