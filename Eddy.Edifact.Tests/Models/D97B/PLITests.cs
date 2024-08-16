using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97B;
using Eddy.Edifact.Models.D97B.Composites;

namespace Eddy.Edifact.Tests.Models.D97B;

public class PLITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PLI+";

		var expected = new PLI_ProductLocationInformation()
		{
			GeographicDetails = null,
		};

		var actual = Map.MapObject<PLI_ProductLocationInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredGeographicDetails(string geographicDetails, bool isValidExpected)
	{
		var subject = new PLI_ProductLocationInformation();
		//Required fields
		//Test Parameters
		if (geographicDetails != "") 
			subject.GeographicDetails = new E008_GeographicDetails();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
