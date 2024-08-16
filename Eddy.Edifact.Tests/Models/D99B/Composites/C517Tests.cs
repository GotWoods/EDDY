using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C517Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "X:P:4:u";

		var expected = new C517_LocationIdentification()
		{
			LocationNameCode = "X",
			CodeListIdentificationCode = "P",
			CodeListResponsibleAgencyCode = "4",
			LocationName = "u",
		};

		var actual = Map.MapComposite<C517_LocationIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
