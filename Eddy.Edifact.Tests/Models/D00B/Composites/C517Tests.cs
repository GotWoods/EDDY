using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C517Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "V:8:l:J";

		var expected = new C517_LocationIdentification()
		{
			LocationNameCode = "V",
			CodeListIdentificationCode = "8",
			CodeListResponsibleAgencyCode = "l",
			LocationName = "J",
		};

		var actual = Map.MapComposite<C517_LocationIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
