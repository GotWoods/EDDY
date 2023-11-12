using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v4040;
using Eddy.x12.Models.v4040.Composites;

namespace Eddy.x12.Tests.Models.v4040.Composites;

public class C045Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "tj*hc*jC*fS*QG";

		var expected = new C045_ConditionsIndicated()
		{
			ConditionIndicator = "tj",
			ConditionIndicator2 = "hc",
			ConditionIndicator3 = "jC",
			ConditionIndicator4 = "fS",
			ConditionIndicator5 = "QG",
		};

		var actual = Map.MapObject<C045_ConditionsIndicated>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tj", true)]
	public void Validation_RequiredConditionIndicator(string conditionIndicator, bool isValidExpected)
	{
		var subject = new C045_ConditionsIndicated();
		//Required fields
		//Test Parameters
		subject.ConditionIndicator = conditionIndicator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
