using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class DFNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "DFN+V+O+q";

		var expected = new DFN_DefinitionFunction()
		{
			DefinitionFunctionCode = "V",
			DefinitionExtentCode = "O",
			DefinitionIdentifier = "q",
		};

		var actual = Map.MapObject<DFN_DefinitionFunction>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredDefinitionFunctionCode(string definitionFunctionCode, bool isValidExpected)
	{
		var subject = new DFN_DefinitionFunction();
		//Required fields
		//Test Parameters
		subject.DefinitionFunctionCode = definitionFunctionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
