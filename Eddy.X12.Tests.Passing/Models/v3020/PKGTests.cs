using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class PKGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PKG*D*I*VB*9*V";

		var expected = new PKG_MarkingPackagingLoading()
		{
			ItemDescriptionType = "D",
			PackagingCharacteristicCode = "I",
			AgencyQualifierCode = "VB",
			PackagingDescriptionCode = "9",
			Description = "V",
		};

		var actual = Map.MapObject<PKG_MarkingPackagingLoading>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredItemDescriptionType(string itemDescriptionType, bool isValidExpected)
	{
		var subject = new PKG_MarkingPackagingLoading();
		//Required fields
		//Test Parameters
		subject.ItemDescriptionType = itemDescriptionType;
		//At Least one
		subject.PackagingDescriptionCode = "9";
		subject.AgencyQualifierCode = "AB";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("9", "VB", true)]
	[InlineData("9", "", false)]
	[InlineData("", "VB", true)]
	public void Validation_ARequiresBPackagingDescriptionCode(string packagingDescriptionCode, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new PKG_MarkingPackagingLoading();
		//Required fields
		subject.ItemDescriptionType = "D";

		//Test Parameters
		subject.PackagingDescriptionCode = packagingDescriptionCode;
		subject.AgencyQualifierCode = agencyQualifierCode;

        if (subject.PackagingDescriptionCode == "")
            subject.Description = "AB";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("9", "V", true)]
	[InlineData("9", "", true)]
	[InlineData("", "V", true)]
	public void Validation_AtLeastOnePackagingDescriptionCode(string packagingDescriptionCode, string description, bool isValidExpected)
	{
		var subject = new PKG_MarkingPackagingLoading();
		//Required fields
		subject.ItemDescriptionType = "D";
		//Test Parameters
		subject.PackagingDescriptionCode = packagingDescriptionCode;
		subject.Description = description;

        if (subject.PackagingDescriptionCode != "")
            subject.AgencyQualifierCode = "AB";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
