using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class BSDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BSD*BH*i*4*R*r*pf*G*TQ*T";

		var expected = new BSD_BreakdownStructureDescription()
		{
			ReferenceIdentificationQualifier = "BH",
			ReferenceIdentification = "i",
			Description = "4",
			Level = "R",
			ReferenceIdentification2 = "r",
			BreakdownStructureDetailCode = "pf",
			Level2 = "G",
			SecurityLevelCode = "TQ",
			CalculationOperationCode = "T",
		};

		var actual = Map.MapObject<BSD_BreakdownStructureDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("BH", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new BSD_BreakdownStructureDescription();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		//At Least one
		subject.ReferenceIdentification = "i";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("i", "4", true)]
	[InlineData("i", "", true)]
	[InlineData("", "4", true)]
	public void Validation_AtLeastOneReferenceIdentification(string referenceIdentification, string description, bool isValidExpected)
	{
		var subject = new BSD_BreakdownStructureDescription();
		//Required fields
		subject.ReferenceIdentificationQualifier = "BH";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
