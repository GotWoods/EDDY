using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A.Composites;

public class E976Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "0:d:q";

		var expected = new E976_OriginatorDetails()
		{
			CountryIdentifier = "0",
			CurrencyIdentificationCode = "d",
			LanguageNameCode = "q",
		};

		var actual = Map.MapComposite<E976_OriginatorDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
