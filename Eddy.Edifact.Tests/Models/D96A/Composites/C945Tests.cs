using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C945Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "F:j:2:T:a";

		var expected = new C945_MembershipLevel()
		{
			MembershipLevelQualifier = "F",
			MembershipLevelIdentification = "j",
			CodeListQualifier = "2",
			CodeListResponsibleAgencyCoded = "T",
			MembershipLevel = "a",
		};

		var actual = Map.MapComposite<C945_MembershipLevel>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredMembershipLevelQualifier(string membershipLevelQualifier, bool isValidExpected)
	{
		var subject = new C945_MembershipLevel();
		//Required fields
		//Test Parameters
		subject.MembershipLevelQualifier = membershipLevelQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
