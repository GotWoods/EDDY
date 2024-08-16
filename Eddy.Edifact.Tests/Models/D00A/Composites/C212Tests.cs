using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C212Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "3:E:9:9";

		var expected = new C212_ItemNumberIdentification()
		{
			ItemIdentifier = "3",
			ItemTypeIdentificationCode = "E",
			CodeListIdentificationCode = "9",
			CodeListResponsibleAgencyCode = "9",
		};

		var actual = Map.MapComposite<C212_ItemNumberIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
