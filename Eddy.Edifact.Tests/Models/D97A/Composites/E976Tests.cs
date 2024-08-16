using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E976Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "U:4:h";

		var expected = new E976_OriginatorDetails()
		{
			CountryCoded = "U",
			CurrencyCoded = "4",
			LanguageCoded = "h",
		};

		var actual = Map.MapComposite<E976_OriginatorDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
