using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A;

public class ERITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ERI+";

		var expected = new ERI_ApplicationErrorInformation()
		{
			ApplicationErrorDetails = null,
		};

		var actual = Map.MapObject<ERI_ApplicationErrorInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredApplicationErrorDetails(string applicationErrorDetails, bool isValidExpected)
	{
		var subject = new ERI_ApplicationErrorInformation();
		//Required fields
		//Test Parameters
		if (applicationErrorDetails != "") 
			subject.ApplicationErrorDetails = new E901_ApplicationErrorDetails();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
