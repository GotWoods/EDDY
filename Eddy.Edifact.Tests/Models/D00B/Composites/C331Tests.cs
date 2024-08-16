using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C331Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "z:E:7:T:P";

		var expected = new C331_InsuranceCoverDetails()
		{
			InsuranceCoverDescriptionCode = "z",
			CodeListIdentificationCode = "E",
			CodeListResponsibleAgencyCode = "7",
			InsuranceCoverDescription = "T",
			InsuranceCoverDescription2 = "P",
		};

		var actual = Map.MapComposite<C331_InsuranceCoverDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
