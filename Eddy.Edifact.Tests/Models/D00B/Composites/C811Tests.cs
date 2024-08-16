using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C811Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "A:i:n:F";

		var expected = new C811_QuestionDetails()
		{
			QuestionDescriptionCode = "A",
			CodeListIdentificationCode = "i",
			CodeListResponsibleAgencyCode = "n",
			QuestionDescription = "F",
		};

		var actual = Map.MapComposite<C811_QuestionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
