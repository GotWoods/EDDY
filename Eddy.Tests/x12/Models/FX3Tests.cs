using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class FX3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FX3*t*aS*j*Xk*z*av*j*v*X*y*nZ";

		var expected = new FX3_ProductInformation()
		{
			YesNoConditionOrResponseCode = "t",
			ProductServiceIDQualifier = "aS",
			ProductServiceID = "j",
			ProductServiceIDQualifier2 = "Xk",
			ProductServiceID2 = "z",
			ProductServiceIDQualifier3 = "av",
			ProductServiceID3 = "j",
			AssignedIdentification = "v",
			Description = "X",
			YesNoConditionOrResponseCode2 = "y",
			ConditionIndicatorCode = "nZ",
		};

		var actual = Map.MapObject<FX3_ProductInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new FX3_ProductInformation();
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("aS", "j", true)]
	[InlineData("", "j", false)]
	[InlineData("aS", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new FX3_ProductInformation();
		subject.YesNoConditionOrResponseCode = "t";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Xk", "z", true)]
	[InlineData("", "z", false)]
	[InlineData("Xk", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new FX3_ProductInformation();
		subject.YesNoConditionOrResponseCode = "t";
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("av", "j", true)]
	[InlineData("", "j", false)]
	[InlineData("av", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new FX3_ProductInformation();
		subject.YesNoConditionOrResponseCode = "t";
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
