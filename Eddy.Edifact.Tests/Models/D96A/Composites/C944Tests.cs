using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C944Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "x:b:Q:I";

		var expected = new C944_MembershipStatus()
		{
			MembershipStatusCoded = "x",
			CodeListQualifier = "b",
			CodeListResponsibleAgencyCoded = "Q",
			MembershipStatus = "I",
		};

		var actual = Map.MapComposite<C944_MembershipStatus>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
