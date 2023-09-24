using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7050;

namespace Eddy.x12.Tests.Models.v7050;

public class T8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "T8*3*v";

		var expected = new T8_FreeFormTransitData()
		{
			AssignedNumber = 3,
			TransitFreeFormData = "v",
		};

		var actual = Map.MapObject<T8_FreeFormTransitData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new T8_FreeFormTransitData();
		subject.TransitFreeFormData = "v";
		if (assignedNumber > 0)
			subject.AssignedNumber = assignedNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredTransitFreeFormData(string transitFreeFormData, bool isValidExpected)
	{
		var subject = new T8_FreeFormTransitData();
		subject.AssignedNumber = 3;
		subject.TransitFreeFormData = transitFreeFormData;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
