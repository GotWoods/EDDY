using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class V4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "V4*y";

		var expected = new V4_CargoLocationReference()
		{
			VesselStowageLocation = "y",
		};

		var actual = Map.MapObject<V4_CargoLocationReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredVesselStowageLocation(string vesselStowageLocation, bool isValidExpected)
	{
		var subject = new V4_CargoLocationReference();
		//Required fields
		//Test Parameters
		subject.VesselStowageLocation = vesselStowageLocation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
