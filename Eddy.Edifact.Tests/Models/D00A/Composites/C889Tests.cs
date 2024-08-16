using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C889Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "u:7:C:R:r";

		var expected = new C889_CharacteristicValue()
		{
			CharacteristicValueDescriptionCode = "u",
			CodeListIdentificationCode = "7",
			CodeListResponsibleAgencyCode = "C",
			CharacteristicValueDescription = "R",
			CharacteristicValueDescription2 = "r",
		};

		var actual = Map.MapComposite<C889_CharacteristicValue>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
