using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class S001Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "ZitV:R";

		var expected = new S001_SyntaxIdentifier()
		{
			SyntaxIdentifier = "ZitV",
			SyntaxVersionNumber = "R",
		};

		var actual = Map.MapComposite<S001_SyntaxIdentifier>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZitV", true)]
	public void Validation_RequiredSyntaxIdentifier(string syntaxIdentifier, bool isValidExpected)
	{
		var subject = new S001_SyntaxIdentifier();
		//Required fields
		subject.SyntaxVersionNumber = "R";
		//Test Parameters
		subject.SyntaxIdentifier = syntaxIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredSyntaxVersionNumber(string syntaxVersionNumber, bool isValidExpected)
	{
		var subject = new S001_SyntaxIdentifier();
		//Required fields
		subject.SyntaxIdentifier = "ZitV";
		//Test Parameters
		subject.SyntaxVersionNumber = syntaxVersionNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
