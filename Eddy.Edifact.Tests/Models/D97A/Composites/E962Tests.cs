using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E962Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "5:e:O";

		var expected = new E962_TerminalInformation()
		{
			GateIdentification = "5",
			RelatedPlaceLocationOneIdentification = "e",
			RelatedPlaceLocationOneIdentification2 = "O",
		};

		var actual = Map.MapComposite<E962_TerminalInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
