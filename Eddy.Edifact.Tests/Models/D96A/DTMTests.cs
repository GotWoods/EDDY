using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class DTMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "DTM+";

		var expected = new DTM_DateTimePeriod()
		{
			DateTimePeriod = null,
		};

		var actual = Map.MapObject<DTM_DateTimePeriod>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new DTM_DateTimePeriod();
		//Required fields
		//Test Parameters
		if (dateTimePeriod != "") 
			subject.DateTimePeriod = new C507_DateTimePeriod();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
