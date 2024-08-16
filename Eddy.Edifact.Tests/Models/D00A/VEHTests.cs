using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class VEHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "VEH+d+++C++q";

		var expected = new VEH_Vehicle()
		{
			EquipmentTypeCodeQualifier = "d",
			VehicleInformation = null,
			Dimensions = null,
			MeasurementValue = "C",
			Position = null,
			TravellerReferenceIdentifier = "q",
		};

		var actual = Map.MapObject<VEH_Vehicle>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
