using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class S017Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "Y:v:C:i";

		var expected = new S017_MessageImplementationGuidelineIdentification()
		{
			MessageImplementationGuidelineIdentification = "Y",
			MessageImplementationGuidelineVersionNumber = "v",
			MessageImplementationGuidelineReleaseNumber = "C",
			ControllingAgencyCoded = "i",
		};

		var actual = Map.MapComposite<S017_MessageImplementationGuidelineIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredMessageImplementationGuidelineIdentification(string messageImplementationGuidelineIdentification, bool isValidExpected)
	{
		var subject = new S017_MessageImplementationGuidelineIdentification();
		//Required fields
		//Test Parameters
		subject.MessageImplementationGuidelineIdentification = messageImplementationGuidelineIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
