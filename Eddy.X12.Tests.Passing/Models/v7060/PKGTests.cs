using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.Tests.Models.v7060;

public class PKGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PKG*e*u*Ej*J*A*wk*3D";

		var expected = new PKG_MarkingPackagingLoading()
		{
			ItemDescriptionTypeCode = "e",
			PackagingCharacteristicCode = "u",
			AgencyQualifierCode = "Ej",
			PackagingDescriptionCode = "J",
			Description = "A",
			UnitLoadOptionCode = "wk",
			LanguageCode = "3D",
		};

		var actual = Map.MapObject<PKG_MarkingPackagingLoading>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("J", "Ej", true)]
	[InlineData("J", "", false)]
	[InlineData("", "Ej", true)]
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
	[InlineData("A", "e", true)]
	[InlineData("A", "", false)]
	[InlineData("", "e", true)]
	public void Validation_ARequiresBDescription(string description, string itemDescriptionTypeCode, bool isValidExpected)
	{
		var subject = new PKG_MarkingPackagingLoading();
		//Required fields
		//Test Parameters
		subject.Description = description;
		subject.ItemDescriptionTypeCode = itemDescriptionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("3D", "A", true)]
	[InlineData("3D", "", false)]
	[InlineData("", "A", true)]
	public void Validation_ARequiresBLanguageCode(string languageCode, string description, bool isValidExpected)
	{
		var subject = new PKG_MarkingPackagingLoading();
		//Required fields
		//Test Parameters
		subject.LanguageCode = languageCode;
		subject.Description = description;
		//A Requires B
		if (description != "")
			subject.ItemDescriptionTypeCode = "e";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
