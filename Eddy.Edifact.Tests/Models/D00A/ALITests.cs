using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class ALITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ALI+n+1+d+o+F+6+b";

		var expected = new ALI_AdditionalInformation()
		{
			CountryOfOriginNameCode = "n",
			DutyRegimeTypeCode = "1",
			SpecialConditionCode = "d",
			SpecialConditionCode2 = "o",
			SpecialConditionCode3 = "F",
			SpecialConditionCode4 = "6",
			SpecialConditionCode5 = "b",
		};

		var actual = Map.MapObject<ALI_AdditionalInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
