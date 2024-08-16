using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C702Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "3:S:X";

		var expected = new C702_CodeSetIdentification()
		{
			SimpleDataElementTag = "3",
			CodeListQualifier = "S",
			CodeListResponsibleAgencyCoded = "X",
		};

		var actual = Map.MapComposite<C702_CodeSetIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
