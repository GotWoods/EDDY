using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class RYLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RYL*4*6*c*ek";

		var expected = new RYL_RoyaltyPayment()
		{
			AssignedNumber = 4,
			NameLastOrOrganizationName = "6",
			IdentificationCodeQualifier = "c",
			IdentificationCode = "ek",
		};

		var actual = Map.MapObject<RYL_RoyaltyPayment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new RYL_RoyaltyPayment();
		if (assignedNumber > 0)
		subject.AssignedNumber = assignedNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("c", "ek", true)]
	[InlineData("", "ek", false)]
	[InlineData("c", "", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new RYL_RoyaltyPayment();
		subject.AssignedNumber = 4;
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
