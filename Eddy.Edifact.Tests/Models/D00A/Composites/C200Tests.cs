using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C200Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "9:x:h:0:K:h";

		var expected = new C200_Charge()
		{
			FreightAndOtherChargesDescriptionIdentifier = "9",
			CodeListIdentificationCode = "x",
			CodeListResponsibleAgencyCode = "h",
			FreightAndOtherChargesDescription = "0",
			PaymentArrangementCode = "K",
			ItemIdentifier = "h",
		};

		var actual = Map.MapComposite<C200_Charge>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
