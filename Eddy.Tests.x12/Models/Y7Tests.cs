using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class Y7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Y7*6*6*D*4988*1Uvp3vCe";

		var expected = new Y7_CargoBookingPriority()
		{
			Priority = 6,
			PriorityCode = 6,
			PriorityCodeQualifier = "D",
			PortCallFileNumber = 4988,
			Date = "1Uvp3vCe",
		};

		var actual = Map.MapObject<Y7_CargoBookingPriority>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(6, "D", true)]
	[InlineData(0, "D", false)]
	[InlineData(6, "", false)]
	public void Validation_AllAreRequiredPriorityCode(int priorityCode, string priorityCodeQualifier, bool isValidExpected)
	{
		var subject = new Y7_CargoBookingPriority();
		if (priorityCode > 0)
		subject.PriorityCode = priorityCode;
		subject.PriorityCodeQualifier = priorityCodeQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
