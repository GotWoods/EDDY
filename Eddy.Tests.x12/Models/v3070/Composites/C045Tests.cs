using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3070;
using Eddy.x12.Models.v3070.Composites;

namespace Eddy.x12.Tests.Models.v3070.Composites;

public class C045Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "fu*Rf*HN*xS*06";

		var expected = new C045_ConditionsIndicated()
		{
			ConditionIndicator = "fu",
			ConditionIndicator2 = "Rf",
			ConditionIndicator3 = "HN",
			ConditionIndicator4 = "xS",
			ConditionIndicator5 = "06",
		};

		var actual = Map.MapObject<C045_ConditionsIndicated>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fu", true)]
	public void Validation_RequiredConditionIndicator(string conditionIndicator, bool isValidExpected)
	{
		var subject = new C045_ConditionsIndicated();
		//Required fields
		//Test Parameters
		subject.ConditionIndicator = conditionIndicator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
