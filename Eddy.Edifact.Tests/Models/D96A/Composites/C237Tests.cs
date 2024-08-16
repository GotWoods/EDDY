using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C237Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "r:M:g:6";

		var expected = new C237_EquipmentIdentification()
		{
			EquipmentIdentificationNumber = "r",
			CodeListQualifier = "M",
			CodeListResponsibleAgencyCoded = "g",
			CountryCoded = "6",
		};

		var actual = Map.MapComposite<C237_EquipmentIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
