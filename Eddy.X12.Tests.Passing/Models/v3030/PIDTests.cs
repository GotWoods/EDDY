using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class PIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PID*C*no*Xa*A*5*Pj*4*8";

		var expected = new PID_ProductItemDescription()
		{
			ItemDescriptionType = "C",
			ProductProcessCharacteristicCode = "no",
			AgencyQualifierCode = "Xa",
			ProductDescriptionCode = "A",
			Description = "5",
			SurfaceLayerPositionCode = "Pj",
			SourceSubqualifier = "4",
			YesNoConditionOrResponseCode = "8",
		};

		var actual = Map.MapObject<PID_ProductItemDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredItemDescriptionType(string itemDescriptionType, bool isValidExpected)
	{
		var subject = new PID_ProductItemDescription();
		//Required fields
		//Test Parameters
		subject.ItemDescriptionType = itemDescriptionType;
		//At Least one
		subject.ProductDescriptionCode = "A";
        if (subject.ProductDescriptionCode != "")
            subject.AgencyQualifierCode = "AB";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("A", "Xa", true)]
	[InlineData("A", "", false)]
	[InlineData("", "Xa", true)]
	public void Validation_ARequiresBProductDescriptionCode(string productDescriptionCode, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new PID_ProductItemDescription();
		//Required fields
		subject.ItemDescriptionType = "C";
		//Test Parameters
		subject.ProductDescriptionCode = productDescriptionCode;
		subject.AgencyQualifierCode = agencyQualifierCode;

        if (subject.ProductDescriptionCode == "")
            subject.Description = "AB";


        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("A", "5", true)]
	[InlineData("A", "", true)]
	[InlineData("", "5", true)]
	public void Validation_AtLeastOneProductDescriptionCode(string productDescriptionCode, string description, bool isValidExpected)
	{
		var subject = new PID_ProductItemDescription();
		//Required fields
		subject.ItemDescriptionType = "C";
		//Test Parameters
		subject.ProductDescriptionCode = productDescriptionCode;
		subject.Description = description;

        if (subject.ProductDescriptionCode != "")
            subject.AgencyQualifierCode = "AB";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("4", "Xa", true)]
	[InlineData("4", "", false)]
	[InlineData("", "Xa", true)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new PID_ProductItemDescription();
		//Required fields
		subject.ItemDescriptionType = "C";
		//Test Parameters
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;

        subject.Description = "ABC";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("8", "Xa", true)]
	[InlineData("8", "", false)]
	[InlineData("", "Xa", true)]
	public void Validation_ARequiresBYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new PID_ProductItemDescription();
		//Required fields
		subject.ItemDescriptionType = "C";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		subject.AgencyQualifierCode = agencyQualifierCode;

        subject.Description = "ABC";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
