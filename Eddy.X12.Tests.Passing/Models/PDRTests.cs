using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PDRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PDR*GI*o*Y*Jd";

		var expected = new PDR_PropertyDescriptionReal()
		{
			TypeOfRealEstateAssetCode = "GI",
			CodeListQualifierCode = "o",
			IndustryCode = "Y",
			OccupancyCode = "Jd",
		};

		var actual = Map.MapObject<PDR_PropertyDescriptionReal>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("GI", true)]
	public void Validation_RequiredTypeOfRealEstateAssetCode(string typeOfRealEstateAssetCode, bool isValidExpected)
	{
		var subject = new PDR_PropertyDescriptionReal();
		subject.TypeOfRealEstateAssetCode = typeOfRealEstateAssetCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("o", "Y", true)]
	[InlineData("", "Y", false)]
	[InlineData("o", "", false)]
	public void Validation_AllAreRequiredCodeListQualifierCode(string codeListQualifierCode, string industryCode, bool isValidExpected)
	{
		var subject = new PDR_PropertyDescriptionReal();
		subject.TypeOfRealEstateAssetCode = "GI";
		subject.CodeListQualifierCode = codeListQualifierCode;
		subject.IndustryCode = industryCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
