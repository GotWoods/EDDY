using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7050;

namespace Eddy.x12.Tests.Models.v7050;

public class G84Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G84*2*y*g*1R*7*2*6";

		var expected = new G84_DeliveryReturnRecordOfTotals()
		{
			Quantity = 2,
			TotalInvoiceAmount = "y",
			TotalDepositDollarAmount = "g",
			TransactionTypeCode = "1R",
			MonetaryAmount = 7,
			MonetaryAmount2 = 2,
			MonetaryAmount3 = 6,
		};

		var actual = Map.MapObject<G84_DeliveryReturnRecordOfTotals>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", false)]
	[InlineData(2, "y", true)]
	[InlineData(2, "", true)]
	[InlineData(0, "y", true)]
	public void Validation_AtLeastOneQuantity(decimal quantity, string totalInvoiceAmount, bool isValidExpected)
	{
		var subject = new G84_DeliveryReturnRecordOfTotals();
		if (quantity > 0)
			subject.Quantity = quantity;
		subject.TotalInvoiceAmount = totalInvoiceAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
