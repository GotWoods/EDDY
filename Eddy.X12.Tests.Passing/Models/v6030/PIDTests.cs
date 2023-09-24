using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class PIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PID*M*Ie*9B*O*K*gX*V*x*gw";

		var expected = new PID_ProductItemDescription()
		{
			ItemDescriptionTypeCode = "M",
			ProductProcessCharacteristicCode = "Ie",
			AgencyQualifierCode = "9B",
			ProductDescriptionCode = "O",
			Description = "K",
			SurfaceLayerPositionCode = "gX",
			SourceSubqualifier = "V",
			YesNoConditionOrResponseCode = "x",
			LanguageCode = "gw",
		};

		var actual = Map.MapObject<PID_ProductItemDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredItemDescriptionTypeCode(string itemDescriptionTypeCode, bool isValidExpected)
	{
		var subject = new PID_ProductItemDescription();
		//Required fields
		//Test Parameters
		subject.ItemDescriptionTypeCode = itemDescriptionTypeCode;
        subject.Description = "ABC";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("O", "9B", true)]
	[InlineData("", "9B", true)]
	public void Validation_ARequiresBProductDescriptionCode(string productDescriptionCode, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new PID_ProductItemDescription();
		//Required fields
		subject.ItemDescriptionTypeCode = "M";
		//Test Parameters
		subject.ProductDescriptionCode = productDescriptionCode;
		subject.AgencyQualifierCode = agencyQualifierCode;

        if (subject.ProductDescriptionCode == "")
            subject.Description = "AB";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("O", "K", true)]
	[InlineData("O", "", true)]
	[InlineData("", "K", true)]
	public void Validation_AtLeastOneProductDescriptionCode(string productDescriptionCode, string description, bool isValidExpected)
	{
		var subject = new PID_ProductItemDescription();
		//Required fields
		subject.ItemDescriptionTypeCode = "M";
		//Test Parameters
		subject.ProductDescriptionCode = productDescriptionCode;
		subject.Description = description;

        if (subject.ProductDescriptionCode != "")
            subject.AgencyQualifierCode = "AB";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("V", "9B", true)]
	[InlineData("V", "", false)]
	[InlineData("", "9B", true)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new PID_ProductItemDescription();
		//Required fields
		subject.ItemDescriptionTypeCode = "M";
		//Test Parameters
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;
        subject.Description = "ABC";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("x", "O", true)]
	[InlineData("x", "", false)]
	[InlineData("", "O", true)]
	public void Validation_ARequiresBYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, string productDescriptionCode, bool isValidExpected)
	{
		var subject = new PID_ProductItemDescription();
		//Required fields
		subject.ItemDescriptionTypeCode = "M";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		subject.ProductDescriptionCode = productDescriptionCode;
		//A Requires B
		if (productDescriptionCode != "")
			subject.AgencyQualifierCode = "9B";
		//At Least one
		subject.Description = "K";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("gw", "K", true)]
	[InlineData("gw", "", false)]
	[InlineData("", "K", true)]
	public void Validation_ARequiresBLanguageCode(string languageCode, string description, bool isValidExpected)
	{
		var subject = new PID_ProductItemDescription();
		//Required fields
		subject.ItemDescriptionTypeCode = "M";
		//Test Parameters
		subject.LanguageCode = languageCode;
		subject.Description = description;
		//At Least one
		subject.ProductDescriptionCode = "O";
        if (subject.ProductDescriptionCode != "")
            subject.AgencyQualifierCode = "AB";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
