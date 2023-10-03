using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v6030;
using Eddy.x12.Models.v6030.Composites;

namespace Eddy.x12.Tests.Models.v6030.Composites;

public class C045Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "Dx*e2*ca*p5*qV";

		var expected = new C045_ConditionsIndicated()
		{
			ConditionIndicatorCode = "Dx",
			ConditionIndicatorCode2 = "e2",
			ConditionIndicatorCode3 = "ca",
			ConditionIndicatorCode4 = "p5",
			ConditionIndicatorCode5 = "qV",
		};

		var actual = Map.MapObject<C045_ConditionsIndicated>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Dx", true)]
	public void Validation_RequiredConditionIndicatorCode(string conditionIndicatorCode, bool isValidExpected)
	{
		var subject = new C045_ConditionsIndicated();
		//Required fields
		//Test Parameters
		subject.ConditionIndicatorCode = conditionIndicatorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
