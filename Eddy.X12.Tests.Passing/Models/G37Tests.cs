using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G37Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G37*W*tuFC*nZtt";

		var expected = new G37_LaborActivity()
		{
			LaborActivityCode = "W",
			Time = "tuFC",
			Time2 = "nZtt",
		};

		var actual = Map.MapObject<G37_LaborActivity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredLaborActivityCode(string laborActivityCode, bool isValidExpected)
	{
		var subject = new G37_LaborActivity();
		subject.LaborActivityCode = laborActivityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "tuFC", true)]
	[InlineData("nZtt", "", false)]
	public void Validation_ARequiresBTime2(string time2, string time, bool isValidExpected)
	{
		var subject = new G37_LaborActivity();
		subject.LaborActivityCode = "W";
		subject.Time2 = time2;
		subject.Time = time;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
