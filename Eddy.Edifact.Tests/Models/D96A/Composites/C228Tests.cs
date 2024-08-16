using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C228Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "X:m";

		var expected = new C228_TransportMeans()
		{
			TypeOfMeansOfTransportIdentification = "X",
			TypeOfMeansOfTransport = "m",
		};

		var actual = Map.MapComposite<C228_TransportMeans>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
