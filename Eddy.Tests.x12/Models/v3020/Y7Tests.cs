using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class Y7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Y7*6*1*f*1168*BPFVSR";

		var expected = new Y7_Priority()
		{
			Priority = 6,
			PriorityCode = 1,
			PriorityCodeQualifier = "f",
			PortCallFileNumber = 1168,
			RequiredDeliveryDate = "BPFVSR",
		};

		var actual = Map.MapObject<Y7_Priority>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "f", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "f", false)]
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
