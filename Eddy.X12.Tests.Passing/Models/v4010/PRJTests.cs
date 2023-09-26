using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class PRJTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PRJ*h*o5*v*AY5TQh7O";

		var expected = new PRJ_MultifamilyHousingProject()
		{
			Name = "h",
			ReferenceIdentificationQualifier = "o5",
			ReferenceIdentification = "v",
			Date = "AY5TQh7O",
		};

		var actual = Map.MapObject<PRJ_MultifamilyHousingProject>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new PRJ_MultifamilyHousingProject();
		//Required fields
		//Test Parameters
		subject.Name = name;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "o5";
			subject.ReferenceIdentification = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("o5", "v", true)]
	[InlineData("o5", "", false)]
	[InlineData("", "v", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new PRJ_MultifamilyHousingProject();
		//Required fields
		subject.Name = "h";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
