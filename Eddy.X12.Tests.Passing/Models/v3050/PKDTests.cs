using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class PKDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PKD*Xoi*1*Q1*U*I";

		var expected = new PKD_PackagingDescription()
		{
			PackagingCode = "Xoi",
			SourceSubqualifier = "1",
			AgencyQualifierCode = "Q1",
			PackagingDescriptionCode = "U",
			OwnershipCode = "I",
		};

		var actual = Map.MapObject<PKD_PackagingDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("1", "Xoi", true)]
	[InlineData("1", "", false)]
	[InlineData("", "Xoi", true)]
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
	[InlineData("Q1", "1", true)]
	[InlineData("Q1", "", false)]
	[InlineData("", "1", true)]
	public void Validation_ARequiresBAgencyQualifierCode(string agencyQualifierCode, string sourceSubqualifier, bool isValidExpected)
	{
		var subject = new PKD_PackagingDescription();
		//Required fields
		//Test Parameters
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.SourceSubqualifier = sourceSubqualifier;
		//A Requires B
		if (sourceSubqualifier != "")
			subject.PackagingCode = "Xoi";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
