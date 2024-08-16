using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C;

public class ITDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ITD+E+G+w+v";

		var expected = new ITD_InformationTypeData()
		{
			InformationCategoryCode = "E",
			LanguageNameCode = "G",
			StatusDescriptionCode = "w",
			DataFormatDescriptionCode = "v",
		};

		var actual = Map.MapObject<ITD_InformationTypeData>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
