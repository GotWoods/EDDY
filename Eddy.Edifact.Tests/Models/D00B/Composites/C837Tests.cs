using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C837Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "q:B:b:G";

		var expected = new C837_CertaintyDetails()
		{
			CertaintyDescriptionCode = "q",
			CodeListIdentificationCode = "B",
			CodeListResponsibleAgencyCode = "b",
			CertaintyDescription = "G",
		};

		var actual = Map.MapComposite<C837_CertaintyDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
