using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class N7BTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N7B*4*q*cXF*fw1*G3D*r";

		var expected = new N7B_AdditionalEquipmentDetails()
		{
			NumberOfTankCompartments = 4,
			LoadingOrDischargeLocationCode = "q",
			VesselMaterialCode = "cXF",
			GasketTypeCode = "fw1",
			TrailerLiningTypeCode = "G3D",
			ReferenceNumber = "r",
		};

		var actual = Map.MapObject<N7B_AdditionalEquipmentDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
