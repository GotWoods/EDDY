using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class ALITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ALI+Z+6+g+e+T+Y+1";

		var expected = new ALI_AdditionalInformation()
		{
			CountryOfOriginCoded = "Z",
			TypeOfDutyRegimeCoded = "6",
			SpecialConditionCode = "g",
			SpecialConditionCode2 = "e",
			SpecialConditionCode3 = "T",
			SpecialConditionCode4 = "Y",
			SpecialConditionCode5 = "1",
		};

		var actual = Map.MapObject<ALI_AdditionalInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
