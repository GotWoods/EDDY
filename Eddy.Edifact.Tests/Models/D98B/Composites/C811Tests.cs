using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98B;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Tests.Models.D98B.Composites;

public class C811Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "f:l:Y:m";

		var expected = new C811_QuestionDetails()
		{
			QuestionCoded = "f",
			CodeListQualifier = "l",
			CodeListResponsibleAgencyCoded = "Y",
			Question = "m",
		};

		var actual = Map.MapComposite<C811_QuestionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
