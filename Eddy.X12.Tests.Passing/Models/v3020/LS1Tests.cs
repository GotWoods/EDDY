using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class LS1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LS1*6*q*1H*i*d*D*f";

		var expected = new LS1_LeaseItemIdentification()
		{
			Quantity = 6,
			AssignedIdentification = "q",
			ChangeOrResponseTypeCode = "1H",
			ProductServiceID = "i",
			ProductServiceID2 = "d",
			ProductServiceID3 = "D",
			ProductServiceID4 = "f",
		};

		var actual = Map.MapObject<LS1_LeaseItemIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new LS1_LeaseItemIdentification();
		//Required fields
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
