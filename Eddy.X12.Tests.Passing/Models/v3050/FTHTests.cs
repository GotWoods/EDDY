using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class FTHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FTH*w*6*Y*5C";

		var expected = new FTH_FirstTimeHomeBuyer()
		{
			YesNoConditionOrResponseCode = "w",
			YesNoConditionOrResponseCode2 = "6",
			TypeOfResidenceCode = "Y",
			TypeOfAccountCode = "5C",
		};

		var actual = Map.MapObject<FTH_FirstTimeHomeBuyer>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new FTH_FirstTimeHomeBuyer();
		//Required fields
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
