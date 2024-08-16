using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C534Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "T:y:a:w:0:e";

		var expected = new C534_PaymentInstructionDetails()
		{
			PaymentConditionsCode = "T",
			PaymentGuaranteeMeansCode = "y",
			PaymentMeansCode = "a",
			CodeListIdentificationCode = "w",
			CodeListResponsibleAgencyCode = "0",
			PaymentChannelCode = "e",
		};

		var actual = Map.MapComposite<C534_PaymentInstructionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
