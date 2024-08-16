using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97B;
using Eddy.Edifact.Models.D97B.Composites;

namespace Eddy.Edifact.Tests.Models.D97B;

public class RTITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "RTI+";

		var expected = new RTI_RateDetails()
		{
			RateClassDetails = null,
		};

		var actual = Map.MapObject<RTI_RateDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredRateClassDetails(string rateClassDetails, bool isValidExpected)
	{
		var subject = new RTI_RateDetails();
		//Required fields
		//Test Parameters
		if (rateClassDetails != "") 
			subject.RateClassDetails = new E011_RateClassDetails();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
