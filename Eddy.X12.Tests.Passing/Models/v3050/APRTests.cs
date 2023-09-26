using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class APRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "APR*8*3dBOoNC*HvArN7L";

		var expected = new APR_AssociationOfAmericanRailroadsPoolCodeRestrictions()
		{
			YesNoConditionOrResponseCode = "8",
			AssociationOfAmericanRailroadsAARPoolCode = "3dBOoNC",
			AssociationOfAmericanRailroadsAARPoolCode2 = "HvArN7L",
		};

		var actual = Map.MapObject<APR_AssociationOfAmericanRailroadsPoolCodeRestrictions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new APR_AssociationOfAmericanRailroadsPoolCodeRestrictions();
		//Required fields
		subject.AssociationOfAmericanRailroadsAARPoolCode = "3dBOoNC";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3dBOoNC", true)]
	public void Validation_RequiredAssociationOfAmericanRailroadsAARPoolCode(string associationOfAmericanRailroadsAARPoolCode, bool isValidExpected)
	{
		var subject = new APR_AssociationOfAmericanRailroadsPoolCodeRestrictions();
		//Required fields
		subject.YesNoConditionOrResponseCode = "8";
		//Test Parameters
		subject.AssociationOfAmericanRailroadsAARPoolCode = associationOfAmericanRailroadsAARPoolCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
