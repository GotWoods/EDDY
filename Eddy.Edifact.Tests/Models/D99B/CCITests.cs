using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class CCITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CCI+S+++N";

		var expected = new CCI_CharacteristicClassId()
		{
			ClassTypeCode = "S",
			MeasurementDetails = null,
			ProductCharacteristic = null,
			CharacteristicRelevanceCoded = "N",
		};

		var actual = Map.MapObject<CCI_CharacteristicClassId>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
