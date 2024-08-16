using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C942Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "8:T:l:h";

		var expected = new C942_MembershipCategory()
		{
			MembershipCategoryDescriptionCode = "8",
			CodeListIdentificationCode = "T",
			CodeListResponsibleAgencyCode = "l",
			MembershipCategoryDescription = "h",
		};

		var actual = Map.MapComposite<C942_MembershipCategory>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredMembershipCategoryDescriptionCode(string membershipCategoryDescriptionCode, bool isValidExpected)
	{
		var subject = new C942_MembershipCategory();
		//Required fields
		//Test Parameters
		subject.MembershipCategoryDescriptionCode = membershipCategoryDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
