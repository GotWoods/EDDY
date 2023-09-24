using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G80Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G80*J*6*5";

		var expected = new G80_ShippingInformation()
		{
			StoreNumber = "J",
			EquipmentNumber = "6",
			StopSequenceNumber = 5,
		};

		var actual = Map.MapObject<G80_ShippingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
