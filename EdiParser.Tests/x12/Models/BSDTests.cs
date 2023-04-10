using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BSDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BSD*GH*8*c*P*9*CE*t*qI*t";

		var expected = new BSD_BreakdownStructureDescription()
		{
			ReferenceIdentificationQualifier = "GH",
			ReferenceIdentification = "8",
			Description = "c",
			ReportingStructureIdentifier = "P",
			ReferenceIdentification2 = "9",
			BreakdownStructureDetailCode = "CE",
			ReportingStructureIdentifier2 = "t",
			SecurityLevelCode = "qI",
			CalculationOperationCode = "t",
		};

		var actual = Map.MapObject<BSD_BreakdownStructureDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("GH", true)]
	public void Validatation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new BSD_BreakdownStructureDescription();
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.Description = "ABC";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("8","c", true)]
	[InlineData("", "c", true)]
	[InlineData("8", "", true)]
	public void Validation_AtLeastOneReferenceIdentification(string referenceIdentification, string description, bool isValidExpected)
	{
		var subject = new BSD_BreakdownStructureDescription();
		subject.ReferenceIdentificationQualifier = "GH";
		subject.ReferenceIdentification = referenceIdentification;
		subject.Description = description;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
