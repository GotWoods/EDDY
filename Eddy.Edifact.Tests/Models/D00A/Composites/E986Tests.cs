using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E986Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "S:p:O:S:f:M:y:j";

		var expected = new E986_TravellerDetails()
		{
			GivenName = "S",
			PartyFunctionCodeQualifier = "p",
			TravellerReferenceIdentifier = "O",
			GivenNameTitleDescription = "S",
			TravellerAccompaniedByInfantIndicatorCode = "f",
			LanguageNameCode = "M",
			GenderCode = "y",
			AgeValue = "j",
		};

		var actual = Map.MapComposite<E986_TravellerDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
