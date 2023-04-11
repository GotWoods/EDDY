using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class FX4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FX4*W*k8*d1*j*TK*q*Q";

		var expected = new FX4_EquipmentInformation()
		{
			YesNoConditionOrResponseCode = "W",
			TypeOfProductServiceCode = "k8",
			ProductServiceIDQualifier = "d1",
			ProductServiceID = "j",
			ProductServiceIDQualifier2 = "TK",
			ProductServiceID2 = "q",
			Description = "Q",
		};

		var actual = Map.MapObject<FX4_EquipmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new FX4_EquipmentInformation();
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
        subject.Description = "AB";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("d1", "j", true)]
	[InlineData("", "j", false)]
	[InlineData("d1", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new FX4_EquipmentInformation();
		subject.YesNoConditionOrResponseCode = "W";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
        subject.Description = "AB";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("d1","Q", true)]
	[InlineData("", "Q", true)]
	[InlineData("d1", "", true)]
	public void Validation_AtLeastOneProductServiceIDQualifier(string productServiceIDQualifier, string description, bool isValidExpected)
	{
		var subject = new FX4_EquipmentInformation();
		subject.YesNoConditionOrResponseCode = "W";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.Description = description;

		if (productServiceIDQualifier!="")
			subject.ProductServiceID = "AB";

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("TK", "q", true)]
	[InlineData("", "q", false)]
	[InlineData("TK", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new FX4_EquipmentInformation();
		subject.YesNoConditionOrResponseCode = "W";
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
        subject.Description = "AB";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
