using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class BSDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BSD*K6*U*s*0*9*t0*S*yB*I";

		var expected = new BSD_BreakdownStructureDescription()
		{
			ReferenceIdentificationQualifier = "K6",
			ReferenceIdentification = "U",
			Description = "s",
			ReportingStructureIdentifier = "0",
			ReferenceIdentification2 = "9",
			BreakdownStructureDetailCode = "t0",
			ReportingStructureIdentifier2 = "S",
			SecurityLevelCode = "yB",
			CalculationOperationCode = "I",
		};

		var actual = Map.MapObject<BSD_BreakdownStructureDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K6", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new BSD_BreakdownStructureDescription();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		//At Least one
		subject.ReferenceIdentification = "U";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("U", "s", true)]
	[InlineData("U", "", true)]
	[InlineData("", "s", true)]
	public void Validation_AtLeastOneReferenceIdentification(string referenceIdentification, string description, bool isValidExpected)
	{
		var subject = new BSD_BreakdownStructureDescription();
		//Required fields
		subject.ReferenceIdentificationQualifier = "K6";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
