using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E986Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "W:4:H:U:H:X:E:k";

		var expected = new E986_TravellerDetails()
		{
			GivenName = "W",
			PartyFunctionCodeQualifier = "4",
			TravellerReferenceNumber = "H",
			Title = "U",
			TravellerAccompaniedByInfantIndicator = "H",
			LanguageNameCode = "X",
			GenderCode = "E",
			Age = "k",
		};

		var actual = Map.MapComposite<E986_TravellerDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
