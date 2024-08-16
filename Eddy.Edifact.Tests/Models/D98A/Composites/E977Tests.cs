using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98A;
using Eddy.Edifact.Models.D98A.Composites;

namespace Eddy.Edifact.Tests.Models.D98A.Composites;

public class E977Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "k:z:X:Y:p:0:w:f";

		var expected = new E977_PaymentDetails()
		{
			FormOfPaymentIdentification = "k",
			PaymentTypeIdentification = "z",
			ServiceToBePaidCoded = "X",
			MonetaryAmount = "Y",
			CurrencyCoded = "p",
			ReferenceNumber = "0",
			Date = "w",
			PlaceLocationIdentification = "f",
		};

		var actual = Map.MapComposite<E977_PaymentDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
