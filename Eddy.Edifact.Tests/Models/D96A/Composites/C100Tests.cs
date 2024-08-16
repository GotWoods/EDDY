using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C100Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "p:L:7:T:3";

		var expected = new C100_TermsOfDeliveryOrTransport()
		{
			TermsOfDeliveryOrTransportCoded = "p",
			CodeListQualifier = "L",
			CodeListResponsibleAgencyCoded = "7",
			TermsOfDeliveryOrTransport = "T",
			TermsOfDeliveryOrTransport2 = "3",
		};

		var actual = Map.MapComposite<C100_TermsOfDeliveryOrTransport>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
