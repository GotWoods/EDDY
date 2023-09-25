using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class PRJTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PRJ*H*vQ*9*BfYCYI";

		var expected = new PRJ_MultifamilyHousingProject()
		{
			Name = "H",
			ReferenceIdentificationQualifier = "vQ",
			ReferenceIdentification = "9",
			Date = "BfYCYI",
		};

		var actual = Map.MapObject<PRJ_MultifamilyHousingProject>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new PRJ_MultifamilyHousingProject();
		//Required fields
		//Test Parameters
		subject.Name = name;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "vQ";
			subject.ReferenceIdentification = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("vQ", "9", true)]
	[InlineData("vQ", "", false)]
	[InlineData("", "9", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new PRJ_MultifamilyHousingProject();
		//Required fields
		subject.Name = "H";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
