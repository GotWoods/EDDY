using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C200Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "B:B:b:n:Y:S";

		var expected = new C200_Charge()
		{
			FreightAndOtherChargesDescriptionIdentifier = "B",
			CodeListIdentificationCode = "B",
			CodeListResponsibleAgencyCode = "b",
			FreightAndOtherChargesDescription = "n",
			PaymentArrangementCode = "Y",
			ItemIdentifier = "S",
		};

		var actual = Map.MapComposite<C200_Charge>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
