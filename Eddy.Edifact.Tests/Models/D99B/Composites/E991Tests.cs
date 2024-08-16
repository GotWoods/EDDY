using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E991Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "k:E";

		var expected = new E991_VehicleInformation()
		{
			EquipmentSizeAndTypeDescription = "k",
			ObjectIdentifier = "E",
		};

		var actual = Map.MapComposite<E991_VehicleInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
