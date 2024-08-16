using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96B;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Tests.Models.D96B.Composites;

public class C218Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "F:J:J:H";

		var expected = new C218_HazardousMaterial()
		{
			HazardousMaterialClassCodeIdentification = "F",
			CodeListQualifier = "J",
			CodeListResponsibleAgencyCoded = "J",
			HazardousMaterialClass = "H",
		};

		var actual = Map.MapComposite<C218_HazardousMaterial>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
