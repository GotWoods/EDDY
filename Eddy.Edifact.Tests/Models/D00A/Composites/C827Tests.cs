using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C827Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "M:7:L";

		var expected = new C827_TypeOfMarking()
		{
			MarkingTypeCode = "M",
			CodeListIdentificationCode = "7",
			CodeListResponsibleAgencyCode = "L",
		};

		var actual = Map.MapComposite<C827_TypeOfMarking>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredMarkingTypeCode(string markingTypeCode, bool isValidExpected)
	{
		var subject = new C827_TypeOfMarking();
		//Required fields
		//Test Parameters
		subject.MarkingTypeCode = markingTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
