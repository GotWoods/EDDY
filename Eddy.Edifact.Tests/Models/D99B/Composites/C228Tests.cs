using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C228Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "I:d";

		var expected = new C228_TransportMeans()
		{
			TransportMeansDescriptionCode = "I",
			TransportMeansDescription = "d",
		};

		var actual = Map.MapComposite<C228_TransportMeans>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
