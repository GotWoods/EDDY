using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C830Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "S:B:7:b";

		var expected = new C830_ProcessIdentificationDetails()
		{
			ProcessIdentification = "S",
			CodeListIdentificationCode = "B",
			CodeListResponsibleAgencyCode = "7",
			Process = "b",
		};

		var actual = Map.MapComposite<C830_ProcessIdentificationDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
