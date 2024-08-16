using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class TODTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "TOD+a+d+";

		var expected = new TOD_TermsOfDeliveryOrTransport()
		{
			TermsOfDeliveryOrTransportFunctionCoded = "a",
			TransportChargesPaymentMethodCode = "d",
			TermsOfDeliveryOrTransport = null,
		};

		var actual = Map.MapObject<TOD_TermsOfDeliveryOrTransport>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
