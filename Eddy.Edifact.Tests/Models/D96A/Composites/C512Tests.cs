using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C512Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "d:I";

		var expected = new C512_SizeDetails()
		{
			SizeQualifier = "d",
			Size = "I",
		};

		var actual = Map.MapComposite<C512_SizeDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
