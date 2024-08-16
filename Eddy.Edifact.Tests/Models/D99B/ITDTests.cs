using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class ITDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ITD+2+6+i+l";

		var expected = new ITD_InformationTypeData()
		{
			InformationCategoryCoded = "2",
			LanguageNameCode = "6",
			InformationDetailIdentification = "i",
			DataFormatDescriptionCode = "l",
		};

		var actual = Map.MapObject<ITD_InformationTypeData>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
