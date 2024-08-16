using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C012Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "f:f:C:P";

		var expected = new C012_ProcessingIndicator()
		{
			ProcessingIndicatorDescriptionCode = "f",
			CodeListIdentificationCode = "f",
			CodeListResponsibleAgencyCode = "C",
			ProcessingIndicatorDescription = "P",
		};

		var actual = Map.MapComposite<C012_ProcessingIndicator>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
