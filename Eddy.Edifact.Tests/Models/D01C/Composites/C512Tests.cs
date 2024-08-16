using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class C512Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "E:a";

		var expected = new C512_SizeDetails()
		{
			SizeTypeCodeQualifier = "E",
			SizeMeasure = "a",
		};

		var actual = Map.MapComposite<C512_SizeDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
