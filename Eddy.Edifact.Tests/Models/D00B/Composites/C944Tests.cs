using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C944Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "m:N:3:k";

		var expected = new C944_MembershipStatus()
		{
			MembershipStatusDescriptionCode = "m",
			CodeListIdentificationCode = "N",
			CodeListResponsibleAgencyCode = "3",
			MembershipStatusDescription = "k",
		};

		var actual = Map.MapComposite<C944_MembershipStatus>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
