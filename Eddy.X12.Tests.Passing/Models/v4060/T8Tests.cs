using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.Tests.Models.v4060;

public class T8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "T8*2*A";

		var expected = new T8_FreeFormTransitData()
		{
			AssignedNumber = 2,
			TransitFreeFormData = "A",
		};

		var actual = Map.MapObject<T8_FreeFormTransitData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new T8_FreeFormTransitData();
		subject.TransitFreeFormData = "A";
		if (assignedNumber > 0)
			subject.AssignedNumber = assignedNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredTransitFreeFormData(string transitFreeFormData, bool isValidExpected)
	{
		var subject = new T8_FreeFormTransitData();
		subject.AssignedNumber = 2;
		subject.TransitFreeFormData = transitFreeFormData;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
