using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C944Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "w:g:v:B";

		var expected = new C944_MembershipStatus()
		{
			MembershipStatusDescriptionCode = "w",
			CodeListIdentificationCode = "g",
			CodeListResponsibleAgencyCode = "v",
			MembershipStatusDescription = "B",
		};

		var actual = Map.MapComposite<C944_MembershipStatus>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
