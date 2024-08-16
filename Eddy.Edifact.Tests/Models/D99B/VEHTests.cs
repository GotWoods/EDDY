using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class VEHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "VEH+S+++q++K";

		var expected = new VEH_Vehicle()
		{
			EquipmentTypeCodeQualifier = "S",
			VehicleInformation = null,
			Dimensions = null,
			MeasurementValue = "q",
			Position = null,
			TravellerReferenceNumber = "K",
		};

		var actual = Map.MapObject<VEH_Vehicle>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
