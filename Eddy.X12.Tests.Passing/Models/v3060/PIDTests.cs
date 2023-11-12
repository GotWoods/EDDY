using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class PIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PID*K*Tq*Os*S*I*lG*w*n*lr";

		var expected = new PID_ProductItemDescription()
		{
			ItemDescriptionType = "K",
			ProductProcessCharacteristicCode = "Tq",
			AgencyQualifierCode = "Os",
			ProductDescriptionCode = "S",
			Description = "I",
			SurfaceLayerPositionCode = "lG",
			SourceSubqualifier = "w",
			YesNoConditionOrResponseCode = "n",
			LanguageCode = "lr",
		};

		var actual = Map.MapObject<PID_ProductItemDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredItemDescriptionType(string itemDescriptionType, bool isValidExpected)
	{
		var subject = new PID_ProductItemDescription();
		//Required fields
		//Test Parameters
		subject.ItemDescriptionType = itemDescriptionType;
		//At Least one
		subject.ProductDescriptionCode = "S";
        if (subject.ProductDescriptionCode != "")
            subject.AgencyQualifierCode = "AB";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("S", "Os", true)]
	[InlineData("S", "", false)]
	[InlineData("", "Os", true)]
	public void Validation_ARequiresBProductDescriptionCode(string productDescriptionCode, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new PID_ProductItemDescription();
		//Required fields
		subject.ItemDescriptionType = "K";
		//Test Parameters
		subject.ProductDescriptionCode = productDescriptionCode;
		subject.AgencyQualifierCode = agencyQualifierCode;

        if (subject.ProductDescriptionCode == "")
            subject.Description = "AB";


        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("S", "I", true)]
	[InlineData("S", "", true)]
	[InlineData("", "I", true)]
	public void Validation_AtLeastOneProductDescriptionCode(string productDescriptionCode, string description, bool isValidExpected)
	{
		var subject = new PID_ProductItemDescription();
		//Required fields
		subject.ItemDescriptionType = "K";
		//Test Parameters
		subject.ProductDescriptionCode = productDescriptionCode;
		subject.Description = description;

        if (subject.ProductDescriptionCode != "")
            subject.AgencyQualifierCode = "AB";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("w", "Os", true)]
	[InlineData("w", "", false)]
	[InlineData("", "Os", true)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new PID_ProductItemDescription();
		//Required fields
		subject.ItemDescriptionType = "K";
		//Test Parameters
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;
        subject.Description = "ABC";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("n", "Os", true)]
	[InlineData("n", "", false)]
	[InlineData("", "Os", true)]
	public void Validation_ARequiresBYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new PID_ProductItemDescription();
		//Required fields
		subject.ItemDescriptionType = "K";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		subject.AgencyQualifierCode = agencyQualifierCode;
        subject.Description = "ABC";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
