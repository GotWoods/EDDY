using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C811Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "W:1:5:6";

		var expected = new C811_QuestionDetails()
		{
			QuestionDescriptionCode = "W",
			CodeListIdentificationCode = "1",
			CodeListResponsibleAgencyCode = "5",
			QuestionDescription = "6",
		};

		var actual = Map.MapComposite<C811_QuestionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
