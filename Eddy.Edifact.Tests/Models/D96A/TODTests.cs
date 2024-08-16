using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class TODTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "TOD+W+W+";

		var expected = new TOD_TermsOfDeliveryOrTransport()
		{
			TermsOfDeliveryOrTransportFunctionCoded = "W",
			TransportChargesMethodOfPaymentCoded = "W",
			TermsOfDeliveryOrTransport = null,
		};

		var actual = Map.MapObject<TOD_TermsOfDeliveryOrTransport>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
