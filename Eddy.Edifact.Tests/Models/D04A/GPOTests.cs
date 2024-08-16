using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D04A;
using Eddy.Edifact.Models.D04A.Composites;

namespace Eddy.Edifact.Tests.Models.D04A;

public class GPOTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "GPO+R+r+u+f";

		var expected = new GPO_GeographicalPosition()
		{
			GeographicalPositionCodeQualifier = "R",
			LatitudeDegree = "r",
			LongitudeDegree = "u",
			Altitude = "f",
		};

		var actual = Map.MapObject<GPO_GeographicalPosition>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredGeographicalPositionCodeQualifier(string geographicalPositionCodeQualifier, bool isValidExpected)
	{
		var subject = new GPO_GeographicalPosition();
		//Required fields
		//Test Parameters
		subject.GeographicalPositionCodeQualifier = geographicalPositionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
