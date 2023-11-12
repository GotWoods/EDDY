using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G89Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G89*4*9*EN*e3vE8vTddtto*Mn*M*MILe8UiIxjX4*5*5";

		var expected = new G89_LineItemDetailAdjustment()
		{
			DirectStoreDeliverySequenceNumber = 4,
			Quantity = 9,
			UnitOfMeasurementCode = "EN",
			UPCConsumerPackageCode = "e3vE8vTddtto",
			ProductServiceIDQualifier = "Mn",
			ProductServiceID = "M",
			UPCCaseCode = "MILe8UiIxjX4",
			ItemListCost = 5,
			Pack = 5,
		};

		var actual = Map.MapObject<G89_LineItemDetailAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
