using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class UCSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "UCS*uI*R*t*M*mC*D*6*";

		var expected = new UCS_UnderwritingConsiderations()
		{
			CodeCategory = "uI",
			Description = "R",
			ItemDescriptionTypeCode = "t",
			Description2 = "M",
			ProductServiceIDQualifier = "mC",
			ProductServiceID = "D",
			Number = 6,
			CompositeUnitOfMeasure = null,
		};

		var actual = Map.MapObject<UCS_UnderwritingConsiderations>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("t", "M", true)]
	[InlineData("t", "", false)]
	[InlineData("", "M", false)]
	public void Validation_AllAreRequiredItemDescriptionTypeCode(string itemDescriptionTypeCode, string description2, bool isValidExpected)
	{
		var subject = new UCS_UnderwritingConsiderations();
		//Required fields
		//Test Parameters
		subject.ItemDescriptionTypeCode = itemDescriptionTypeCode;
		subject.Description2 = description2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "mC";
			subject.ProductServiceID = "D";
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
	[InlineData("mC", "D", true)]
	[InlineData("mC", "", false)]
	[InlineData("", "D", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new UCS_UnderwritingConsiderations();
		//Required fields
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ItemDescriptionTypeCode) || !string.IsNullOrEmpty(subject.ItemDescriptionTypeCode) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ItemDescriptionTypeCode = "t";
			subject.Description2 = "M";
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
		if(!string.IsNullOrEmpty(subject.ItemDescriptionTypeCode) || !string.IsNullOrEmpty(subject.ItemDescriptionTypeCode) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ItemDescriptionTypeCode = "t";
			subject.Description2 = "M";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "mC";
			subject.ProductServiceID = "D";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
