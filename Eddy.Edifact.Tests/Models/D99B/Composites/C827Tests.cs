using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C827Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "U:7:8";

		var expected = new C827_TypeOfMarking()
		{
			TypeOfMarkingCoded = "U",
			CodeListIdentificationCode = "7",
			CodeListResponsibleAgencyCode = "8",
		};

		var actual = Map.MapComposite<C827_TypeOfMarking>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredTypeOfMarkingCoded(string typeOfMarkingCoded, bool isValidExpected)
	{
		var subject = new C827_TypeOfMarking();
		//Required fields
		//Test Parameters
		subject.TypeOfMarkingCoded = typeOfMarkingCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
