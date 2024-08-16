using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class CCITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CCI+A++";

		var expected = new CCI_CharacteristicClassId()
		{
			PropertyClassCoded = "A",
			MeasurementDetails = null,
			ProductCharacteristic = null,
		};

		var actual = Map.MapObject<CCI_CharacteristicClassId>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
