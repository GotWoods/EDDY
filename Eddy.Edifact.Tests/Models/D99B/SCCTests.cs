using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class SCCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "SCC+Y+h+";

		var expected = new SCC_SchedulingConditions()
		{
			DeliveryPlanCommitmentLevelCode = "Y",
			DeliveryInstructionCoded = "h",
			PatternDescription = null,
		};

		var actual = Map.MapObject<SCC_SchedulingConditions>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredDeliveryPlanCommitmentLevelCode(string deliveryPlanCommitmentLevelCode, bool isValidExpected)
	{
		var subject = new SCC_SchedulingConditions();
		//Required fields
		//Test Parameters
		subject.DeliveryPlanCommitmentLevelCode = deliveryPlanCommitmentLevelCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
