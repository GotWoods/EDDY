using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class LODTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LOD*5*XA*y*t*x*4";

		var expected = new LOD_LocationDescription()
		{
			GeneralTerritoryCode = "5",
			ConditionIndicatorCode = "XA",
			FreeFormInformation = "y",
			ThoroughfareTypeQualifier = "t",
			ThoroughfareTypeCode = "x",
			FreeFormInformation2 = "4",
		};

		var actual = Map.MapObject<LOD_LocationDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("5", "y", false)]
	[InlineData("", "y", true)]
	[InlineData("5", "", true)]
	public void Validation_OnlyOneOfGeneralTerritoryCode(string generalTerritoryCode, string freeFormInformation, bool isValidExpected)
	{
		var subject = new LOD_LocationDescription();
		subject.GeneralTerritoryCode = generalTerritoryCode;
		subject.FreeFormInformation = freeFormInformation;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "5", true)]
	[InlineData("XA", "", false)]
	public void Validation_ARequiresBConditionIndicatorCode(string conditionIndicatorCode, string generalTerritoryCode, bool isValidExpected)
	{
		var subject = new LOD_LocationDescription();
		subject.ConditionIndicatorCode = conditionIndicatorCode;
		subject.GeneralTerritoryCode = generalTerritoryCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "x", true)]
	[InlineData("t", "", false)]
	public void Validation_ARequiresBThoroughfareTypeQualifier(string thoroughfareTypeQualifier, string thoroughfareTypeCode, bool isValidExpected)
	{
		var subject = new LOD_LocationDescription();
		subject.ThoroughfareTypeQualifier = thoroughfareTypeQualifier;
		subject.ThoroughfareTypeCode = thoroughfareTypeCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("x", "4", false)]
	[InlineData("", "4", true)]
	[InlineData("x", "", true)]
	public void Validation_OnlyOneOfThoroughfareTypeCode(string thoroughfareTypeCode, string freeFormInformation2, bool isValidExpected)
	{
		var subject = new LOD_LocationDescription();
		subject.ThoroughfareTypeCode = thoroughfareTypeCode;
		subject.FreeFormInformation2 = freeFormInformation2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
