using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class MEMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "MEM+c+++++";

		var expected = new MEM_MembershipDetails()
		{
			MembershipTypeCodeQualifier = "c",
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
	[InlineData("c", true)]
	public void Validation_RequiredMembershipTypeCodeQualifier(string membershipTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new MEM_MembershipDetails();
		//Required fields
		//Test Parameters
		subject.MembershipTypeCodeQualifier = membershipTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
