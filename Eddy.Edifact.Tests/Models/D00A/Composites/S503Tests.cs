using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class S503Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "R:Q";

		var expected = new S503_AlgorithmParameter()
		{
			AlgorithmParameterQualifier = "R",
			AlgorithmParameterValue = "Q",
		};

		var actual = Map.MapComposite<S503_AlgorithmParameter>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredAlgorithmParameterQualifier(string algorithmParameterQualifier, bool isValidExpected)
	{
		var subject = new S503_AlgorithmParameter();
		//Required fields
		subject.AlgorithmParameterValue = "Q";
		//Test Parameters
		subject.AlgorithmParameterQualifier = algorithmParameterQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredAlgorithmParameterValue(string algorithmParameterValue, bool isValidExpected)
	{
		var subject = new S503_AlgorithmParameter();
		//Required fields
		subject.AlgorithmParameterQualifier = "R";
		//Test Parameters
		subject.AlgorithmParameterValue = algorithmParameterValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
