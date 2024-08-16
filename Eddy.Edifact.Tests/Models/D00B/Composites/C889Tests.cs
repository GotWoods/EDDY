using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C889Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "O:l:F:c:9";

		var expected = new C889_CharacteristicValue()
		{
			CharacteristicValueDescriptionCode = "O",
			CodeListIdentificationCode = "l",
			CodeListResponsibleAgencyCode = "F",
			CharacteristicValueDescription = "c",
			CharacteristicValueDescription2 = "9",
		};

		var actual = Map.MapComposite<C889_CharacteristicValue>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
