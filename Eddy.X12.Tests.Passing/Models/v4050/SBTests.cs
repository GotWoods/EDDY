using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class SBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SB*4";

		var expected = new SB_DocketLevel()
		{
			DocketLevelNumber = 4,
		};

		var actual = Map.MapObject<SB_DocketLevel>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredDocketLevelNumber(int docketLevelNumber, bool isValidExpected)
	{
		var subject = new SB_DocketLevel();
		if (docketLevelNumber > 0)
			subject.DocketLevelNumber = docketLevelNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
