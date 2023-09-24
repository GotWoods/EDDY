using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G45Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G45*yc7gSQVgGiLv*YrrYYFmcQKXq*c*h*vT*1*1*4*Q1*EV*Wd31S7";

		var expected = new G45_LineItemDetailPromotion()
		{
			UPCCaseCode = "yc7gSQVgGiLv",
			UPCConsumerPackageCode = "YrrYYFmcQKXq",
			AllowanceOrChargeNumber = "c",
			ExceptionNumber = "h",
			ProductServiceIDQualifier = "vT",
			ProductServiceID = "1",
			Pack = 1,
			Size = 4,
			UnitOfMeasurementCode = "Q1",
			DateQualifier = "EV",
			Date = "Wd31S7",
		};

		var actual = Map.MapObject<G45_LineItemDetailPromotion>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
