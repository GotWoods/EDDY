using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v6020;
using Eddy.x12.Models.v6020.Composites;

namespace Eddy.x12.Tests.Models.v6020.Composites;

public class C063Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "4*2*1*9*1*6";

		var expected = new C063_ChangeQuantities()
		{
			Quantity = 4,
			Quantity2 = 2,
			Quantity3 = 1,
			Quantity4 = 9,
			Quantity5 = 1,
			Quantity6 = 6,
		};

		var actual = Map.MapObject<C063_ChangeQuantities>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(2, 1, false)]
	[InlineData(2, 0, true)]
	[InlineData(0, 1, true)]
	public void Validation_OnlyOneOfQuantity2(decimal quantity2, decimal quantity3, bool isValidExpected)
	{
		var subject = new C063_ChangeQuantities();
		//Required fields
		//Test Parameters
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		if (quantity3 > 0) 
			subject.Quantity3 = quantity3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
