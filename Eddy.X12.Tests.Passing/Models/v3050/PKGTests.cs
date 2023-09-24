using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class PKGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PKG*w*u*UN*K*a*Xu";

		var expected = new PKG_MarkingPackagingLoading()
		{
			ItemDescriptionType = "w",
			PackagingCharacteristicCode = "u",
			AgencyQualifierCode = "UN",
			PackagingDescriptionCode = "K",
			Description = "a",
			UnitLoadOptionCode = "Xu",
		};

		var actual = Map.MapObject<PKG_MarkingPackagingLoading>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("K", "UN", true)]
	[InlineData("K", "", false)]
	[InlineData("", "UN", true)]
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
	[InlineData("a", "w", true)]
	[InlineData("a", "", false)]
	[InlineData("", "w", true)]
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
