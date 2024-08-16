using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C237Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "7:M:E:d";

		var expected = new C237_EquipmentIdentification()
		{
			EquipmentIdentifier = "7",
			CodeListIdentificationCode = "M",
			CodeListResponsibleAgencyCode = "E",
			CountryNameCode = "d",
		};

		var actual = Map.MapComposite<C237_EquipmentIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
