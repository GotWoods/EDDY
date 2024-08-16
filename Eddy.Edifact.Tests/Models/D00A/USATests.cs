using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class USATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "USA++";

		var expected = new USA_SecurityAlgorithm()
		{
			SecurityAlgorithm = null,
			AlgorithmParameter = null,
		};

		var actual = Map.MapObject<USA_SecurityAlgorithm>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredSecurityAlgorithm(string securityAlgorithm, bool isValidExpected)
	{
		var subject = new USA_SecurityAlgorithm();
		//Required fields
		//Test Parameters
		if (securityAlgorithm != "") 
			subject.SecurityAlgorithm = new S502_SecurityAlgorithm();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
