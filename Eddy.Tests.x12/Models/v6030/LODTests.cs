using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class LODTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LOD*J*HB*2*v*n*4";

		var expected = new LOD_LocationDescription()
		{
			GeneralTerritoryCode = "J",
			ConditionIndicatorCode = "HB",
			FreeFormInformation = "2",
			ThoroughfareTypeQualifier = "v",
			ThoroughfareTypeCode = "n",
			FreeFormInformation2 = "4",
		};

		var actual = Map.MapObject<LOD_LocationDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("J", "2", false)]
	[InlineData("J", "", true)]
	[InlineData("", "2", true)]
	public void Validation_OnlyOneOfGeneralTerritoryCode(string generalTerritoryCode, string freeFormInformation, bool isValidExpected)
	{
		var subject = new LOD_LocationDescription();
		//Required fields
		//Test Parameters
		subject.GeneralTerritoryCode = generalTerritoryCode;
		subject.FreeFormInformation = freeFormInformation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("HB", "J", true)]
	[InlineData("HB", "", false)]
	[InlineData("", "J", true)]
	public void Validation_ARequiresBConditionIndicatorCode(string conditionIndicatorCode, string generalTerritoryCode, bool isValidExpected)
	{
		var subject = new LOD_LocationDescription();
		//Required fields
		//Test Parameters
		subject.ConditionIndicatorCode = conditionIndicatorCode;
		subject.GeneralTerritoryCode = generalTerritoryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("v", "n", true)]
	[InlineData("v", "", false)]
	[InlineData("", "n", true)]
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
	[InlineData("n", "4", false)]
	[InlineData("n", "", true)]
	[InlineData("", "4", true)]
	public void Validation_OnlyOneOfThoroughfareTypeCode(string thoroughfareTypeCode, string freeFormInformation2, bool isValidExpected)
	{
		var subject = new LOD_LocationDescription();
		//Required fields
		//Test Parameters
		subject.ThoroughfareTypeCode = thoroughfareTypeCode;
		subject.FreeFormInformation2 = freeFormInformation2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
