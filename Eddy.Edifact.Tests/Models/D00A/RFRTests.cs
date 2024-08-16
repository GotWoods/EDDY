using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class RFRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "RFR+";

		var expected = new RFR_Reference()
		{
			Reference = null,
		};

		var actual = Map.MapObject<RFR_Reference>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredReference(string reference, bool isValidExpected)
	{
		var subject = new RFR_Reference();
		//Required fields
		//Test Parameters
		if (reference != "") 
			subject.Reference = new E506_Reference();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
