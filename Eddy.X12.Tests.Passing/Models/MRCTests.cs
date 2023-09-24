using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class MRCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MRC*gg*d*g*8*r*y*8*h*6";

		var expected = new MRC_MortgagorResponseCharacteristics()
		{
			EntityIdentifierCode = "gg",
			MortgagorResponseCode = "d",
			ContactMethodCode = "g",
			Quantity = 8,
			DateTimePeriod = "r",
			ContactMethodCode2 = "y",
			Quantity2 = 8,
			ContactMethodCode3 = "h",
			Quantity3 = 6,
		};

		var actual = Map.MapObject<MRC_MortgagorResponseCharacteristics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("gg", true)]
	public void Validation_RequiredEntityIdentifierCode(string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new MRC_MortgagorResponseCharacteristics();
		subject.MortgagorResponseCode = "d";
		subject.ContactMethodCode = "g";
		subject.Quantity = 8;
		subject.EntityIdentifierCode = entityIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredMortgagorResponseCode(string mortgagorResponseCode, bool isValidExpected)
	{
		var subject = new MRC_MortgagorResponseCharacteristics();
		subject.EntityIdentifierCode = "gg";
		subject.ContactMethodCode = "g";
		subject.Quantity = 8;
		subject.MortgagorResponseCode = mortgagorResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredContactMethodCode(string contactMethodCode, bool isValidExpected)
	{
		var subject = new MRC_MortgagorResponseCharacteristics();
		subject.EntityIdentifierCode = "gg";
		subject.MortgagorResponseCode = "d";
		subject.Quantity = 8;
		subject.ContactMethodCode = contactMethodCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new MRC_MortgagorResponseCharacteristics();
		subject.EntityIdentifierCode = "gg";
		subject.MortgagorResponseCode = "d";
		subject.ContactMethodCode = "g";
		if (quantity > 0)
		subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("y", 8, true)]
	[InlineData("", 8, false)]
	[InlineData("y", 0, false)]
	public void Validation_AllAreRequiredContactMethodCode2(string contactMethodCode2, decimal quantity2, bool isValidExpected)
	{
		var subject = new MRC_MortgagorResponseCharacteristics();
		subject.EntityIdentifierCode = "gg";
		subject.MortgagorResponseCode = "d";
		subject.ContactMethodCode = "g";
		subject.Quantity = 8;
		subject.ContactMethodCode2 = contactMethodCode2;
		if (quantity2 > 0)
		subject.Quantity2 = quantity2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("h", 6, true)]
	[InlineData("", 6, false)]
	[InlineData("h", 0, false)]
	public void Validation_AllAreRequiredContactMethodCode3(string contactMethodCode3, decimal quantity3, bool isValidExpected)
	{
		var subject = new MRC_MortgagorResponseCharacteristics();
		subject.EntityIdentifierCode = "gg";
		subject.MortgagorResponseCode = "d";
		subject.ContactMethodCode = "g";
		subject.Quantity = 8;
		subject.ContactMethodCode3 = contactMethodCode3;
		if (quantity3 > 0)
		subject.Quantity3 = quantity3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
