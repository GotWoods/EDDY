using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C224Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "s:B:3:t";

		var expected = new C224_EquipmentSizeAndType()
		{
			EquipmentSizeAndTypeDescriptionCode = "s",
			CodeListIdentificationCode = "B",
			CodeListResponsibleAgencyCode = "3",
			EquipmentSizeAndTypeDescription = "t",
		};

		var actual = Map.MapComposite<C224_EquipmentSizeAndType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
