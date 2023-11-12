using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class N7BTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N7B*9*l*SB7*S9R*Bkh*D";

		var expected = new N7B_AdditionalEquipmentDetails()
		{
			NumberOfTankCompartments = 9,
			LoadingOrDischargeLocationCode = "l",
			VesselMaterialCode = "SB7",
			GasketTypeCode = "S9R",
			TrailerLiningTypeCode = "Bkh",
			ReferenceIdentification = "D",
		};

		var actual = Map.MapObject<N7B_AdditionalEquipmentDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
