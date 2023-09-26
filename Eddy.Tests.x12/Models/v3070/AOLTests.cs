using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class AOLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AOL*3T*6*K*A*E*5*C*7o";

		var expected = new AOL_AnimalObservationLocation()
		{
			ObservationTypeCode = "3T",
			Description = "6",
			TissueOrSpecimenDispositionCode = "K",
			YesNoConditionOrResponseCode = "A",
			SubLocation = "E",
			SubLocation2 = "5",
			SubLocation3 = "C",
			SurfaceLayerPositionCode = "7o",
		};

		var actual = Map.MapObject<AOL_AnimalObservationLocation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3T", true)]
	public void Validation_RequiredObservationTypeCode(string observationTypeCode, bool isValidExpected)
	{
		var subject = new AOL_AnimalObservationLocation();
		//Required fields
		subject.Description = "6";
		//Test Parameters
		subject.ObservationTypeCode = observationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredDescription(string description, bool isValidExpected)
	{
		var subject = new AOL_AnimalObservationLocation();
		//Required fields
		subject.ObservationTypeCode = "3T";
		//Test Parameters
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
