using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A.Composites;

public class C517Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "d:6:O:i";

		var expected = new C517_LocationIdentification()
		{
			LocationIdentifier = "d",
			CodeListIdentificationCode = "6",
			CodeListResponsibleAgencyCode = "O",
			LocationName = "i",
		};

		var actual = Map.MapComposite<C517_LocationIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
