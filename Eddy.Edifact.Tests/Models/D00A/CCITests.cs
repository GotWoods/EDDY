using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class CCITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CCI+Z+++O";

		var expected = new CCI_CharacteristicClassId()
		{
			ClassTypeCode = "Z",
			MeasurementDetails = null,
			ProductCharacteristic = null,
			CharacteristicRelevanceCode = "O",
		};

		var actual = Map.MapObject<CCI_CharacteristicClassId>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
