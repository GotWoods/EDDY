using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class N7BTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N7B*5*B*mr6*jr6*eeI*A";

		var expected = new N7B_AdditionalEquipmentDetails()
		{
			NumberOfTankCompartments = 5,
			LoadingOrDischargeLocationCode = "B",
			VesselMaterialCode = "mr6",
			GasketTypeCode = "jr6",
			TrailerLiningTypeCode = "eeI",
			ReferenceIdentification = "A",
		};

		var actual = Map.MapObject<N7B_AdditionalEquipmentDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
