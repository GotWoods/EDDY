using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class RFFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "RFF+";

		var expected = new RFF_Reference()
		{
			Reference = null,
		};

		var actual = Map.MapObject<RFF_Reference>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredReference(string reference, bool isValidExpected)
	{
		var subject = new RFF_Reference();
		//Required fields
		//Test Parameters
		if (reference != "") 
			subject.Reference = new C506_Reference();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
