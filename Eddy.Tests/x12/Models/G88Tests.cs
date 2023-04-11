using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G88Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G88*2q2Q4nIn*eNAafHdB*m*dAgaGcwP*U";

		var expected = new G88_DeliveryReturnIdentificationAdjustment()
		{
			PhysicalDeliveryOrReturnDate = "2q2Q4nIn",
			ProductOwnershipTransferDate = "eNAafHdB",
			PurchaseOrderNumber = "m",
			PurchaseOrderDate = "dAgaGcwP",
			ReceiversLocationNumber = "U",
		};

		var actual = Map.MapObject<G88_DeliveryReturnIdentificationAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
