using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C;

public class VEHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "VEH+v+++C++A";

		var expected = new VEH_Vehicle()
		{
			EquipmentTypeCodeQualifier = "v",
			VehicleInformation = null,
			Dimensions = null,
			Measure = "C",
			Position = null,
			TravellerReferenceIdentifier = "A",
		};

		var actual = Map.MapObject<VEH_Vehicle>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
