using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C838Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "u:j:L:b";

		var expected = new C838_DosageDetails()
		{
			DosageIdentification = "u",
			CodeListIdentificationCode = "j",
			CodeListResponsibleAgencyCode = "L",
			Dosage = "b",
		};

		var actual = Map.MapComposite<C838_DosageDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
