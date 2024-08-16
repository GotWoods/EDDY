using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E977Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "n:k:j:U:b:e:s:N";

		var expected = new E977_PaymentDetails()
		{
			FormOfPaymentIdentification = "n",
			PaymentTypeIdentification = "k",
			ServiceToBePaidCoded = "j",
			MonetaryAmount = "U",
			CurrencyCoded = "b",
			ReferenceNumber = "e",
			Date = "s",
			PlaceLocationIdentification = "N",
		};

		var actual = Map.MapComposite<E977_PaymentDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
