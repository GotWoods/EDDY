using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class PKDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PKD*fwS1q*J*N4*J*m";

		var expected = new PKD_PackagingDescription()
		{
			PackagingCode = "fwS1q",
			SourceSubqualifier = "J",
			AgencyQualifierCode = "N4",
			PackagingDescriptionCode = "J",
			OwnershipCode = "m",
		};

		var actual = Map.MapObject<PKD_PackagingDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("J", "fwS1q", true)]
	[InlineData("J", "", false)]
	[InlineData("", "fwS1q", true)]
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
	[InlineData("N4", "J", true)]
	[InlineData("N4", "", false)]
	[InlineData("", "J", true)]
	public void Validation_ARequiresBAgencyQualifierCode(string agencyQualifierCode, string sourceSubqualifier, bool isValidExpected)
	{
		var subject = new PKD_PackagingDescription();
		//Required fields
		//Test Parameters
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.SourceSubqualifier = sourceSubqualifier;
		//A Requires B
		if (sourceSubqualifier != "")
			subject.PackagingCode = "fwS1q";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
