using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98B;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Tests.Models.D98B;

public class DFNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "DFN+5+V+6";

		var expected = new DFN_DefinitionFunction()
		{
			DefinitionFunctionCoded = "5",
			DefinitionExtentCoded = "V",
			DefinitionIdentification = "6",
		};

		var actual = Map.MapObject<DFN_DefinitionFunction>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredDefinitionFunctionCoded(string definitionFunctionCoded, bool isValidExpected)
	{
		var subject = new DFN_DefinitionFunction();
		//Required fields
		//Test Parameters
		subject.DefinitionFunctionCoded = definitionFunctionCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
