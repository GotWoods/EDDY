using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C534Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "s:q:0:V:M:w";

		var expected = new C534_PaymentInstructionDetails()
		{
			PaymentConditionsCoded = "s",
			PaymentGuaranteeCoded = "q",
			PaymentMeansCoded = "0",
			CodeListIdentificationCode = "V",
			CodeListResponsibleAgencyCode = "M",
			PaymentChannelCoded = "w",
		};

		var actual = Map.MapComposite<C534_PaymentInstructionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
