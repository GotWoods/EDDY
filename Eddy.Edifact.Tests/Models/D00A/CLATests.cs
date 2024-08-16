using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class CLATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CLA+L+";

		var expected = new CLA_ClauseIdentification()
		{
			ClauseCodeQualifier = "L",
			ClauseName = null,
		};

		var actual = Map.MapObject<CLA_ClauseIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredClauseCodeQualifier(string clauseCodeQualifier, bool isValidExpected)
	{
		var subject = new CLA_ClauseIdentification();
		//Required fields
		//Test Parameters
		subject.ClauseCodeQualifier = clauseCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
