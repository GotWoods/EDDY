using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models;

public class UCSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "UCS*if*p*S*u*98*H*5*";

		var expected = new UCS_UnderwritingConsiderations()
		{
			CodeCategory = "if",
			Description = "p",
			ItemDescriptionTypeCode = "S",
			Description2 = "u",
			ProductServiceIDQualifier = "98",
			ProductServiceID = "H",
			Number = 5,
			CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure(),
		};

		var actual = Map.MapObject<UCS_UnderwritingConsiderations>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("S", "u", true)]
	[InlineData("", "u", false)]
	[InlineData("S", "", false)]
	public void Validation_AllAreRequiredItemDescriptionTypeCode(string itemDescriptionTypeCode, string description2, bool isValidExpected)
	{
		var subject = new UCS_UnderwritingConsiderations();
		subject.ItemDescriptionTypeCode = itemDescriptionTypeCode;
		subject.Description2 = description2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("98", "H", true)]
	[InlineData("", "H", false)]
	[InlineData("98", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new UCS_UnderwritingConsiderations();
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(5, "AA", true)]
	[InlineData(0, "AA", false)]
	[InlineData(5, "", false)]
	public void Validation_AllAreRequiredNumber(int number, string compositeUnitOfMeasure, bool isValidExpected)
	{
		var subject = new UCS_UnderwritingConsiderations();
		if (number > 0)
		subject.Number = number;
        if (compositeUnitOfMeasure != "")
            subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure() { UnitOrBasisForMeasurementCode = compositeUnitOfMeasure };
        

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
