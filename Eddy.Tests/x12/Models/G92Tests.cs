using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G92Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G92*pT*FF7KEtPu*x";

		var expected = new G92_PurchaseOrderChangeType()
		{
			ChangeOrResponseTypeCode = "pT",
			Date = "FF7KEtPu",
			PurchaseOrderNumber = "x",
		};

		var actual = Map.MapObject<G92_PurchaseOrderChangeType>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("pT", true)]
	public void Validation_RequiredChangeOrResponseTypeCode(string changeOrResponseTypeCode, bool isValidExpected)
	{
		var subject = new G92_PurchaseOrderChangeType();
		subject.Date = "FF7KEtPu";
		subject.PurchaseOrderNumber = "x";
		subject.ChangeOrResponseTypeCode = changeOrResponseTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("FF7KEtPu", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new G92_PurchaseOrderChangeType();
		subject.ChangeOrResponseTypeCode = "pT";
		subject.PurchaseOrderNumber = "x";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new G92_PurchaseOrderChangeType();
		subject.ChangeOrResponseTypeCode = "pT";
		subject.Date = "FF7KEtPu";
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
