using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class TRUTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "TRU+D+M+F+j+G";

		var expected = new TRU_TechnicalRules()
		{
			ObjectIdentifier = "D",
			Version = "M",
			Release = "F",
			RulePartIdentification = "j",
			CodeListResponsibleAgencyCode = "G",
		};

		var actual = Map.MapObject<TRU_TechnicalRules>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredObjectIdentifier(string objectIdentifier, bool isValidExpected)
	{
		var subject = new TRU_TechnicalRules();
		//Required fields
		//Test Parameters
		subject.ObjectIdentifier = objectIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
