using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class TODTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "TOD+g+I+";

		var expected = new TOD_TermsOfDeliveryOrTransport()
		{
			DeliveryOrTransportTermsFunctionCode = "g",
			TransportChargesPaymentMethodCode = "I",
			TermsOfDeliveryOrTransport = null,
		};

		var actual = Map.MapObject<TOD_TermsOfDeliveryOrTransport>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
