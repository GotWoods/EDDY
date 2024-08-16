using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97B;
using Eddy.Edifact.Models.D97B.Composites;

namespace Eddy.Edifact.Tests.Models.D97B;

public class TRFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "TRF+";

		var expected = new TRF_TrafficRestrictionDetails()
		{
			TrafficRestrictionDetails = null,
		};

		var actual = Map.MapObject<TRF_TrafficRestrictionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredTrafficRestrictionDetails(string trafficRestrictionDetails, bool isValidExpected)
	{
		var subject = new TRF_TrafficRestrictionDetails();
		//Required fields
		//Test Parameters
		if (trafficRestrictionDetails != "") 
			subject.TrafficRestrictionDetails = new E007_TrafficRestrictionDetails();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
