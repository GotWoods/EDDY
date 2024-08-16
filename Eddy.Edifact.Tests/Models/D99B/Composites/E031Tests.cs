using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E031Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "9:4:n";

		var expected = new E031_MessageApplicationProductSpecification()
		{
			MessageFunctionCode = "9",
			ProcessIdentification = "4",
			ProcessIdentification2 = "n",
		};

		var actual = Map.MapComposite<E031_MessageApplicationProductSpecification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
