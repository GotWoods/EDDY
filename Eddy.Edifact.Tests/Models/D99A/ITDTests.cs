using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99A;
using Eddy.Edifact.Models.D99A.Composites;

namespace Eddy.Edifact.Tests.Models.D99A;

public class ITDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ITD+q+Y+8+d";

		var expected = new ITD_InformationTypeData()
		{
			InformationCategoryCoded = "q",
			LanguageCoded = "Y",
			InformationDetailIdentification = "8",
			DataFormatCoded = "d",
		};

		var actual = Map.MapObject<ITD_InformationTypeData>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
