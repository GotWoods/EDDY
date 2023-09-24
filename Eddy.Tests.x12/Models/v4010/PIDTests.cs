using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class PIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PID*2*m4*UW*S*A*hH*S*1*Bb";

		var expected = new PID_ProductItemDescription()
		{
			ItemDescriptionType = "2",
			ProductProcessCharacteristicCode = "m4",
			AgencyQualifierCode = "UW",
			ProductDescriptionCode = "S",
			Description = "A",
			SurfaceLayerPositionCode = "hH",
			SourceSubqualifier = "S",
			YesNoConditionOrResponseCode = "1",
			LanguageCode = "Bb",
		};

		var actual = Map.MapObject<PID_ProductItemDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredItemDescriptionType(string itemDescriptionType, bool isValidExpected)
	{
		var subject = new PID_ProductItemDescription();
		//Required fields
		//Test Parameters
		subject.ItemDescriptionType = itemDescriptionType;
        //At Least one
        subject.Description = "ABC";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("S", "UW", true)]
	public void Validation_ARequiresBProductDescriptionCode(string productDescriptionCode, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new PID_ProductItemDescription();
		//Required fields
		subject.ItemDescriptionType = "2";
		//Test Parameters
		subject.ProductDescriptionCode = productDescriptionCode;
		subject.AgencyQualifierCode = agencyQualifierCode;

        if (subject.ProductDescriptionCode == "")
            subject.Description = "AB";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("S", "A", true)]
	[InlineData("S", "", true)]
	[InlineData("", "A", true)]
	public void Validation_AtLeastOneProductDescriptionCode(string productDescriptionCode, string description, bool isValidExpected)
	{
		var subject = new PID_ProductItemDescription();
		//Required fields
		subject.ItemDescriptionType = "2";
		//Test Parameters
		subject.ProductDescriptionCode = productDescriptionCode;
		subject.Description = description;

        if (subject.ProductDescriptionCode != "")
            subject.AgencyQualifierCode = "AB";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("S", "UW", true)]
	[InlineData("S", "", false)]
	[InlineData("", "UW", true)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new PID_ProductItemDescription();
		//Required fields
		subject.ItemDescriptionType = "2";
		//Test Parameters
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;
		//At Least one
		subject.ProductDescriptionCode = "S";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("1", "S", true)]
	[InlineData("1", "", false)]
	[InlineData("", "S", true)]
	public void Validation_ARequiresBYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, string productDescriptionCode, bool isValidExpected)
	{
		var subject = new PID_ProductItemDescription();
		//Required fields
		subject.ItemDescriptionType = "2";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		subject.ProductDescriptionCode = productDescriptionCode;
		//A Requires B
		if (productDescriptionCode != "")
			subject.AgencyQualifierCode = "UW";
		//At Least one
		subject.Description = "A";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Bb", "A", true)]
	[InlineData("Bb", "", false)]
	[InlineData("", "A", true)]
	public void Validation_ARequiresBLanguageCode(string languageCode, string description, bool isValidExpected)
	{
		var subject = new PID_ProductItemDescription();
		//Required fields
		subject.ItemDescriptionType = "2";
		//Test Parameters
		subject.LanguageCode = languageCode;
		subject.Description = description;
		//At Least one
		subject.ProductDescriptionCode = "S";

        if (subject.ProductDescriptionCode != "")
            subject.AgencyQualifierCode = "AB";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
