using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class MRCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MRC*Xe*d*c*1*U*B*1*X*1";

		var expected = new MRC_MortgagorResponseCharacteristics()
		{
			EntityIdentifierCode = "Xe",
			MortgagorResponseCode = "d",
			ContactMethodCode = "c",
			Quantity = 1,
			DateTimePeriod = "U",
			ContactMethodCode2 = "B",
			Quantity2 = 1,
			ContactMethodCode3 = "X",
			Quantity3 = 1,
		};

		var actual = Map.MapObject<MRC_MortgagorResponseCharacteristics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Xe", true)]
	public void Validation_RequiredEntityIdentifierCode(string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new MRC_MortgagorResponseCharacteristics();
		//Required fields
		subject.MortgagorResponseCode = "d";
		subject.ContactMethodCode = "c";
		subject.Quantity = 1;
		//Test Parameters
		subject.EntityIdentifierCode = entityIdentifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ContactMethodCode2) || !string.IsNullOrEmpty(subject.ContactMethodCode2) || subject.Quantity2 > 0)
		{
			subject.ContactMethodCode2 = "B";
			subject.Quantity2 = 1;
		}
		if(!string.IsNullOrEmpty(subject.ContactMethodCode3) || !string.IsNullOrEmpty(subject.ContactMethodCode3) || subject.Quantity3 > 0)
		{
			subject.ContactMethodCode3 = "X";
			subject.Quantity3 = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredMortgagorResponseCode(string mortgagorResponseCode, bool isValidExpected)
	{
		var subject = new MRC_MortgagorResponseCharacteristics();
		//Required fields
		subject.EntityIdentifierCode = "Xe";
		subject.ContactMethodCode = "c";
		subject.Quantity = 1;
		//Test Parameters
		subject.MortgagorResponseCode = mortgagorResponseCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ContactMethodCode2) || !string.IsNullOrEmpty(subject.ContactMethodCode2) || subject.Quantity2 > 0)
		{
			subject.ContactMethodCode2 = "B";
			subject.Quantity2 = 1;
		}
		if(!string.IsNullOrEmpty(subject.ContactMethodCode3) || !string.IsNullOrEmpty(subject.ContactMethodCode3) || subject.Quantity3 > 0)
		{
			subject.ContactMethodCode3 = "X";
			subject.Quantity3 = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredContactMethodCode(string contactMethodCode, bool isValidExpected)
	{
		var subject = new MRC_MortgagorResponseCharacteristics();
		//Required fields
		subject.EntityIdentifierCode = "Xe";
		subject.MortgagorResponseCode = "d";
		subject.Quantity = 1;
		//Test Parameters
		subject.ContactMethodCode = contactMethodCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ContactMethodCode2) || !string.IsNullOrEmpty(subject.ContactMethodCode2) || subject.Quantity2 > 0)
		{
			subject.ContactMethodCode2 = "B";
			subject.Quantity2 = 1;
		}
		if(!string.IsNullOrEmpty(subject.ContactMethodCode3) || !string.IsNullOrEmpty(subject.ContactMethodCode3) || subject.Quantity3 > 0)
		{
			subject.ContactMethodCode3 = "X";
			subject.Quantity3 = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new MRC_MortgagorResponseCharacteristics();
		//Required fields
		subject.EntityIdentifierCode = "Xe";
		subject.MortgagorResponseCode = "d";
		subject.ContactMethodCode = "c";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ContactMethodCode2) || !string.IsNullOrEmpty(subject.ContactMethodCode2) || subject.Quantity2 > 0)
		{
			subject.ContactMethodCode2 = "B";
			subject.Quantity2 = 1;
		}
		if(!string.IsNullOrEmpty(subject.ContactMethodCode3) || !string.IsNullOrEmpty(subject.ContactMethodCode3) || subject.Quantity3 > 0)
		{
			subject.ContactMethodCode3 = "X";
			subject.Quantity3 = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("B", 1, true)]
	[InlineData("B", 0, false)]
	[InlineData("", 1, false)]
	public void Validation_AllAreRequiredContactMethodCode2(string contactMethodCode2, decimal quantity2, bool isValidExpected)
	{
		var subject = new MRC_MortgagorResponseCharacteristics();
		//Required fields
		subject.EntityIdentifierCode = "Xe";
		subject.MortgagorResponseCode = "d";
		subject.ContactMethodCode = "c";
		subject.Quantity = 1;
		//Test Parameters
		subject.ContactMethodCode2 = contactMethodCode2;
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ContactMethodCode3) || !string.IsNullOrEmpty(subject.ContactMethodCode3) || subject.Quantity3 > 0)
		{
			subject.ContactMethodCode3 = "X";
			subject.Quantity3 = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("X", 1, true)]
	[InlineData("X", 0, false)]
	[InlineData("", 1, false)]
	public void Validation_AllAreRequiredContactMethodCode3(string contactMethodCode3, decimal quantity3, bool isValidExpected)
	{
		var subject = new MRC_MortgagorResponseCharacteristics();
		//Required fields
		subject.EntityIdentifierCode = "Xe";
		subject.MortgagorResponseCode = "d";
		subject.ContactMethodCode = "c";
		subject.Quantity = 1;
		//Test Parameters
		subject.ContactMethodCode3 = contactMethodCode3;
		if (quantity3 > 0) 
			subject.Quantity3 = quantity3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ContactMethodCode2) || !string.IsNullOrEmpty(subject.ContactMethodCode2) || subject.Quantity2 > 0)
		{
			subject.ContactMethodCode2 = "B";
			subject.Quantity2 = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
