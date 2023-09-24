using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class PIDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PID*A*Hy*gb*J*E*Um";

		var expected = new PID_ProductItemDescription()
		{
			ItemDescriptionType = "A",
			ProductProcessCharacteristicCode = "Hy",
			AgencyQualifierCode = "gb",
			ProductDescriptionCode = "J",
			Description = "E",
			SurfaceLayerPositionCode = "Um",
		};

		var actual = Map.MapObject<PID_ProductItemDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredItemDescriptionType(string itemDescriptionType, bool isValidExpected)
	{
		var subject = new PID_ProductItemDescription();
		//Required fields
		//Test Parameters
		subject.ItemDescriptionType = itemDescriptionType;
		//At Least one
		subject.ProductDescriptionCode = "J";
        if (subject.ProductDescriptionCode != "")
            subject.AgencyQualifierCode = "AB";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("J", "gb", true)]
	[InlineData("", "gb", true)]
	public void Validation_ARequiresBProductDescriptionCode(string productDescriptionCode, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new PID_ProductItemDescription();
		//Required fields
		subject.ItemDescriptionType = "A";
		//Test Parameters
		subject.ProductDescriptionCode = productDescriptionCode;
		subject.AgencyQualifierCode = agencyQualifierCode;

        if (subject.ProductDescriptionCode == "")
            subject.Description = "AB";

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("J", "E", true)]
	[InlineData("J", "", true)]
	[InlineData("", "E", true)]
	public void Validation_AtLeastOneProductDescriptionCode(string productDescriptionCode, string description, bool isValidExpected)
	{
		var subject = new PID_ProductItemDescription();
		//Required fields
		subject.ItemDescriptionType = "A";
		//Test Parameters
		subject.ProductDescriptionCode = productDescriptionCode;
		subject.Description = description;

        if (subject.ProductDescriptionCode != "")
            subject.AgencyQualifierCode = "AB";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
