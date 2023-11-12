using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.Tests.Models.v4060;

public class LODTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LOD*M*Se*7*v*O*b";

		var expected = new LOD_LocationDescription()
		{
			GeneralTerritoryCode = "M",
			ConditionIndicator = "Se",
			FreeFormInformation = "7",
			ThoroughfareTypeQualifier = "v",
			ThoroughfareTypeCode = "O",
			FreeFormInformation2 = "b",
		};

		var actual = Map.MapObject<LOD_LocationDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("M", "7", false)]
	[InlineData("M", "", true)]
	[InlineData("", "7", true)]
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
	[InlineData("Se", "M", true)]
	[InlineData("Se", "", false)]
	[InlineData("", "M", true)]
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
	[InlineData("v", "O", true)]
	[InlineData("v", "", false)]
	[InlineData("", "O", true)]
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
	[InlineData("O", "b", false)]
	[InlineData("O", "", true)]
	[InlineData("", "b", true)]
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
