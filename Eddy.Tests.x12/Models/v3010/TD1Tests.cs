using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class TD1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TD1*JGaOT*3*t*U*U*i*4*tD";

		var expected = new TD1_CarrierDetailsQuantityAndWeight()
		{
			PackagingCode = "JGaOT",
			LadingQuantity = 3,
			CommodityCodeQualifier = "t",
			CommodityCode = "U",
			LadingDescription = "U",
			WeightQualifier = "i",
			Weight = 4,
			UnitOfMeasurementCode = "tD",
		};

		var actual = Map.MapObject<TD1_CarrierDetailsQuantityAndWeight>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
