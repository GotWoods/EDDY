using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C100Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "z:O:g:K:I";

		var expected = new C100_TermsOfDeliveryOrTransport()
		{
			DeliveryOrTransportTermsDescriptionCode = "z",
			CodeListIdentificationCode = "O",
			CodeListResponsibleAgencyCode = "g",
			DeliveryOrTransportTermsDescription = "K",
			DeliveryOrTransportTermsDescription2 = "I",
		};

		var actual = Map.MapComposite<C100_TermsOfDeliveryOrTransport>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
