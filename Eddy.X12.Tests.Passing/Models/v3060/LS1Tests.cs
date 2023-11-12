using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class LS1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LS1*3*c*s4*7*W*T*W";

		var expected = new LS1_AssetItemIdentification()
		{
			Quantity = 3,
			AssignedIdentification = "c",
			ChangeOrResponseTypeCode = "s4",
			ProductServiceID = "7",
			ProductServiceID2 = "W",
			ProductServiceID3 = "T",
			ProductServiceID4 = "W",
		};

		var actual = Map.MapObject<LS1_AssetItemIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
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
