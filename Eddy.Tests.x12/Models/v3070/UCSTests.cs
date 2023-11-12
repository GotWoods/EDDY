using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3070.Composites;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class UCSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "UCS*wu*Y*9*m*Cy*F*8*";

		var expected = new UCS_UnderwritingConsiderations()
		{
			CodeCategory = "wu",
			Description = "Y",
			ItemDescriptionType = "9",
			Description2 = "m",
			ProductServiceIDQualifier = "Cy",
			ProductServiceID = "F",
			Number = 8,
			CompositeUnitOfMeasure = null,
		};

		var actual = Map.MapObject<UCS_UnderwritingConsiderations>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("9", "m", true)]
	[InlineData("9", "", false)]
	[InlineData("", "m", false)]
	public void Validation_AllAreRequiredItemDescriptionType(string itemDescriptionType, string description2, bool isValidExpected)
	{
		var subject = new UCS_UnderwritingConsiderations();
		//Required fields
		//Test Parameters
		subject.ItemDescriptionType = itemDescriptionType;
		subject.Description2 = description2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Cy";
			subject.ProductServiceID = "F";
		}
		if(subject.Number > 0 || subject.Number > 0 || subject.Number != null)
		{
			subject.Number = 8;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Cy", "F", true)]
	[InlineData("Cy", "", false)]
	[InlineData("", "F", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new UCS_UnderwritingConsiderations();
		//Required fields
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ItemDescriptionType) || !string.IsNullOrEmpty(subject.ItemDescriptionType) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ItemDescriptionType = "9";
			subject.Description2 = "m";
		}
		if(subject.Number > 0 || subject.Number > 0 || subject.Number != null)
		{
			subject.Number = 8;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "A", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "A", false)]
	public void Validation_AllAreRequiredNumber(int number, string compositeUnitOfMeasure, bool isValidExpected)
	{
		var subject = new UCS_UnderwritingConsiderations();
		//Required fields
		//Test Parameters
		if (number > 0) 
			subject.Number = number;
		if (compositeUnitOfMeasure != "") 
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ItemDescriptionType) || !string.IsNullOrEmpty(subject.ItemDescriptionType) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ItemDescriptionType = "9";
			subject.Description2 = "m";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Cy";
			subject.ProductServiceID = "F";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
