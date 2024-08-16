using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class ALITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ALI+7+z+w+i+S+w+t";

		var expected = new ALI_AdditionalInformation()
		{
			CountryOfOriginCoded = "7",
			TypeOfDutyRegimeCoded = "z",
			SpecialConditionsCoded = "w",
			SpecialConditionsCoded2 = "i",
			SpecialConditionsCoded3 = "S",
			SpecialConditionsCoded4 = "w",
			SpecialConditionsCoded5 = "t",
		};

		var actual = Map.MapObject<ALI_AdditionalInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
