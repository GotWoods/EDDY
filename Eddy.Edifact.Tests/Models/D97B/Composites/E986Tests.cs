using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97B;
using Eddy.Edifact.Models.D97B.Composites;

namespace Eddy.Edifact.Tests.Models.D97B.Composites;

public class E986Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "A:Q:F:W:e:R:U:N";

		var expected = new E986_TravellerDetails()
		{
			GivenName = "A",
			PartyQualifier = "Q",
			TravellerReferenceNumber = "F",
			Title = "W",
			TravellerAccompaniedByInfantIndicator = "e",
			LanguageCoded = "R",
			SexCoded = "U",
			Age = "N",
		};

		var actual = Map.MapComposite<E986_TravellerDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
