using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C977Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "O:b:V:m";

		var expected = new C977_PeriodDetail()
		{
			PeriodDetailDescriptionCode = "O",
			CodeListIdentificationCode = "b",
			CodeListResponsibleAgencyCode = "V",
			PeriodDetailDescription = "m",
		};

		var actual = Map.MapComposite<C977_PeriodDetail>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
