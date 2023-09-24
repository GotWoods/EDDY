using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class PKGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PKG*n*1*D2*U*o*1p";

		var expected = new PKG_MarkingPackagingLoading()
		{
			ItemDescriptionType = "n",
			PackagingCharacteristicCode = "1",
			AgencyQualifierCode = "D2",
			PackagingDescriptionCode = "U",
			Description = "o",
			UnitLoadOptionCode = "1p",
		};

		var actual = Map.MapObject<PKG_MarkingPackagingLoading>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("U", "n", true)]
	[InlineData("U", "", false)]
	[InlineData("", "n", true)]
	public void Validation_ARequiresBPackagingDescriptionCode(string packagingDescriptionCode, string itemDescriptionType, bool isValidExpected)
	{
		var subject = new PKG_MarkingPackagingLoading();
		//Required fields
		//Test Parameters
		subject.PackagingDescriptionCode = packagingDescriptionCode;
		subject.ItemDescriptionType = itemDescriptionType;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("o", "n", true)]
	[InlineData("o", "", false)]
	[InlineData("", "n", true)]
	public void Validation_ARequiresBDescription(string description, string itemDescriptionType, bool isValidExpected)
	{
		var subject = new PKG_MarkingPackagingLoading();
		//Required fields
		//Test Parameters
		subject.Description = description;
		subject.ItemDescriptionType = itemDescriptionType;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
