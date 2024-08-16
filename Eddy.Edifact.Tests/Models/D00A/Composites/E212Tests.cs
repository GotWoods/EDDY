using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E212Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "p:w:6:1";

		var expected = new E212_ItemNumberIdentification()
		{
			ItemIdentifier = "p",
			ItemTypeIdentificationCode = "w",
			CodeListIdentificationCode = "6",
			CodeListResponsibleAgencyCode = "1",
		};

		var actual = Map.MapComposite<E212_ItemNumberIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
