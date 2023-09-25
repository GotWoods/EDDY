using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class Y7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Y7*3*2*6*1917*KO9ray";

		var expected = new Y7_Priority()
		{
			Priority = 3,
			PriorityCode = 2,
			PriorityCodeQualifier = "6",
			PortCallFileNumber = 1917,
			Date = "KO9ray",
		};

		var actual = Map.MapObject<Y7_Priority>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "6", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "6", false)]
	public void Validation_AllAreRequiredPriorityCode(int priorityCode, string priorityCodeQualifier, bool isValidExpected)
	{
		var subject = new Y7_Priority();
		//Required fields
		//Test Parameters
		if (priorityCode > 0) 
			subject.PriorityCode = priorityCode;
		subject.PriorityCodeQualifier = priorityCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
