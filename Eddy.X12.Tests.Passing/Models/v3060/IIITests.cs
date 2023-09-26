using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class IIITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "III*X*j*iJ*3*3**g1*Jv*Gr";

		var expected = new III_Information()
		{
			CodeListQualifierCode = "X",
			IndustryCode = "j",
			CodeCategory = "iJ",
			FreeFormMessageText = "3",
			Quantity = 3,
			CompositeUnitOfMeasure = null,
			SurfaceLayerPositionCode = "g1",
			SurfaceLayerPositionCode2 = "Jv",
			SurfaceLayerPositionCode3 = "Gr",
		};

		var actual = Map.MapObject<III_Information>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("X", "j", true)]
	[InlineData("X", "", false)]
	[InlineData("", "j", false)]
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
			subject.CodeCategory = "iJ";
			subject.FreeFormMessageText = "3";
			subject.Quantity = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", 0, true)]
	[InlineData("iJ", "3", 3, true)]
	[InlineData("iJ", "", 0, false)]
	[InlineData("", "3", 3, true)]
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
			subject.CodeListQualifierCode = "X";
			subject.IndustryCode = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
