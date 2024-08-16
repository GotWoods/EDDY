using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class E212Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "Y:7:1:H";

		var expected = new E212_ItemNumberIdentification()
		{
			ItemIdentifier = "Y",
			ItemTypeIdentificationCode = "7",
			CodeListIdentificationCode = "1",
			CodeListResponsibleAgencyCode = "H",
		};

		var actual = Map.MapComposite<E212_ItemNumberIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
