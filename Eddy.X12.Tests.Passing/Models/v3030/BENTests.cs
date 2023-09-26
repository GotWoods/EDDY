using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class BENTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BEN*j*2*ln*d*6";

		var expected = new BEN_BeneficiaryInformation()
		{
			PrimaryOrContingentCode = "j",
			Percent = 2,
			IndividualRelationshipCode = "ln",
			YesNoConditionOrResponseCode = "d",
			YesNoConditionOrResponseCode2 = "6",
		};

		var actual = Map.MapObject<BEN_BeneficiaryInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredPrimaryOrContingentCode(string primaryOrContingentCode, bool isValidExpected)
	{
		var subject = new BEN_BeneficiaryInformation();
		//Required fields
		//Test Parameters
		subject.PrimaryOrContingentCode = primaryOrContingentCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
