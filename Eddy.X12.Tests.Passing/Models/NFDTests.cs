using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class NFDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NFD*";

		var expected = new NFD_NutritionFactsPanelFooterStatement()
		{
			CompositeMultipleLanguageTextInformation = null,
		};

		var actual = Map.MapObject<NFD_NutritionFactsPanelFooterStatement>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
