using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E994Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "x:k";

		var expected = new E994_StopoverInformation()
		{
			PlaceLocationIdentification = "x",
			NumberOfUnits = "k",
		};

		var actual = Map.MapComposite<E994_StopoverInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
