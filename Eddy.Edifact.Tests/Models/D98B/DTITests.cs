using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98B;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Tests.Models.D98B;

public class DTITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "DTI++";

		var expected = new DTI_DateAndTimeInformation()
		{
			DateAndTimeInformation = null,
			TimeReferenceDetails = null,
		};

		var actual = Map.MapObject<DTI_DateAndTimeInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredDateAndTimeInformation(string dateAndTimeInformation, bool isValidExpected)
	{
		var subject = new DTI_DateAndTimeInformation();
		//Required fields
		//Test Parameters
		if (dateAndTimeInformation != "") 
			subject.DateAndTimeInformation = new E013_DateAndTimeInformation();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
