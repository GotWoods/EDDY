using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class G88Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G88*ZbQWJYF4*OdRy8HEG*G*Q5j4NvKB*U";

		var expected = new G88_DeliveryReturnIdentificationAdjustment()
		{
			PhysicalDeliveryOrReturnDate = "ZbQWJYF4",
			ProductOwnershipTransferDate = "OdRy8HEG",
			PurchaseOrderNumber = "G",
			PurchaseOrderDate = "Q5j4NvKB",
			ReceiversLocationNumber = "U",
		};

		var actual = Map.MapObject<G88_DeliveryReturnIdentificationAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
