using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C331Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "E:M:0:l:o";

		var expected = new C331_InsuranceCoverDetails()
		{
			InsuranceCoverDescriptionCode = "E",
			CodeListIdentificationCode = "M",
			CodeListResponsibleAgencyCode = "0",
			InsuranceCoverDescription = "l",
			InsuranceCoverDescription2 = "o",
		};

		var actual = Map.MapComposite<C331_InsuranceCoverDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
