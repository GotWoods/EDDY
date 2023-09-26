using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class TPBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TPB*O*U*ZU*z";

		var expected = new TPB_BusinessProfessionalTitle()
		{
			BusinessProfessionalTitleCode = "O",
			FreeFormMessageText = "U",
			AgencyQualifierCode = "ZU",
			SourceSubqualifier = "z",
		};

		var actual = Map.MapObject<TPB_BusinessProfessionalTitle>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("O", "U", true)]
	[InlineData("O", "", true)]
	[InlineData("", "U", true)]
	public void Validation_AtLeastOneBusinessProfessionalTitleCode(string businessProfessionalTitleCode, string freeFormMessageText, bool isValidExpected)
	{
		var subject = new TPB_BusinessProfessionalTitle();
		//Required fields
		//Test Parameters
		subject.BusinessProfessionalTitleCode = businessProfessionalTitleCode;
		subject.FreeFormMessageText = freeFormMessageText;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ZU", "O", true)]
	[InlineData("ZU", "", false)]
	[InlineData("", "O", true)]
	public void Validation_ARequiresBAgencyQualifierCode(string agencyQualifierCode, string businessProfessionalTitleCode, bool isValidExpected)
	{
		var subject = new TPB_BusinessProfessionalTitle();
		//Required fields
		//Test Parameters
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.BusinessProfessionalTitleCode = businessProfessionalTitleCode;
		//At Least one
		subject.FreeFormMessageText = "U";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("z", "ZU", true)]
	[InlineData("z", "", false)]
	[InlineData("", "ZU", true)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new TPB_BusinessProfessionalTitle();
		//Required fields
		//Test Parameters
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;
		//A Requires B
		if (agencyQualifierCode != "")
			subject.BusinessProfessionalTitleCode = "O";
		//At Least one
		subject.BusinessProfessionalTitleCode = "O";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
