using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97B;
using Eddy.Edifact.Models.D97B.Composites;

namespace Eddy.Edifact.Tests.Models.D97B;

public class POCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "POC+";

		var expected = new POC_PurposeOfConveyanceCall()
		{
			PurposeOfConveyanceCall = null,
		};

		var actual = Map.MapObject<POC_PurposeOfConveyanceCall>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredPurposeOfConveyanceCall(string purposeOfConveyanceCall, bool isValidExpected)
	{
		var subject = new POC_PurposeOfConveyanceCall();
		//Required fields
		//Test Parameters
		if (purposeOfConveyanceCall != "") 
			subject.PurposeOfConveyanceCall = new C525_PurposeOfConveyanceCall();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
