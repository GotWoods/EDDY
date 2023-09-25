using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class Y7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Y7*2*3*r*7366*uSoI8vxL";

		var expected = new Y7_Priority()
		{
			Priority = 2,
			PriorityCode = 3,
			PriorityCodeQualifier = "r",
			PortCallFileNumber = 7366,
			Date = "uSoI8vxL",
		};

		var actual = Map.MapObject<Y7_Priority>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "r", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "r", false)]
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
