using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class E977Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "s:b:E:r:h:y:q:J";

		var expected = new E977_PaymentDetails()
		{
			PaymentMethodCode = "s",
			PaymentPurposeCode = "b",
			ServiceTypeCode = "E",
			MonetaryAmount = "r",
			CurrencyIdentificationCode = "h",
			ReferenceIdentifier = "y",
			DateValue = "q",
			LocationNameCode = "J",
		};

		var actual = Map.MapComposite<E977_PaymentDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
