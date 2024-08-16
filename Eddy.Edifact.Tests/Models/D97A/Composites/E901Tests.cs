using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E901Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "n:d:n";

		var expected = new E901_ApplicationErrorDetails()
		{
			ApplicationErrorIdentification = "n",
			CodeListQualifier = "d",
			CodeListResponsibleAgencyCoded = "n",
		};

		var actual = Map.MapComposite<E901_ApplicationErrorDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredApplicationErrorIdentification(string applicationErrorIdentification, bool isValidExpected)
	{
		var subject = new E901_ApplicationErrorDetails();
		//Required fields
		//Test Parameters
		subject.ApplicationErrorIdentification = applicationErrorIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
