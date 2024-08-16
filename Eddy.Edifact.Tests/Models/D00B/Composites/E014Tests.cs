using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class E014Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "w:L";

		var expected = new E014_TimeReferenceDetails()
		{
			ReferenceIdentifier = "w",
			ReferenceCodeQualifier = "L",
		};

		var actual = Map.MapComposite<E014_TimeReferenceDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
