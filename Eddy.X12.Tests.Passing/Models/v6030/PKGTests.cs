using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class PKGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PKG*9*D*Om*a*T*3k";

		var expected = new PKG_MarkingPackagingLoading()
		{
			ItemDescriptionTypeCode = "9",
			PackagingCharacteristicCode = "D",
			AgencyQualifierCode = "Om",
			PackagingDescriptionCode = "a",
			Description = "T",
			UnitLoadOptionCode = "3k",
		};

		var actual = Map.MapObject<PKG_MarkingPackagingLoading>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("a", "Om", true)]
	[InlineData("a", "", false)]
	[InlineData("", "Om", true)]
	public void Validation_ARequiresBPackagingDescriptionCode(string packagingDescriptionCode, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new PKG_MarkingPackagingLoading();
		//Required fields
		//Test Parameters
		subject.PackagingDescriptionCode = packagingDescriptionCode;
		subject.AgencyQualifierCode = agencyQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("T", "9", true)]
	[InlineData("T", "", false)]
	[InlineData("", "9", true)]
	public void Validation_ARequiresBDescription(string description, string itemDescriptionTypeCode, bool isValidExpected)
	{
		var subject = new PKG_MarkingPackagingLoading();
		//Required fields
		//Test Parameters
		subject.Description = description;
		subject.ItemDescriptionTypeCode = itemDescriptionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
