using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class LODTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LOD*o*NO*U*b*2*p";

		var expected = new LOD_LocationDescription()
		{
			GeneralTerritoryCode = "o",
			ConditionIndicator = "NO",
			FreeFormMessage = "U",
			ThoroughfareTypeQualifier = "b",
			ThoroughfareTypeCode = "2",
			FreeFormMessage2 = "p",
		};

		var actual = Map.MapObject<LOD_LocationDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("o", "U", false)]
	[InlineData("o", "", true)]
	[InlineData("", "U", true)]
	public void Validation_OnlyOneOfGeneralTerritoryCode(string generalTerritoryCode, string freeFormMessage, bool isValidExpected)
	{
		var subject = new LOD_LocationDescription();
		//Required fields
		//Test Parameters
		subject.GeneralTerritoryCode = generalTerritoryCode;
		subject.FreeFormMessage = freeFormMessage;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("NO", "o", true)]
	[InlineData("NO", "", false)]
	[InlineData("", "o", true)]
	public void Validation_ARequiresBConditionIndicator(string conditionIndicator, string generalTerritoryCode, bool isValidExpected)
	{
		var subject = new LOD_LocationDescription();
		//Required fields
		//Test Parameters
		subject.ConditionIndicator = conditionIndicator;
		subject.GeneralTerritoryCode = generalTerritoryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("b", "2", true)]
	[InlineData("b", "", false)]
	[InlineData("", "2", true)]
	public void Validation_ARequiresBThoroughfareTypeQualifier(string thoroughfareTypeQualifier, string thoroughfareTypeCode, bool isValidExpected)
	{
		var subject = new LOD_LocationDescription();
		//Required fields
		//Test Parameters
		subject.ThoroughfareTypeQualifier = thoroughfareTypeQualifier;
		subject.ThoroughfareTypeCode = thoroughfareTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("2", "p", false)]
	[InlineData("2", "", true)]
	[InlineData("", "p", true)]
	public void Validation_OnlyOneOfThoroughfareTypeCode(string thoroughfareTypeCode, string freeFormMessage2, bool isValidExpected)
	{
		var subject = new LOD_LocationDescription();
		//Required fields
		//Test Parameters
		subject.ThoroughfareTypeCode = thoroughfareTypeCode;
		subject.FreeFormMessage2 = freeFormMessage2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
