using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class G84Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G84*9*t*H";

		var expected = new G84_DeliveryReturnRecordOfTotals()
		{
			Quantity = 9,
			TotalInvoiceAmount = "t",
			TotalDepositDollarAmount = "H",
		};

		var actual = Map.MapObject<G84_DeliveryReturnRecordOfTotals>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", false)]
	[InlineData(9, "t", true)]
	[InlineData(9, "", true)]
	[InlineData(0, "t", true)]
	public void Validation_AtLeastOneQuantity(decimal quantity, string totalInvoiceAmount, bool isValidExpected)
	{
		var subject = new G84_DeliveryReturnRecordOfTotals();
		if (quantity > 0)
			subject.Quantity = quantity;
		subject.TotalInvoiceAmount = totalInvoiceAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
