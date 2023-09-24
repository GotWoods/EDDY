using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G88Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G88*QE9KAY*cBTkvv*8*vlyUfx*q";

		var expected = new G88_DeliveryReturnIdentificationAdjustment()
		{
			PhysicalDeliveryOrReturnDate = "QE9KAY",
			ProductOwnershipTransferDate = "cBTkvv",
			PurchaseOrderNumber = "8",
			PurchaseOrderDate = "vlyUfx",
			ReceiversLocationNumber = "q",
		};

		var actual = Map.MapObject<G88_DeliveryReturnIdentificationAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
