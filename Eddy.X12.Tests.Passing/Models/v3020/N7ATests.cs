using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class N7ATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N7A*IW*9*6*voE*8*1*N7*1r*bJ";

		var expected = new N7A_AccessorialEquipmentDetails()
		{
			LoadOrDeviceCode = "IW",
			Length = 9,
			Diameter = 6,
			HoseTypeCode = "voE",
			Diameter2 = 8,
			Diameter3 = 1,
			InletOrOutletMaterialTypeCode = "N7",
			InletOrOutletFittingTypeCode = "1r",
			MiscellaneousEquipmentCode = "bJ",
		};

		var actual = Map.MapObject<N7A_AccessorialEquipmentDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
