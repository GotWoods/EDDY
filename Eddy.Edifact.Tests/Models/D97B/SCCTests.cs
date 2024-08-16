using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97B;
using Eddy.Edifact.Models.D97B.Composites;

namespace Eddy.Edifact.Tests.Models.D97B;

public class SCCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "SCC+2+m+";

		var expected = new SCC_SchedulingConditions()
		{
			DeliveryPlanStatusIndicatorCoded = "2",
			DeliveryInstructionCoded = "m",
			PatternDescription = null,
		};

		var actual = Map.MapObject<SCC_SchedulingConditions>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredDeliveryPlanStatusIndicatorCoded(string deliveryPlanStatusIndicatorCoded, bool isValidExpected)
	{
		var subject = new SCC_SchedulingConditions();
		//Required fields
		//Test Parameters
		subject.DeliveryPlanStatusIndicatorCoded = deliveryPlanStatusIndicatorCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
