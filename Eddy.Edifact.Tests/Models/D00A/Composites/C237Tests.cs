using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C237Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "Z:c:A:z";

		var expected = new C237_EquipmentIdentification()
		{
			EquipmentIdentifier = "Z",
			CodeListIdentificationCode = "c",
			CodeListResponsibleAgencyCode = "A",
			CountryNameCode = "z",
		};

		var actual = Map.MapComposite<C237_EquipmentIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
