using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E976Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "l:3:j";

		var expected = new E976_OriginatorDetails()
		{
			CountryNameCode = "l",
			CurrencyIdentificationCode = "3",
			LanguageNameCode = "j",
		};

		var actual = Map.MapComposite<E976_OriginatorDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
