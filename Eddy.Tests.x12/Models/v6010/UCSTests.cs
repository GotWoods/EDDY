using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v6010.Composites;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class UCSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "UCS*RX*Z*2*2*OJ*d*6*";

		var expected = new UCS_UnderwritingConsiderations()
		{
			CodeCategory = "RX",
			Description = "Z",
			ItemDescriptionType = "2",
			Description2 = "2",
			ProductServiceIDQualifier = "OJ",
			ProductServiceID = "d",
			Number = 6,
			CompositeUnitOfMeasure = null,
		};

		var actual = Map.MapObject<UCS_UnderwritingConsiderations>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("2", "2", true)]
	[InlineData("2", "", false)]
	[InlineData("", "2", false)]
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
			subject.ProductServiceIDQualifier = "OJ";
			subject.ProductServiceID = "d";
		}
		if(subject.Number > 0 || subject.Number > 0 || subject.Number != null)
		{
			subject.Number = 6;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("OJ", "d", true)]
	[InlineData("OJ", "", false)]
	[InlineData("", "d", false)]
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
			subject.ItemDescriptionType = "2";
			subject.Description2 = "2";
		}
		if(subject.Number > 0 || subject.Number > 0 || subject.Number != null)
		{
			subject.Number = 6;
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "A", true)]
	[InlineData(6, "", false)]
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
			subject.ItemDescriptionType = "2";
			subject.Description2 = "2";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "OJ";
			subject.ProductServiceID = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
