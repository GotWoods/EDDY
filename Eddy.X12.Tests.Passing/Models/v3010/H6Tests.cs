using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class H6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "H6*Rw*cC*4*p*1*h";

		var expected = new H6_SpecialServices()
		{
			SpecialServicesCode = "Rw",
			SpecialServicesCode2 = "cC",
			QuantityOfPalletsShipped = 4,
			PalletExchangeCode = "p",
			Weight = 1,
			WeightUnitQualifier = "h",
		};

		var actual = Map.MapObject<H6_SpecialServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
