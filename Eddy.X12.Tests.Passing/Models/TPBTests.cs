using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class TPBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TPB*a*v*ea*J";

		var expected = new TPB_BusinessProfessionalTitle()
		{
			BusinessProfessionalTitleCode = "a",
			FreeFormMessageText = "v",
			AgencyQualifierCode = "ea",
			SourceSubqualifier = "J",
		};

		var actual = Map.MapObject<TPB_BusinessProfessionalTitle>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("a","v", true)]
	[InlineData("", "v", true)]
	[InlineData("a", "", true)]
	public void Validation_AtLeastOneBusinessProfessionalTitleCode(string businessProfessionalTitleCode, string freeFormMessageText, bool isValidExpected)
	{
		var subject = new TPB_BusinessProfessionalTitle();
		subject.BusinessProfessionalTitleCode = businessProfessionalTitleCode;
		subject.FreeFormMessageText = freeFormMessageText;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "a", true)]
	[InlineData("ea", "", false)]
	public void Validation_ARequiresBAgencyQualifierCode(string agencyQualifierCode, string businessProfessionalTitleCode, bool isValidExpected)
	{
		var subject = new TPB_BusinessProfessionalTitle();
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.BusinessProfessionalTitleCode = businessProfessionalTitleCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "ea", true)]
	[InlineData("J", "", false)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new TPB_BusinessProfessionalTitle();
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
