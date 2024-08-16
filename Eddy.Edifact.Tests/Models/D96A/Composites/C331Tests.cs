using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C331Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "t:N:f:6:U";

		var expected = new C331_InsuranceCoverDetails()
		{
			InsuranceCoverIdentification = "t",
			CodeListQualifier = "N",
			CodeListResponsibleAgencyCoded = "f",
			InsuranceCover = "6",
			InsuranceCover2 = "U",
		};

		var actual = Map.MapComposite<C331_InsuranceCoverDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
