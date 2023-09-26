using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class PRJTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PRJ*3*Bs*7*LaQvhd";

		var expected = new PRJ_MultifamilyHousingProject()
		{
			Name = "3",
			ReferenceIdentificationQualifier = "Bs",
			ReferenceIdentification = "7",
			Date = "LaQvhd",
		};

		var actual = Map.MapObject<PRJ_MultifamilyHousingProject>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new PRJ_MultifamilyHousingProject();
		//Required fields
		//Test Parameters
		subject.Name = name;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "Bs";
			subject.ReferenceIdentification = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Bs", "7", true)]
	[InlineData("Bs", "", false)]
	[InlineData("", "7", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new PRJ_MultifamilyHousingProject();
		//Required fields
		subject.Name = "3";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
