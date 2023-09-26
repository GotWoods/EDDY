using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class BSDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BSD*fn*M*A*b*o*9k*7*20*9";

		var expected = new BSD_BreakdownStructureDescription()
		{
			ReferenceIdentificationQualifier = "fn",
			ReferenceIdentification = "M",
			Description = "A",
			Level = "b",
			ReferenceIdentification2 = "o",
			BreakdownStructureDetailCode = "9k",
			Level2 = "7",
			SecurityLevelCode = "20",
			CalculationOperationCode = "9",
		};

		var actual = Map.MapObject<BSD_BreakdownStructureDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fn", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new BSD_BreakdownStructureDescription();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		//At Least one
		subject.ReferenceIdentification = "M";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("M", "A", true)]
	[InlineData("M", "", true)]
	[InlineData("", "A", true)]
	public void Validation_AtLeastOneReferenceIdentification(string referenceIdentification, string description, bool isValidExpected)
	{
		var subject = new BSD_BreakdownStructureDescription();
		//Required fields
		subject.ReferenceIdentificationQualifier = "fn";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
