using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C830Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "C:u:5:n";

		var expected = new C830_ProcessIdentificationDetails()
		{
			ProcessDescriptionCode = "C",
			CodeListIdentificationCode = "u",
			CodeListResponsibleAgencyCode = "5",
			ProcessDescription = "n",
		};

		var actual = Map.MapComposite<C830_ProcessIdentificationDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
