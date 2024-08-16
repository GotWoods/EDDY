using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E972Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "K:4:m";

		var expected = new E972_MessageProcessingDetails()
		{
			BusinessFunctionCoded = "K",
			MessageFunctionCoded = "4",
			CodeListResponsibleAgencyCoded = "m",
		};

		var actual = Map.MapComposite<E972_MessageProcessingDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
