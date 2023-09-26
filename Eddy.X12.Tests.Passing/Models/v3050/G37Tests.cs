using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class G37Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G37*5*6Mz5*2VJ0";

		var expected = new G37_LaborActivity()
		{
			LaborActivityCode = "5",
			Time = "6Mz5",
			Time2 = "2VJ0",
		};

		var actual = Map.MapObject<G37_LaborActivity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredLaborActivityCode(string laborActivityCode, bool isValidExpected)
	{
		var subject = new G37_LaborActivity();
		//Required fields
		//Test Parameters
		subject.LaborActivityCode = laborActivityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("2VJ0", "6Mz5", true)]
	[InlineData("2VJ0", "", false)]
	[InlineData("", "6Mz5", true)]
	public void Validation_ARequiresBTime2(string time2, string time, bool isValidExpected)
	{
		var subject = new G37_LaborActivity();
		//Required fields
		subject.LaborActivityCode = "5";
		//Test Parameters
		subject.Time2 = time2;
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
