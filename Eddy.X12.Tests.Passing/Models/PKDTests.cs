using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PKDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PKD*EyL*A*s5*T*j";

		var expected = new PKD_PackagingDescription()
		{
			PackagingCode = "EyL",
			SourceSubqualifier = "A",
			AgencyQualifierCode = "s5",
			PackagingDescriptionCode = "T",
			OwnershipCode = "j",
		};

		var actual = Map.MapObject<PKD_PackagingDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "EyL", true)]
	[InlineData("A", "", false)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string packagingCode, bool isValidExpected)
	{
		var subject = new PKD_PackagingDescription();
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.PackagingCode = packagingCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "A", true)]
	[InlineData("s5", "", false)]
	public void Validation_ARequiresBAgencyQualifierCode(string agencyQualifierCode, string sourceSubqualifier, bool isValidExpected)
	{
		var subject = new PKD_PackagingDescription();
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.SourceSubqualifier = sourceSubqualifier;

		if (sourceSubqualifier != "")
			subject.PackagingCode = "AAA";

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
