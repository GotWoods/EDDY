using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class MRCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MRC*JI*z*3*7*1*Q*5*g*8";

		var expected = new MRC_MortgagorResponseCharacteristics()
		{
			EntityIdentifierCode = "JI",
			MortgagorResponseCode = "z",
			ContactMethodCode = "3",
			Quantity = 7,
			DateTimePeriod = "1",
			ContactMethodCode2 = "Q",
			Quantity2 = 5,
			ContactMethodCode3 = "g",
			Quantity3 = 8,
		};

		var actual = Map.MapObject<MRC_MortgagorResponseCharacteristics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("JI", true)]
	public void Validation_RequiredEntityIdentifierCode(string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new MRC_MortgagorResponseCharacteristics();
		//Required fields
		subject.MortgagorResponseCode = "z";
		subject.ContactMethodCode = "3";
		subject.Quantity = 7;
		//Test Parameters
		subject.EntityIdentifierCode = entityIdentifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ContactMethodCode2) || !string.IsNullOrEmpty(subject.ContactMethodCode2) || subject.Quantity2 > 0)
		{
			subject.ContactMethodCode2 = "Q";
			subject.Quantity2 = 5;
		}
		if(!string.IsNullOrEmpty(subject.ContactMethodCode3) || !string.IsNullOrEmpty(subject.ContactMethodCode3) || subject.Quantity3 > 0)
		{
			subject.ContactMethodCode3 = "g";
			subject.Quantity3 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredMortgagorResponseCode(string mortgagorResponseCode, bool isValidExpected)
	{
		var subject = new MRC_MortgagorResponseCharacteristics();
		//Required fields
		subject.EntityIdentifierCode = "JI";
		subject.ContactMethodCode = "3";
		subject.Quantity = 7;
		//Test Parameters
		subject.MortgagorResponseCode = mortgagorResponseCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ContactMethodCode2) || !string.IsNullOrEmpty(subject.ContactMethodCode2) || subject.Quantity2 > 0)
		{
			subject.ContactMethodCode2 = "Q";
			subject.Quantity2 = 5;
		}
		if(!string.IsNullOrEmpty(subject.ContactMethodCode3) || !string.IsNullOrEmpty(subject.ContactMethodCode3) || subject.Quantity3 > 0)
		{
			subject.ContactMethodCode3 = "g";
			subject.Quantity3 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredContactMethodCode(string contactMethodCode, bool isValidExpected)
	{
		var subject = new MRC_MortgagorResponseCharacteristics();
		//Required fields
		subject.EntityIdentifierCode = "JI";
		subject.MortgagorResponseCode = "z";
		subject.Quantity = 7;
		//Test Parameters
		subject.ContactMethodCode = contactMethodCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ContactMethodCode2) || !string.IsNullOrEmpty(subject.ContactMethodCode2) || subject.Quantity2 > 0)
		{
			subject.ContactMethodCode2 = "Q";
			subject.Quantity2 = 5;
		}
		if(!string.IsNullOrEmpty(subject.ContactMethodCode3) || !string.IsNullOrEmpty(subject.ContactMethodCode3) || subject.Quantity3 > 0)
		{
			subject.ContactMethodCode3 = "g";
			subject.Quantity3 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new MRC_MortgagorResponseCharacteristics();
		//Required fields
		subject.EntityIdentifierCode = "JI";
		subject.MortgagorResponseCode = "z";
		subject.ContactMethodCode = "3";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ContactMethodCode2) || !string.IsNullOrEmpty(subject.ContactMethodCode2) || subject.Quantity2 > 0)
		{
			subject.ContactMethodCode2 = "Q";
			subject.Quantity2 = 5;
		}
		if(!string.IsNullOrEmpty(subject.ContactMethodCode3) || !string.IsNullOrEmpty(subject.ContactMethodCode3) || subject.Quantity3 > 0)
		{
			subject.ContactMethodCode3 = "g";
			subject.Quantity3 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Q", 5, true)]
	[InlineData("Q", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredContactMethodCode2(string contactMethodCode2, decimal quantity2, bool isValidExpected)
	{
		var subject = new MRC_MortgagorResponseCharacteristics();
		//Required fields
		subject.EntityIdentifierCode = "JI";
		subject.MortgagorResponseCode = "z";
		subject.ContactMethodCode = "3";
		subject.Quantity = 7;
		//Test Parameters
		subject.ContactMethodCode2 = contactMethodCode2;
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ContactMethodCode3) || !string.IsNullOrEmpty(subject.ContactMethodCode3) || subject.Quantity3 > 0)
		{
			subject.ContactMethodCode3 = "g";
			subject.Quantity3 = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("g", 8, true)]
	[InlineData("g", 0, false)]
	[InlineData("", 8, false)]
	public void Validation_AllAreRequiredContactMethodCode3(string contactMethodCode3, decimal quantity3, bool isValidExpected)
	{
		var subject = new MRC_MortgagorResponseCharacteristics();
		//Required fields
		subject.EntityIdentifierCode = "JI";
		subject.MortgagorResponseCode = "z";
		subject.ContactMethodCode = "3";
		subject.Quantity = 7;
		//Test Parameters
		subject.ContactMethodCode3 = contactMethodCode3;
		if (quantity3 > 0) 
			subject.Quantity3 = quantity3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ContactMethodCode2) || !string.IsNullOrEmpty(subject.ContactMethodCode2) || subject.Quantity2 > 0)
		{
			subject.ContactMethodCode2 = "Q";
			subject.Quantity2 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
