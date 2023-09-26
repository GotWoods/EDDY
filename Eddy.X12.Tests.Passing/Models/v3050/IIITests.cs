using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class IIITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "III*u*t*jP*J*5**bE*MI*yS";

		var expected = new III_Information()
		{
			CodeListQualifierCode = "u",
			IndustryCode = "t",
			CodeCategory = "jP",
			FreeFormMessageText = "J",
			Quantity = 5,
			CompositeUnitOfMeasure = null,
			SurfaceLayerPositionCode = "bE",
			SurfaceLayerPositionCode2 = "MI",
			SurfaceLayerPositionCode3 = "yS",
		};

		var actual = Map.MapObject<III_Information>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("u", "t", true)]
	[InlineData("u", "", false)]
	[InlineData("", "t", false)]
	public void Validation_AllAreRequiredCodeListQualifierCode(string codeListQualifierCode, string industryCode, bool isValidExpected)
	{
		var subject = new III_Information();
		//Required fields
		//Test Parameters
		subject.CodeListQualifierCode = codeListQualifierCode;
		subject.IndustryCode = industryCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.CodeCategory) || !string.IsNullOrEmpty(subject.CodeCategory) || !string.IsNullOrEmpty(subject.FreeFormMessageText) || subject.Quantity > 0)
		{
			subject.CodeCategory = "jP";
			subject.FreeFormMessageText = "J";
			subject.Quantity = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", 0, true)]
	[InlineData("jP", "J", 5, true)]
	[InlineData("jP", "", 0, false)]
	[InlineData("", "J", 5, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_CodeCategory(string codeCategory, string freeFormMessageText, decimal quantity, bool isValidExpected)
	{
		var subject = new III_Information();
		//Required fields
		//Test Parameters
		subject.CodeCategory = codeCategory;
		subject.FreeFormMessageText = freeFormMessageText;
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.IndustryCode))
		{
			subject.CodeListQualifierCode = "u";
			subject.IndustryCode = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
