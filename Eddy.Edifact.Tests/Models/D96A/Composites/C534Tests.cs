using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C534Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "y:m:N:0:X:L";

		var expected = new C534_PaymentInstructionDetails()
		{
			PaymentConditionsCoded = "y",
			PaymentGuaranteeCoded = "m",
			PaymentMeansCoded = "N",
			CodeListQualifier = "0",
			CodeListResponsibleAgencyCoded = "X",
			PaymentChannelCoded = "L",
		};

		var actual = Map.MapComposite<C534_PaymentInstructionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
