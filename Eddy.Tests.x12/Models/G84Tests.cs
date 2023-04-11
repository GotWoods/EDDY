using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G84Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G84*1*P*b*Gq*8*7*3";

		var expected = new G84_DeliveryReturnRecordOfTotals()
		{
			Quantity = 1,
			TotalInvoiceAmount = "P",
			TotalDepositDollarAmount = "b",
			TransactionTypeCode = "Gq",
			MonetaryAmount = 8,
			MonetaryAmount2 = 7,
			MonetaryAmount3 = 3,
		};

		var actual = Map.MapObject<G84_DeliveryReturnRecordOfTotals>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0,"", false)]
	[InlineData(1,"P", true)]
	[InlineData(0, "P", true)]
	[InlineData(1, "", true)]
	public void Validation_AtLeastOneQuantity(decimal quantity, string totalInvoiceAmount, bool isValidExpected)
	{
		var subject = new G84_DeliveryReturnRecordOfTotals();
		if (quantity > 0)
		subject.Quantity = quantity;
		subject.TotalInvoiceAmount = totalInvoiceAmount;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
