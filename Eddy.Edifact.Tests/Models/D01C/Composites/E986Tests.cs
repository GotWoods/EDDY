using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class E986Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "O:2:9:s:P:b:e:L";

		var expected = new E986_TravellerDetails()
		{
			GivenName = "O",
			PartyFunctionCodeQualifier = "2",
			TravellerReferenceIdentifier = "9",
			GivenNameTitleDescription = "s",
			TravellerAccompaniedByInfantIndicatorCode = "P",
			LanguageNameCode = "b",
			GenderCode = "e",
			Age = "L",
		};

		var actual = Map.MapComposite<E986_TravellerDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
