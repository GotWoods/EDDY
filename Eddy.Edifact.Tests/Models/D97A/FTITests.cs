using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A;

public class FTITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "FTI+";

		var expected = new FTI_FrequentTravellerInformation()
		{
			FrequentTravellerIdentification = null,
		};

		var actual = Map.MapObject<FTI_FrequentTravellerInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredFrequentTravellerIdentification(string frequentTravellerIdentification, bool isValidExpected)
	{
		var subject = new FTI_FrequentTravellerInformation();
		//Required fields
		//Test Parameters
		if (frequentTravellerIdentification != "") 
			subject.FrequentTravellerIdentification = new E970_FrequentTravellerIdentification();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
