using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class ITDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ITD+7+y+1+Z";

		var expected = new ITD_InformationTypeData()
		{
			InformationCategoryCode = "7",
			LanguageNameCode = "y",
			InformationDetailIdentifier = "1",
			DataFormatDescriptionCode = "Z",
		};

		var actual = Map.MapObject<ITD_InformationTypeData>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
