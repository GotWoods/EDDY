using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C889Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "G:X:v:X:m";

		var expected = new C889_CharacteristicValue()
		{
			CharacteristicValueCoded = "G",
			CodeListQualifier = "X",
			CodeListResponsibleAgencyCoded = "v",
			CharacteristicValue = "X",
			CharacteristicValue2 = "m",
		};

		var actual = Map.MapComposite<C889_CharacteristicValue>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
