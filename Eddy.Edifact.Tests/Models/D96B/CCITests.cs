using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96B;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Tests.Models.D96B;

public class CCITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CCI+6+++M";

		var expected = new CCI_CharacteristicClassId()
		{
			PropertyClassCoded = "6",
			MeasurementDetails = null,
			ProductCharacteristic = null,
			CharacteristicRelevanceCoded = "M",
		};

		var actual = Map.MapObject<CCI_CharacteristicClassId>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
