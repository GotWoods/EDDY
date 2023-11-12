using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class LS1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LS1*6*9*kG*4*K*j*R";

		var expected = new LS1_AssetItemIdentification()
		{
			Quantity = 6,
			AssignedIdentification = "9",
			ChangeOrResponseTypeCode = "kG",
			ProductServiceID = "4",
			ProductServiceID2 = "K",
			ProductServiceID3 = "j",
			ProductServiceID4 = "R",
		};

		var actual = Map.MapObject<LS1_AssetItemIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
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
