using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class UNSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "UNS+o";

		var expected = new UNS_SectionControl()
		{
			SectionIdentification = "o",
		};

		var actual = Map.MapObject<UNS_SectionControl>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredSectionIdentification(string sectionIdentification, bool isValidExpected)
	{
		var subject = new UNS_SectionControl();
		//Required fields
		//Test Parameters
		subject.SectionIdentification = sectionIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
