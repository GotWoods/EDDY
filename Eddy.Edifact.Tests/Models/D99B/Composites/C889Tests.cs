using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C889Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "I:v:x:L:j";

		var expected = new C889_CharacteristicValue()
		{
			CharacteristicValueCoded = "I",
			CodeListIdentificationCode = "v",
			CodeListResponsibleAgencyCode = "x",
			CharacteristicValue = "L",
			CharacteristicValue2 = "j",
		};

		var actual = Map.MapComposite<C889_CharacteristicValue>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
