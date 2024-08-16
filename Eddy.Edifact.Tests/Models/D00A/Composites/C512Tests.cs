using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C512Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "r:f";

		var expected = new C512_SizeDetails()
		{
			SizeTypeCodeQualifier = "r",
			SizeValue = "f",
		};

		var actual = Map.MapComposite<C512_SizeDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
