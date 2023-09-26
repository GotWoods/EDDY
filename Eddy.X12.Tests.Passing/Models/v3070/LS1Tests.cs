using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class LS1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LS1*9*B*oF*F*Q*G*F";

		var expected = new LS1_AssetItemIdentification()
		{
			Quantity = 9,
			AssignedIdentification = "B",
			ChangeOrResponseTypeCode = "oF",
			ProductServiceID = "F",
			ProductServiceID2 = "Q",
			ProductServiceID3 = "G",
			ProductServiceID4 = "F",
		};

		var actual = Map.MapObject<LS1_AssetItemIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
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
