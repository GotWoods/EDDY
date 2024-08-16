using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C012Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "L:d:U:k";

		var expected = new C012_ProcessingIndicator()
		{
			ProcessingIndicatorDescriptionCode = "L",
			CodeListIdentificationCode = "d",
			CodeListResponsibleAgencyCode = "U",
			ProcessingIndicatorDescription = "k",
		};

		var actual = Map.MapComposite<C012_ProcessingIndicator>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
