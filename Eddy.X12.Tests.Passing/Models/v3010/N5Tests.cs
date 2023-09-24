using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class N5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N5*7247*71*29*B641*C*7*uo*1*tg";

		var expected = new N5_EquipmentOrdered()
		{
			EquipmentLength = 7247,
			WeightCapacity = 71,
			CubicCapacity = 29,
			CarTypeCode = "B641",
			MetricQualifier = "C",
			Height = 7,
			LadingPercentage = "uo",
			LadingPercentQualifier = "1",
			EquipmentDescriptionCode = "tg",
		};

		var actual = Map.MapObject<N5_EquipmentOrdered>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
