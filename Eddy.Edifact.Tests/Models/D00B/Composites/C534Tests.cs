using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C534Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "G:q:l:a:x:C";

		var expected = new C534_PaymentInstructionDetails()
		{
			PaymentConditionsCode = "G",
			PaymentGuaranteeMeansCode = "q",
			PaymentMeansCode = "l",
			CodeListIdentificationCode = "a",
			CodeListResponsibleAgencyCode = "x",
			PaymentChannelCode = "C",
		};

		var actual = Map.MapComposite<C534_PaymentInstructionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
