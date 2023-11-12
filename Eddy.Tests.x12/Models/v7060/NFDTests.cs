using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.Tests.Models.v7060;

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
