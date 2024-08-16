using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C838Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "v:F:c:O";

		var expected = new C838_DosageDetails()
		{
			DosageDescriptionIdentifier = "v",
			CodeListIdentificationCode = "F",
			CodeListResponsibleAgencyCode = "c",
			DosageDescription = "O",
		};

		var actual = Map.MapComposite<C838_DosageDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
