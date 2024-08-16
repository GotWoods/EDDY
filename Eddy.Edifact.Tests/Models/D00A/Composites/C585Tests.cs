using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C585Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "0:c:2:5";

		var expected = new C585_PriorityDetails()
		{
			PriorityDescriptionCode = "0",
			CodeListIdentificationCode = "c",
			CodeListResponsibleAgencyCode = "2",
			PriorityDescription = "5",
		};

		var actual = Map.MapComposite<C585_PriorityDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
