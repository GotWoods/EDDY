using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C212Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "7:f:I:P";

		var expected = new C212_ItemNumberIdentification()
		{
			ItemIdentifier = "7",
			ItemTypeIdentificationCode = "f",
			CodeListIdentificationCode = "I",
			CodeListResponsibleAgencyCode = "P",
		};

		var actual = Map.MapComposite<C212_ItemNumberIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
