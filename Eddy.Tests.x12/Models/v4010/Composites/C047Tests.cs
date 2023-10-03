using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v4010;
using Eddy.x12.Models.v4010.Composites;

namespace Eddy.x12.Tests.Models.v4010.Composites;

public class C047Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "Dn*t1*UB*8o*Do";

		var expected = new C047_CompositeTypeOfRealEstateAssetCode()
		{
			TypeOfRealEstateAssetCode = "Dn",
			TypeOfRealEstateAssetCode2 = "t1",
			TypeOfRealEstateAssetCode3 = "UB",
			TypeOfRealEstateAssetCode4 = "8o",
			TypeOfRealEstateAssetCode5 = "Do",
		};

		var actual = Map.MapObject<C047_CompositeTypeOfRealEstateAssetCode>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Dn", true)]
	public void Validation_RequiredTypeOfRealEstateAssetCode(string typeOfRealEstateAssetCode, bool isValidExpected)
	{
		var subject = new C047_CompositeTypeOfRealEstateAssetCode();
		//Required fields
		//Test Parameters
		subject.TypeOfRealEstateAssetCode = typeOfRealEstateAssetCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Do", "8o", true)]
	[InlineData("Do", "", false)]
	[InlineData("", "8o", true)]
	public void Validation_ARequiresBTypeOfRealEstateAssetCode5(string typeOfRealEstateAssetCode5, string typeOfRealEstateAssetCode4, bool isValidExpected)
	{
		var subject = new C047_CompositeTypeOfRealEstateAssetCode();
		//Required fields
		subject.TypeOfRealEstateAssetCode = "Dn";
		//Test Parameters
		subject.TypeOfRealEstateAssetCode5 = typeOfRealEstateAssetCode5;
		subject.TypeOfRealEstateAssetCode4 = typeOfRealEstateAssetCode4;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
