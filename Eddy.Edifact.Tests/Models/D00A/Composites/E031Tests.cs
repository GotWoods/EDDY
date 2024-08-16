using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E031Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "C:8:K";

		var expected = new E031_MessageApplicationProductSpecification()
		{
			MessageFunctionCode = "C",
			ProcessDescriptionCode = "8",
			ProcessDescriptionCode2 = "K",
		};

		var actual = Map.MapComposite<E031_MessageApplicationProductSpecification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
