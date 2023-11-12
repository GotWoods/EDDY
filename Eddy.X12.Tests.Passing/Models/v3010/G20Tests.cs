using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G20Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G20*7*7*QZ*6*6H*4*BC*d";

		var expected = new G20_ItemPackingDetail()
		{
			Pack = 7,
			Size = 7,
			UnitOfMeasurementCode = "QZ",
			Weight = 6,
			UnitOfMeasurementCode2 = "6H",
			Volume = 4,
			UnitOfMeasurementCode3 = "BC",
			Color = "d",
		};

		var actual = Map.MapObject<G20_ItemPackingDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
