using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97B;
using Eddy.Edifact.Models.D97B.Composites;

namespace Eddy.Edifact.Tests.Models.D97B.Composites;

public class E972Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "i:R:v:Q:N:F:x:d:c:B:i:A";

		var expected = new E972_MessageProcessingDetails()
		{
			BusinessFunctionCoded = "i",
			MessageFunctionCoded = "R",
			CodeListResponsibleAgencyCoded = "v",
			MessageFunctionCoded2 = "Q",
			MessageFunctionCoded3 = "N",
			MessageFunctionCoded4 = "F",
			MessageFunctionCoded5 = "x",
			MessageFunctionCoded6 = "d",
			MessageFunctionCoded7 = "c",
			MessageFunctionCoded8 = "B",
			MessageFunctionCoded9 = "i",
			MessageFunctionCoded10 = "A",
		};

		var actual = Map.MapComposite<E972_MessageProcessingDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
