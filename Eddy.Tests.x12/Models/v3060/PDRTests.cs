using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class PDRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PDR*51*F*Z*TC";

		var expected = new PDR_PropertyDescriptionReal()
		{
			TypeOfRealEstateAssetCode = "51",
			CodeListQualifierCode = "F",
			IndustryCode = "Z",
			OccupancyCode = "TC",
		};

		var actual = Map.MapObject<PDR_PropertyDescriptionReal>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("51", true)]
	public void Validation_RequiredTypeOfRealEstateAssetCode(string typeOfRealEstateAssetCode, bool isValidExpected)
	{
		var subject = new PDR_PropertyDescriptionReal();
		//Required fields
		//Test Parameters
		subject.TypeOfRealEstateAssetCode = typeOfRealEstateAssetCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.IndustryCode))
		{
			subject.CodeListQualifierCode = "F";
			subject.IndustryCode = "Z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("F", "Z", true)]
	[InlineData("F", "", false)]
	[InlineData("", "Z", false)]
	public void Validation_AllAreRequiredCodeListQualifierCode(string codeListQualifierCode, string industryCode, bool isValidExpected)
	{
		var subject = new PDR_PropertyDescriptionReal();
		//Required fields
		subject.TypeOfRealEstateAssetCode = "51";
		//Test Parameters
		subject.CodeListQualifierCode = codeListQualifierCode;
		subject.IndustryCode = industryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
