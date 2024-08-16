using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class S001Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "sz1g:T:G:R";

		var expected = new S001_SyntaxIdentifier()
		{
			SyntaxIdentifier = "sz1g",
			SyntaxVersionNumber = "T",
			ServiceCodeListDirectoryVersionNumber = "G",
			CharacterEncodingCoded = "R",
		};

		var actual = Map.MapComposite<S001_SyntaxIdentifier>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("sz1g", true)]
	public void Validation_RequiredSyntaxIdentifier(string syntaxIdentifier, bool isValidExpected)
	{
		var subject = new S001_SyntaxIdentifier();
		//Required fields
		subject.SyntaxVersionNumber = "T";
		//Test Parameters
		subject.SyntaxIdentifier = syntaxIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredSyntaxVersionNumber(string syntaxVersionNumber, bool isValidExpected)
	{
		var subject = new S001_SyntaxIdentifier();
		//Required fields
		subject.SyntaxIdentifier = "sz1g";
		//Test Parameters
		subject.SyntaxVersionNumber = syntaxVersionNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
