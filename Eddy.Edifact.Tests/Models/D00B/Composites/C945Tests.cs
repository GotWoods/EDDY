using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C945Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "L:M:S:0:j";

		var expected = new C945_MembershipLevel()
		{
			MembershipLevelCodeQualifier = "L",
			MembershipLevelDescriptionCode = "M",
			CodeListIdentificationCode = "S",
			CodeListResponsibleAgencyCode = "0",
			MembershipLevelDescription = "j",
		};

		var actual = Map.MapComposite<C945_MembershipLevel>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredMembershipLevelCodeQualifier(string membershipLevelCodeQualifier, bool isValidExpected)
	{
		var subject = new C945_MembershipLevel();
		//Required fields
		//Test Parameters
		subject.MembershipLevelCodeQualifier = membershipLevelCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
