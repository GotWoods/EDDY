using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5020;

namespace Eddy.x12.Tests.Models.v5020;

public class G88Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G88*UJATyibd*TcZ6HsYl*U*QKATpNTQ*j";

		var expected = new G88_DeliveryReturnIdentificationAdjustment()
		{
			PhysicalDeliveryOrReturnDate = "UJATyibd",
			ProductOwnershipTransferDate = "TcZ6HsYl",
			PurchaseOrderNumber = "U",
			PurchaseOrderDate = "QKATpNTQ",
			ReceiversLocationNumber = "j",
		};

		var actual = Map.MapObject<G88_DeliveryReturnIdentificationAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
