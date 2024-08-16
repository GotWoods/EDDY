using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class E517Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "P:Y:2:f";

		var expected = new E517_LocationIdentification()
		{
			LocationNameCode = "P",
			CodeListIdentificationCode = "Y",
			CodeListResponsibleAgencyCode = "2",
			LocationName = "f",
		};

		var actual = Map.MapComposite<E517_LocationIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
