using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class SCCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "SCC+a+k+";

		var expected = new SCC_SchedulingConditions()
		{
			DeliveryPlanCommitmentLevelCode = "a",
			DeliveryInstructionCode = "k",
			PatternDescription = null,
		};

		var actual = Map.MapObject<SCC_SchedulingConditions>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredDeliveryPlanCommitmentLevelCode(string deliveryPlanCommitmentLevelCode, bool isValidExpected)
	{
		var subject = new SCC_SchedulingConditions();
		//Required fields
		//Test Parameters
		subject.DeliveryPlanCommitmentLevelCode = deliveryPlanCommitmentLevelCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
