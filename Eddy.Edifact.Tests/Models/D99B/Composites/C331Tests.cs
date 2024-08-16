using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C331Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "M:G:B:t:d";

		var expected = new C331_InsuranceCoverDetails()
		{
			InsuranceCoverIdentification = "M",
			CodeListIdentificationCode = "G",
			CodeListResponsibleAgencyCode = "B",
			InsuranceCover = "t",
			InsuranceCover2 = "d",
		};

		var actual = Map.MapComposite<C331_InsuranceCoverDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
