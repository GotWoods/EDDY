using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C977Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "A:r:q:I";

		var expected = new C977_PeriodDetail()
		{
			PeriodDetailDescriptionCode = "A",
			CodeListIdentificationCode = "r",
			CodeListResponsibleAgencyCode = "q",
			PeriodDetailDescription = "I",
		};

		var actual = Map.MapComposite<C977_PeriodDetail>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
