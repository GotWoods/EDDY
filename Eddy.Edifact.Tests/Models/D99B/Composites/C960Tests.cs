using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C960Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "L:o:n:v";

		var expected = new C960_ReasonForChange()
		{
			ChangeReasonDescriptionCode = "L",
			CodeListIdentificationCode = "o",
			CodeListResponsibleAgencyCode = "n",
			ChangeReasonDescription = "v",
		};

		var actual = Map.MapComposite<C960_ReasonForChange>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
