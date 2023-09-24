using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class G92Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G92*BG*eRADEK*c";

		var expected = new G92_PurchaseOrderChangeType()
		{
			ChangeOrResponseTypeCode = "BG",
			Date = "eRADEK",
			PurchaseOrderNumber = "c",
		};

		var actual = Map.MapObject<G92_PurchaseOrderChangeType>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("BG", true)]
	public void Validation_RequiredChangeOrResponseTypeCode(string changeOrResponseTypeCode, bool isValidExpected)
	{
		var subject = new G92_PurchaseOrderChangeType();
		subject.Date = "eRADEK";
		subject.PurchaseOrderNumber = "c";
		subject.ChangeOrResponseTypeCode = changeOrResponseTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("eRADEK", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new G92_PurchaseOrderChangeType();
		subject.ChangeOrResponseTypeCode = "BG";
		subject.PurchaseOrderNumber = "c";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredPurchaseOrderNumber(string purchaseOrderNumber, bool isValidExpected)
	{
		var subject = new G92_PurchaseOrderChangeType();
		subject.ChangeOrResponseTypeCode = "BG";
		subject.Date = "eRADEK";
		subject.PurchaseOrderNumber = purchaseOrderNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
