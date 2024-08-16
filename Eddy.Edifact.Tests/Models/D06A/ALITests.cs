using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A;

public class ALITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ALI+n+t+F+D+f+R+E";

		var expected = new ALI_AdditionalInformation()
		{
			CountryOfOriginIdentifier = "n",
			DutyRegimeTypeCode = "t",
			SpecialConditionCode = "F",
			SpecialConditionCode2 = "D",
			SpecialConditionCode3 = "f",
			SpecialConditionCode4 = "R",
			SpecialConditionCode5 = "E",
		};

		var actual = Map.MapObject<ALI_AdditionalInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
