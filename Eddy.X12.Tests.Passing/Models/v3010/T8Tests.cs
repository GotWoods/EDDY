using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class T8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "T8*6*1";

		var expected = new T8_FreeFormTransitData()
		{
			AssignedNumber = 6,
			FreeFormTransitData = "1",
		};

		var actual = Map.MapObject<T8_FreeFormTransitData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new T8_FreeFormTransitData();
		subject.FreeFormTransitData = "1";
		if (assignedNumber > 0)
			subject.AssignedNumber = assignedNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredFreeFormTransitData(string freeFormTransitData, bool isValidExpected)
	{
		var subject = new T8_FreeFormTransitData();
		subject.AssignedNumber = 6;
		subject.FreeFormTransitData = freeFormTransitData;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
