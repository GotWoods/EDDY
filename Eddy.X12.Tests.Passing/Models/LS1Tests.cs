using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class LS1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LS1*6*l*QY*T*w*J*E";

		var expected = new LS1_AssetItemIdentification()
		{
			Quantity = 6,
			AssignedIdentification = "l",
			ChangeOrResponseTypeCode = "QY",
			ProductServiceID = "T",
			ProductServiceID2 = "w",
			ProductServiceID3 = "J",
			ProductServiceID4 = "E",
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
		if (quantity > 0)
		subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
