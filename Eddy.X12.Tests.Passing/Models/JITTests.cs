using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class JITTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "JIT*2*bP4c";

		var expected = new JIT_JustInTimeSchedule()
		{
			Quantity = 2,
			Time = "bP4c",
		};

		var actual = Map.MapObject<JIT_JustInTimeSchedule>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new JIT_JustInTimeSchedule();
		subject.Time = "bP4c";
		if (quantity > 0)
		subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bP4c", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new JIT_JustInTimeSchedule();
		subject.Quantity = 2;
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
