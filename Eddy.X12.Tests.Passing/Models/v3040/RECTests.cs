using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class RECTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "REC*pJ*uZ*B*b*4";

		var expected = new REC_RealEstateCondition()
		{
			OccupancyCode = "pJ",
			RealEstatePropertyConditionCode = "uZ",
			PropertyDamageCode = "B",
			YesNoConditionOrResponseCode = "b",
			Quantity = 4,
		};

		var actual = Map.MapObject<REC_RealEstateCondition>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("pJ", true)]
	public void Validation_RequiredOccupancyCode(string occupancyCode, bool isValidExpected)
	{
		var subject = new REC_RealEstateCondition();
		//Required fields
		//Test Parameters
		subject.OccupancyCode = occupancyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
