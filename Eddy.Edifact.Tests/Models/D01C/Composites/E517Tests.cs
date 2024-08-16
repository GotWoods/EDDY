using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class E517Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "O:Y:Z:0";

		var expected = new E517_LocationIdentification()
		{
			LocationNameCode = "O",
			CodeListIdentificationCode = "Y",
			CodeListResponsibleAgencyCode = "Z",
			LocationName = "0",
		};

		var actual = Map.MapComposite<E517_LocationIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
