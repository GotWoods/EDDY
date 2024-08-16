using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class E977Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "q:m:S:L:G:M:W:j";

		var expected = new E977_PaymentDetails()
		{
			PaymentMethodCode = "q",
			PaymentPurposeCode = "m",
			ServiceTypeCode = "S",
			MonetaryAmount = "L",
			CurrencyIdentificationCode = "G",
			ReferenceIdentifier = "M",
			Date = "W",
			LocationNameCode = "j",
		};

		var actual = Map.MapComposite<E977_PaymentDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
