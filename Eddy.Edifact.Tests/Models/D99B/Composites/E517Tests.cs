using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E517Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "7:W:J:B";

		var expected = new E517_LocationIdentification()
		{
			LocationNameCode = "7",
			CodeListIdentificationCode = "W",
			CodeListResponsibleAgencyCode = "J",
			LocationName = "B",
		};

		var actual = Map.MapComposite<E517_LocationIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
