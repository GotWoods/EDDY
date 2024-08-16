using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C585Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "D:8:n:Z";

		var expected = new C585_PriorityDetails()
		{
			PriorityDescriptionCode = "D",
			CodeListIdentificationCode = "8",
			CodeListResponsibleAgencyCode = "n",
			PriorityDescription = "Z",
		};

		var actual = Map.MapComposite<C585_PriorityDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
