using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D02B;
using Eddy.Edifact.Models.D02B.Composites;

namespace Eddy.Edifact.Tests.Models.D02B.Composites;

public class C001Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "v:y:x:K";

		var expected = new C001_TransportMeans()
		{
			TransportMeansDescriptionCode = "v",
			CodeListIdentificationCode = "y",
			CodeListResponsibleAgencyCode = "x",
			TransportMeansDescription = "K",
		};

		var actual = Map.MapComposite<C001_TransportMeans>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
