using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D09A;
using Eddy.Edifact.Models.D09A.Composites;

namespace Eddy.Edifact.Tests.Models.D09A.Composites;

public class C250Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "L:o:7:q";

		var expected = new C250_Usage()
		{
			UsageDescriptionCoded = "L",
			CodeListIdentificationCode = "o",
			CodeListResponsibleAgencyCode = "7",
			UsageDescription = "q",
		};

		var actual = Map.MapComposite<C250_Usage>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
