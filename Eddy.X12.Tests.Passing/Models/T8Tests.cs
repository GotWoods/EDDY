using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class T8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "T8*7*s";

		var expected = new T8_FreeFormTransitData()
		{
			AssignedNumber = 7,
			TransitFreeFormData = "s",
		};

		var actual = Map.MapObject<T8_FreeFormTransitData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new T8_FreeFormTransitData();
		subject.TransitFreeFormData = "s";
		if (assignedNumber > 0)
		subject.AssignedNumber = assignedNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredTransitFreeFormData(string transitFreeFormData, bool isValidExpected)
	{
		var subject = new T8_FreeFormTransitData();
		subject.AssignedNumber = 7;
		subject.TransitFreeFormData = transitFreeFormData;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
