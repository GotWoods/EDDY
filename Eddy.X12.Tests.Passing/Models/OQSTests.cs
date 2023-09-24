using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class OQSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "OQS*3*8";

		var expected = new OQS_OrderQuantitySequence()
		{
			SequenceValue = 3,
			Quantity = 8,
		};

		var actual = Map.MapObject<OQS_OrderQuantitySequence>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredSequenceValue(decimal sequenceValue, bool isValidExpected)
	{
		var subject = new OQS_OrderQuantitySequence();
		subject.Quantity = 8;
		if (sequenceValue > 0)
		subject.SequenceValue = sequenceValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new OQS_OrderQuantitySequence();
		subject.SequenceValue = 3;
		if (quantity > 0)
		subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
