using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E977Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "N:X:m:r:q:y:T:g";

		var expected = new E977_PaymentDetails()
		{
			PaymentMethodCode = "N",
			PaymentPurposeCode = "X",
			ServiceTypeCode = "m",
			MonetaryAmount = "r",
			CurrencyIdentificationCode = "q",
			ReferenceIdentifier = "y",
			DateValue = "T",
			LocationNameCode = "g",
		};

		var actual = Map.MapComposite<E977_PaymentDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
