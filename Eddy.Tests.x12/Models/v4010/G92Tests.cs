using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class G92Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G92*tx*Z0CeJDg4*F";

		var expected = new G92_PurchaseOrderChangeType()
		{
			ChangeOrResponseTypeCode = "tx",
			Date = "Z0CeJDg4",
			PurchaseOrderNumber = "F",
		};

		var actual = Map.MapObject<G92_PurchaseOrderChangeType>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tx", true)]
	public void Validation_RequiredChangeOrResponseTypeCode(string changeOrResponseTypeCode, bool isValidExpected)
	{
		var subject = new G92_PurchaseOrderChangeType();
		subject.Date = "Z0CeJDg4";
		subject.PurchaseOrderNumber = "F";
		subject.ChangeOrResponseTypeCode = changeOrResponseTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z0CeJDg4", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new G92_PurchaseOrderChangeType();
		subject.ChangeOrResponseTypeCode = "tx";
		subject.PurchaseOrderNumber = "F";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new G92_PurchaseOrderChangeType();
		subject.ChangeOrResponseTypeCode = "tx";
		subject.Date = "Z0CeJDg4";
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
