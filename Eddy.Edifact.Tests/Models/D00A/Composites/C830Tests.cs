using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C830Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "v:c:M:I";

		var expected = new C830_ProcessIdentificationDetails()
		{
			ProcessDescriptionCode = "v",
			CodeListIdentificationCode = "c",
			CodeListResponsibleAgencyCode = "M",
			ProcessDescription = "I",
		};

		var actual = Map.MapComposite<C830_ProcessIdentificationDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
