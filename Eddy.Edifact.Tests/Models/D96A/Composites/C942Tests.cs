using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C942Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "w:T:f:9";

		var expected = new C942_MembershipCategory()
		{
			MembershipCategoryIdentification = "w",
			CodeListQualifier = "T",
			CodeListResponsibleAgencyCoded = "f",
			MembershipCategory = "9",
		};

		var actual = Map.MapComposite<C942_MembershipCategory>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredMembershipCategoryIdentification(string membershipCategoryIdentification, bool isValidExpected)
	{
		var subject = new C942_MembershipCategory();
		//Required fields
		//Test Parameters
		subject.MembershipCategoryIdentification = membershipCategoryIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
