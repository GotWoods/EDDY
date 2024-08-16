using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C;

public class CCITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CCI+n+++2";

		var expected = new CCI_CharacteristicClassId()
		{
			ClassTypeCode = "n",
			MeasurementDetails = null,
			CharacteristicDescription = null,
			CharacteristicRelevanceCode = "2",
		};

		var actual = Map.MapObject<CCI_CharacteristicClassId>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
