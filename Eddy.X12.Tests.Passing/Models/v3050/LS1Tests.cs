using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class LS1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LS1*2*S*5Z*s*D*L*3";

		var expected = new LS1_AssetItemIdentification()
		{
			Quantity = 2,
			AssignedIdentification = "S",
			ChangeOrResponseTypeCode = "5Z",
			ProductServiceID = "s",
			ProductServiceID2 = "D",
			ProductServiceID3 = "L",
			ProductServiceID4 = "3",
		};

		var actual = Map.MapObject<LS1_AssetItemIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new LS1_AssetItemIdentification();
		//Required fields
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
