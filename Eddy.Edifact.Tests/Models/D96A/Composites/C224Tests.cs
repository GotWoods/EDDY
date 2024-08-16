using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C224Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "5:F:q:J";

		var expected = new C224_EquipmentSizeAndType()
		{
			EquipmentSizeAndTypeIdentification = "5",
			CodeListQualifier = "F",
			CodeListResponsibleAgencyCoded = "q",
			EquipmentSizeAndType = "J",
		};

		var actual = Map.MapComposite<C224_EquipmentSizeAndType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
