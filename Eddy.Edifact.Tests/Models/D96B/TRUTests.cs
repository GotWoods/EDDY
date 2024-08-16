using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96B;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Tests.Models.D96B;

public class TRUTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "TRU+J+6+i+q+F";

		var expected = new TRU_TechnicalRules()
		{
			IdentityNumber = "J",
			Version = "6",
			Release = "i",
			RulePartIdentification = "q",
			CodeListResponsibleAgencyCoded = "F",
		};

		var actual = Map.MapObject<TRU_TechnicalRules>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredIdentityNumber(string identityNumber, bool isValidExpected)
	{
		var subject = new TRU_TechnicalRules();
		//Required fields
		//Test Parameters
		subject.IdentityNumber = identityNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
