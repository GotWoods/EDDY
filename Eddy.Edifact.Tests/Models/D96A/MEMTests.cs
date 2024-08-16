using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class MEMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "MEM+7+++++";

		var expected = new MEM_MembershipDetails()
		{
			MembershipQualifier = "7",
			MembershipCategory = null,
			MembershipStatus = null,
			MembershipLevel = null,
			RateTariffClass = null,
			ReasonForChange = null,
		};

		var actual = Map.MapObject<MEM_MembershipDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredMembershipQualifier(string membershipQualifier, bool isValidExpected)
	{
		var subject = new MEM_MembershipDetails();
		//Required fields
		//Test Parameters
		subject.MembershipQualifier = membershipQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
