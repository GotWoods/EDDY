using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C944Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "S:2:z:E";

		var expected = new C944_MembershipStatus()
		{
			MembershipStatusCoded = "S",
			CodeListIdentificationCode = "2",
			CodeListResponsibleAgencyCode = "z",
			MembershipStatus = "E",
		};

		var actual = Map.MapComposite<C944_MembershipStatus>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
