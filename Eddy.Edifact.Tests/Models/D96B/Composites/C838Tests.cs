using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96B;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Tests.Models.D96B.Composites;

public class C838Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "w:W:B:m";

		var expected = new C838_DosageDetails()
		{
			DosageIdentification = "w",
			CodeListQualifier = "W",
			CodeListResponsibleAgencyCoded = "B",
			Dosage = "m",
		};

		var actual = Map.MapComposite<C838_DosageDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
