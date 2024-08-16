using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A.Composites;

public class C237Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "U:Q:u:P";

		var expected = new C237_EquipmentIdentification()
		{
			EquipmentIdentifier = "U",
			CodeListIdentificationCode = "Q",
			CodeListResponsibleAgencyCode = "u",
			CountryIdentifier = "P",
		};

		var actual = Map.MapComposite<C237_EquipmentIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
