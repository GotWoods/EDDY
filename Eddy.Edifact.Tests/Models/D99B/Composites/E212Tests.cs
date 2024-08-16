using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E212Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "x:P:N:q";

		var expected = new E212_ItemNumberIdentification()
		{
			ItemNumber = "x",
			ItemTypeIdentificationCode = "P",
			CodeListIdentificationCode = "N",
			CodeListResponsibleAgencyCode = "q",
		};

		var actual = Map.MapComposite<E212_ItemNumberIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
