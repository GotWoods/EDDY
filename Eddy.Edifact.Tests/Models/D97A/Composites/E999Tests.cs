using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E999Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "D:L:ILl0";

		var expected = new E999_ConnectionDetails()
		{
			PlaceLocationIdentification = "D",
			PartyName = "L",
			Time = "ILl0",
		};

		var actual = Map.MapComposite<E999_ConnectionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
