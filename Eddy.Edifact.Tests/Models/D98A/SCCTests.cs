using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98A;
using Eddy.Edifact.Models.D98A.Composites;

namespace Eddy.Edifact.Tests.Models.D98A;

public class SCCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "SCC+z+p+";

		var expected = new SCC_SchedulingConditions()
		{
			DeliveryPlanCommitmentLevelCoded = "z",
			DeliveryInstructionCoded = "p",
			PatternDescription = null,
		};

		var actual = Map.MapObject<SCC_SchedulingConditions>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredDeliveryPlanCommitmentLevelCoded(string deliveryPlanCommitmentLevelCoded, bool isValidExpected)
	{
		var subject = new SCC_SchedulingConditions();
		//Required fields
		//Test Parameters
		subject.DeliveryPlanCommitmentLevelCoded = deliveryPlanCommitmentLevelCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
