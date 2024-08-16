using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96B;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Tests.Models.D96B.Composites;

public class C830Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "p:P:S:5";

		var expected = new C830_ProcessIdentificationDetails()
		{
			ProcessIdentification = "p",
			CodeListQualifier = "P",
			CodeListResponsibleAgencyCoded = "S",
			Process = "5",
		};

		var actual = Map.MapComposite<C830_ProcessIdentificationDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
