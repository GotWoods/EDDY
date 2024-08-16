using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C827Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "a:N:6";

		var expected = new C827_TypeOfMarking()
		{
			MarkingTypeCode = "a",
			CodeListIdentificationCode = "N",
			CodeListResponsibleAgencyCode = "6",
		};

		var actual = Map.MapComposite<C827_TypeOfMarking>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredMarkingTypeCode(string markingTypeCode, bool isValidExpected)
	{
		var subject = new C827_TypeOfMarking();
		//Required fields
		//Test Parameters
		subject.MarkingTypeCode = markingTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
