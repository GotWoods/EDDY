using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PKGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PKG*z*h*2G*3*D*QH*Xp";

		var expected = new PKG_MarkingPackagingLoading()
		{
			ItemDescriptionTypeCode = "z",
			PackagingCharacteristicCode = "h",
			AgencyQualifierCode = "2G",
			PackagingDescriptionCode = "3",
			Description = "D",
			UnitLoadOptionCode = "QH",
			LanguageCode = "Xp",
		};

		var actual = Map.MapObject<PKG_MarkingPackagingLoading>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}
	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "hh", true)]
	[InlineData("z", "", false)]
	public void Validation_ARequiresBPackagingDescriptionCode(string packagingDescriptionCode, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new PKG_MarkingPackagingLoading();
		subject.PackagingDescriptionCode = packagingDescriptionCode;
		subject.AgencyQualifierCode = agencyQualifierCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}
	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "h", true)]
	[InlineData("z", "", false)]
	public void Validation_ARequiresBDescription(string description, string itemDescriptionTypeCode, bool isValidExpected)
	{
		var subject = new PKG_MarkingPackagingLoading();
		subject.Description = description;
		subject.ItemDescriptionTypeCode = itemDescriptionTypeCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}
	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "h", true)]
	[InlineData("zz", "", false)]
	public void Validation_ARequiresBLanguageCode(string languageCode, string description, bool isValidExpected)
	{
		var subject = new PKG_MarkingPackagingLoading();
		subject.LanguageCode = languageCode;
		subject.Description = description;
		if (description != "")
			subject.ItemDescriptionTypeCode = "1";

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}
}
