using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C100Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "9:7:4:F:o";

		var expected = new C100_TermsOfDeliveryOrTransport()
		{
			DeliveryOrTransportTermsDescriptionCode = "9",
			CodeListIdentificationCode = "7",
			CodeListResponsibleAgencyCode = "4",
			DeliveryOrTransportTermsDescription = "F",
			DeliveryOrTransportTermsDescription2 = "o",
		};

		var actual = Map.MapComposite<C100_TermsOfDeliveryOrTransport>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
