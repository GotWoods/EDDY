using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class C517Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "y:k:G:t";

		var expected = new C517_LocationIdentification()
		{
			LocationNameCode = "y",
			CodeListIdentificationCode = "k",
			CodeListResponsibleAgencyCode = "G",
			LocationName = "t",
		};

		var actual = Map.MapComposite<C517_LocationIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
