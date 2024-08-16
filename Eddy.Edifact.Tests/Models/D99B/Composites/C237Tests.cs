using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C237Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "2:P:y:T";

		var expected = new C237_EquipmentIdentification()
		{
			EquipmentIdentificationNumber = "2",
			CodeListIdentificationCode = "P",
			CodeListResponsibleAgencyCode = "y",
			CountryNameCode = "T",
		};

		var actual = Map.MapComposite<C237_EquipmentIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
