using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C224Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "j:P:Q:m";

		var expected = new C224_EquipmentSizeAndType()
		{
			EquipmentSizeAndTypeDescriptionCode = "j",
			CodeListIdentificationCode = "P",
			CodeListResponsibleAgencyCode = "Q",
			EquipmentSizeAndTypeDescription = "m",
		};

		var actual = Map.MapComposite<C224_EquipmentSizeAndType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
