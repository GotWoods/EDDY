using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class TPBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TPB*1*3*lK*S";

		var expected = new TPB_BusinessProfessionalTitle()
		{
			BusinesssProfessionalTitle = "1",
			FreeFormMessageText = "3",
			AgencyQualifierCode = "lK",
			SourceSubqualifier = "S",
		};

		var actual = Map.MapObject<TPB_BusinessProfessionalTitle>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("1", "3", true)]
	[InlineData("1", "", true)]
	[InlineData("", "3", true)]
	public void Validation_AtLeastOneBusinesssProfessionalTitle(string businesssProfessionalTitle, string freeFormMessageText, bool isValidExpected)
	{
		var subject = new TPB_BusinessProfessionalTitle();
		//Required fields
		//Test Parameters
		subject.BusinesssProfessionalTitle = businesssProfessionalTitle;
		subject.FreeFormMessageText = freeFormMessageText;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("lK", "1", true)]
	[InlineData("lK", "", false)]
	[InlineData("", "1", true)]
	public void Validation_ARequiresBAgencyQualifierCode(string agencyQualifierCode, string businesssProfessionalTitle, bool isValidExpected)
	{
		var subject = new TPB_BusinessProfessionalTitle();
		//Required fields
		//Test Parameters
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.BusinesssProfessionalTitle = businesssProfessionalTitle;
		//At Least one
		subject.FreeFormMessageText = "3";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("S", "lK", true)]
	[InlineData("S", "", false)]
	[InlineData("", "lK", true)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new TPB_BusinessProfessionalTitle();
		//Required fields
		//Test Parameters
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;
		//A Requires B
		if (agencyQualifierCode != "")
			subject.BusinesssProfessionalTitle = "1";
		//At Least one
		subject.BusinesssProfessionalTitle = "1";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
