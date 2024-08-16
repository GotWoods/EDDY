using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A;

public class VEHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "VEH+n+++2++n";

		var expected = new VEH_Vehicle()
		{
			EquipmentQualifier = "n",
			VehicleInformation = null,
			Dimensions = null,
			MeasurementValue = "2",
			Position = null,
			TravellerReferenceNumber = "n",
		};

		var actual = Map.MapObject<VEH_Vehicle>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
