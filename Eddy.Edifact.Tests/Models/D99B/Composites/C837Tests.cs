using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C837Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "F:V:y:K";

		var expected = new C837_CertaintyDetails()
		{
			CertaintyCoded = "F",
			CodeListIdentificationCode = "V",
			CodeListResponsibleAgencyCode = "y",
			Certainty = "K",
		};

		var actual = Map.MapComposite<C837_CertaintyDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
