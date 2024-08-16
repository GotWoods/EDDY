using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96B;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Tests.Models.D96B.Composites;

public class C837Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "I:n:Z:q";

		var expected = new C837_CertaintyDetails()
		{
			CertaintyCoded = "I",
			CodeListQualifier = "n",
			CodeListResponsibleAgencyCoded = "Z",
			Certainty = "q",
		};

		var actual = Map.MapComposite<C837_CertaintyDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
