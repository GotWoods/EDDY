using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A;

public class TIFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "TIF++";

		var expected = new TIF_TravellerInformation()
		{
			TravellerSurnameAndRelatedInformation = null,
			TravellerDetails = null,
		};

		var actual = Map.MapObject<TIF_TravellerInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredTravellerSurnameAndRelatedInformation(string travellerSurnameAndRelatedInformation, bool isValidExpected)
	{
		var subject = new TIF_TravellerInformation();
		//Required fields
		//Test Parameters
		if (travellerSurnameAndRelatedInformation != "") 
			subject.TravellerSurnameAndRelatedInformation = new E985_TravellerSurnameAndRelatedInformation();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
