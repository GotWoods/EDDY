using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class SCCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "SCC+w+Q+";

		var expected = new SCC_SchedulingConditions()
		{
			DeliveryPlanStatusIndicatorCoded = "w",
			DeliveryRequirementsCoded = "Q",
			PatternDescription = null,
		};

		var actual = Map.MapObject<SCC_SchedulingConditions>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredDeliveryPlanStatusIndicatorCoded(string deliveryPlanStatusIndicatorCoded, bool isValidExpected)
	{
		var subject = new SCC_SchedulingConditions();
		//Required fields
		//Test Parameters
		subject.DeliveryPlanStatusIndicatorCoded = deliveryPlanStatusIndicatorCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
