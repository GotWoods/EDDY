using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A;

public class PMTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PMT++";

		var expected = new PMT_PaymentInformation()
		{
			PaymentDetails = null,
			CreditCardInformation = null,
		};

		var actual = Map.MapObject<PMT_PaymentInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
