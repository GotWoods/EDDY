using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6040;

namespace Eddy.x12.Tests.Models.v6040;

public class G84Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G84*7*h*s*GM";

		var expected = new G84_DeliveryReturnRecordOfTotals()
		{
			Quantity = 7,
			TotalInvoiceAmount = "h",
			TotalDepositDollarAmount = "s",
			TransactionTypeCode = "GM",
		};

		var actual = Map.MapObject<G84_DeliveryReturnRecordOfTotals>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", false)]
	[InlineData(7, "h", true)]
	[InlineData(7, "", true)]
	[InlineData(0, "h", true)]
	public void Validation_AtLeastOneQuantity(decimal quantity, string totalInvoiceAmount, bool isValidExpected)
	{
		var subject = new G84_DeliveryReturnRecordOfTotals();
		if (quantity > 0)
			subject.Quantity = quantity;
		subject.TotalInvoiceAmount = totalInvoiceAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
