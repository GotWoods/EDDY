using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class OQSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "OQS*3*4";

		var expected = new OQS_OrderQuantitySequence()
		{
			SequenceValue = 3,
			Quantity = 4,
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
		//Required fields
		subject.Quantity = 4;
		//Test Parameters
		if (sequenceValue > 0) 
			subject.SequenceValue = sequenceValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new OQS_OrderQuantitySequence();
		//Required fields
		subject.SequenceValue = 3;
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
