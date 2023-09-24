using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class V4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "V4*V";

		var expected = new V4_CargoLocationReference()
		{
			VesselStowageLocation = "V",
		};

		var actual = Map.MapObject<V4_CargoLocationReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredVesselStowageLocation(string vesselStowageLocation, bool isValidExpected)
	{
		var subject = new V4_CargoLocationReference();
		subject.VesselStowageLocation = vesselStowageLocation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
