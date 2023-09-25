using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class W20Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W20*9*6*bG*9*Q*x*2*1*gM*9";

		var expected = new W20_LineItemDetailMiscellaneous()
		{
			Pack = 9,
			Size = 6,
			UnitOfMeasurementCode = "bG",
			Weight = 9,
			WeightQualifier = "Q",
			WeightUnitQualifier = "x",
			UnitWeight = 2,
			Volume = 1,
			UnitOfMeasurementCode2 = "gM",
			Color = "9",
		};

		var actual = Map.MapObject<W20_LineItemDetailMiscellaneous>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
