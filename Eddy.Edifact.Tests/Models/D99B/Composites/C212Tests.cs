using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C212Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "e:u:s:n";

		var expected = new C212_ItemNumberIdentification()
		{
			ItemNumber = "e",
			ItemTypeIdentificationCode = "u",
			CodeListIdentificationCode = "s",
			CodeListResponsibleAgencyCode = "n",
		};

		var actual = Map.MapComposite<C212_ItemNumberIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
