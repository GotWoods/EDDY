using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class BSDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BSD*iD*R*A*M*c*xI*z*MF";

		var expected = new BSD_BreakdownStructureDescription()
		{
			ReferenceIdentificationQualifier = "iD",
			ReferenceIdentification = "R",
			Description = "A",
			Level = "M",
			ReferenceIdentification2 = "c",
			BreakdownStructureDetailCode = "xI",
			Level2 = "z",
			SecurityLevelCode = "MF",
		};

		var actual = Map.MapObject<BSD_BreakdownStructureDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("iD", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new BSD_BreakdownStructureDescription();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		//At Least one
		subject.ReferenceIdentification = "R";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("R", "A", true)]
	[InlineData("R", "", true)]
	[InlineData("", "A", true)]
	public void Validation_AtLeastOneReferenceIdentification(string referenceIdentification, string description, bool isValidExpected)
	{
		var subject = new BSD_BreakdownStructureDescription();
		//Required fields
		subject.ReferenceIdentificationQualifier = "iD";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
