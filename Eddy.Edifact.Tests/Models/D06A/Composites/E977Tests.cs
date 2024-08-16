using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A.Composites;

public class E977Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "U:9:b:X:2:k:8:4";

		var expected = new E977_PaymentDetails()
		{
			PaymentMethodCode = "U",
			PaymentPurposeCode = "9",
			ServiceTypeCode = "b",
			MonetaryAmount = "X",
			CurrencyIdentificationCode = "2",
			ReferenceIdentifier = "k",
			Date = "8",
			LocationIdentifier = "4",
		};

		var actual = Map.MapComposite<E977_PaymentDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
