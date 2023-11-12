using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class N7BTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N7B*5*i*cmS*IRR*xEQ*g";

		var expected = new N7B_AdditionalEquipmentDetails()
		{
			NumberOfTankCompartments = 5,
			LoadingOrDischargeLocationCode = "i",
			VesselMaterialCode = "cmS",
			GasketTypeCode = "IRR",
			TrailerLiningTypeCode = "xEQ",
			ReferenceIdentification = "g",
		};

		var actual = Map.MapObject<N7B_AdditionalEquipmentDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
