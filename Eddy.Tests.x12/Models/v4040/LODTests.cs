using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class LODTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LOD*f*Du*r*h*M*6";

		var expected = new LOD_LocationDescription()
		{
			GeneralTerritoryCode = "f",
			ConditionIndicator = "Du",
			FreeFormMessage = "r",
			ThoroughfareTypeQualifier = "h",
			ThoroughfareTypeCode = "M",
			FreeFormMessage2 = "6",
		};

		var actual = Map.MapObject<LOD_LocationDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("f", "r", false)]
	[InlineData("f", "", true)]
	[InlineData("", "r", true)]
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
	[InlineData("Du", "f", true)]
	[InlineData("Du", "", false)]
	[InlineData("", "f", true)]
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
	[InlineData("h", "M", true)]
	[InlineData("h", "", false)]
	[InlineData("", "M", true)]
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
	[InlineData("M", "6", false)]
	[InlineData("M", "", true)]
	[InlineData("", "6", true)]
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
