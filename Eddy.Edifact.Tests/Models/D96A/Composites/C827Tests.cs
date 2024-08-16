using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C827Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "Q:E:u";

		var expected = new C827_TypeOfMarking()
		{
			TypeOfMarkingCoded = "Q",
			CodeListQualifier = "E",
			CodeListResponsibleAgencyCoded = "u",
		};

		var actual = Map.MapComposite<C827_TypeOfMarking>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredTypeOfMarkingCoded(string typeOfMarkingCoded, bool isValidExpected)
	{
		var subject = new C827_TypeOfMarking();
		//Required fields
		//Test Parameters
		subject.TypeOfMarkingCoded = typeOfMarkingCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
