using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class PRVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PRV+O++";

		var expected = new PRV_ProvisoDetails()
		{
			ProvisoCodeQualifier = "O",
			ProvisoType = null,
			ProvisoCalculation = null,
		};

		var actual = Map.MapObject<PRV_ProvisoDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredProvisoCodeQualifier(string provisoCodeQualifier, bool isValidExpected)
	{
		var subject = new PRV_ProvisoDetails();
		//Required fields
		//Test Parameters
		subject.ProvisoCodeQualifier = provisoCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
