using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E986Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "o:0:w:m:h:N";

		var expected = new E986_TravellerDetails()
		{
			GivenName = "o",
			PartyQualifier = "0",
			TravellerReferenceNumber = "w",
			Title = "m",
			TravellerAccompaniedByInfantIndicator = "h",
			LanguageCoded = "N",
		};

		var actual = Map.MapComposite<E986_TravellerDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
