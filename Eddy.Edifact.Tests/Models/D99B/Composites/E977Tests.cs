using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E977Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "J:w:Y:v:s:N:J:t";

		var expected = new E977_PaymentDetails()
		{
			FormOfPaymentIdentification = "J",
			PaymentTypeIdentification = "w",
			ServiceTypeCode = "Y",
			MonetaryAmountValue = "v",
			CurrencyIdentificationCode = "s",
			ReferenceIdentifier = "N",
			DateValue = "J",
			LocationNameCode = "t",
		};

		var actual = Map.MapComposite<E977_PaymentDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
