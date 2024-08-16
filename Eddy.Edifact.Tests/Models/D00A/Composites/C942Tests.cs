using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C942Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "j:B:8:X";

		var expected = new C942_MembershipCategory()
		{
			MembershipCategoryDescriptionCode = "j",
			CodeListIdentificationCode = "B",
			CodeListResponsibleAgencyCode = "8",
			MembershipCategoryDescription = "X",
		};

		var actual = Map.MapComposite<C942_MembershipCategory>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredMembershipCategoryDescriptionCode(string membershipCategoryDescriptionCode, bool isValidExpected)
	{
		var subject = new C942_MembershipCategory();
		//Required fields
		//Test Parameters
		subject.MembershipCategoryDescriptionCode = membershipCategoryDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
