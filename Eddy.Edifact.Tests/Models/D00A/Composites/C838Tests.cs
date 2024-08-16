using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C838Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "2:U:b:D";

		var expected = new C838_DosageDetails()
		{
			DosageDescriptionIdentifier = "2",
			CodeListIdentificationCode = "U",
			CodeListResponsibleAgencyCode = "b",
			DosageDescription = "D",
		};

		var actual = Map.MapComposite<C838_DosageDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
