using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C232Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "b:O:C:y";

		var expected = new C232_GovernmentAction()
		{
			GovernmentAgencyIdentificationCode = "b",
			GovernmentInvolvementCode = "O",
			GovernmentActionCode = "C",
			GovernmentProcedureCode = "y",
		};

		var actual = Map.MapComposite<C232_GovernmentAction>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
