using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C942Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "G:o:J:U";

		var expected = new C942_MembershipCategory()
		{
			MembershipCategoryIdentification = "G",
			CodeListIdentificationCode = "o",
			CodeListResponsibleAgencyCode = "J",
			MembershipCategory = "U",
		};

		var actual = Map.MapComposite<C942_MembershipCategory>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredMembershipCategoryIdentification(string membershipCategoryIdentification, bool isValidExpected)
	{
		var subject = new C942_MembershipCategory();
		//Required fields
		//Test Parameters
		subject.MembershipCategoryIdentification = membershipCategoryIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
