using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C945Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "w:2:O:1:R";

		var expected = new C945_MembershipLevel()
		{
			MembershipLevelQualifier = "w",
			MembershipLevelIdentification = "2",
			CodeListIdentificationCode = "O",
			CodeListResponsibleAgencyCode = "1",
			MembershipLevel = "R",
		};

		var actual = Map.MapComposite<C945_MembershipLevel>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredMembershipLevelQualifier(string membershipLevelQualifier, bool isValidExpected)
	{
		var subject = new C945_MembershipLevel();
		//Required fields
		//Test Parameters
		subject.MembershipLevelQualifier = membershipLevelQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
