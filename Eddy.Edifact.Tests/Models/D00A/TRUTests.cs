using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class TRUTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "TRU+E+Y+M+p+f";

		var expected = new TRU_TechnicalRules()
		{
			ObjectIdentifier = "E",
			VersionIdentifier = "Y",
			ReleaseIdentifier = "M",
			RulePartIdentifier = "p",
			CodeListResponsibleAgencyCode = "f",
		};

		var actual = Map.MapObject<TRU_TechnicalRules>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredObjectIdentifier(string objectIdentifier, bool isValidExpected)
	{
		var subject = new TRU_TechnicalRules();
		//Required fields
		//Test Parameters
		subject.ObjectIdentifier = objectIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
