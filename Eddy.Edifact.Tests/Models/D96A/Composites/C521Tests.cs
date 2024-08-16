using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C521Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "9:q:g:F:W";

		var expected = new C521_BusinessFunction()
		{
			BusinessFunctionQualifier = "9",
			BusinessFunctionCoded = "q",
			CodeListQualifier = "g",
			CodeListResponsibleAgencyCoded = "F",
			BusinessDescription = "W",
		};

		var actual = Map.MapComposite<C521_BusinessFunction>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredBusinessFunctionQualifier(string businessFunctionQualifier, bool isValidExpected)
	{
		var subject = new C521_BusinessFunction();
		//Required fields
		subject.BusinessFunctionCoded = "q";
		//Test Parameters
		subject.BusinessFunctionQualifier = businessFunctionQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredBusinessFunctionCoded(string businessFunctionCoded, bool isValidExpected)
	{
		var subject = new C521_BusinessFunction();
		//Required fields
		subject.BusinessFunctionQualifier = "9";
		//Test Parameters
		subject.BusinessFunctionCoded = businessFunctionCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
