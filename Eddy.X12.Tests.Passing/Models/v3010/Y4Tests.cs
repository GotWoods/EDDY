using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class Y4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Y4*A*t*DUKiRk*uNc6AI*1*3alM*Wy";

		var expected = new Y4_ContainerRelease()
		{
			BookingNumber = "A",
			BookingNumber2 = "t",
			ContainerAvailabilityDate = "DUKiRk",
			StandardPointLocationCode = "uNc6AI",
			NumberOfContainers = 1,
			EquipmentType = "3alM",
			StandardCarrierAlphaCode = "Wy",
		};

		var actual = Map.MapObject<Y4_ContainerRelease>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
