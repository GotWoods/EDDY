using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C945Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "A:3:J:6:N";

		var expected = new C945_MembershipLevel()
		{
			MembershipLevelCodeQualifier = "A",
			MembershipLevelDescriptionCode = "3",
			CodeListIdentificationCode = "J",
			CodeListResponsibleAgencyCode = "6",
			MembershipLevelDescription = "N",
		};

		var actual = Map.MapComposite<C945_MembershipLevel>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredMembershipLevelCodeQualifier(string membershipLevelCodeQualifier, bool isValidExpected)
	{
		var subject = new C945_MembershipLevel();
		//Required fields
		//Test Parameters
		subject.MembershipLevelCodeQualifier = membershipLevelCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
