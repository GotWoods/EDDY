using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C811Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "3:c:Z:q";

		var expected = new C811_QuestionDetails()
		{
			QuestionCoded = "3",
			CodeListIdentificationCode = "c",
			CodeListResponsibleAgencyCode = "Z",
			Question = "q",
		};

		var actual = Map.MapComposite<C811_QuestionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
