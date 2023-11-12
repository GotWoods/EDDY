using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class G18Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G18*e7*D*9*BH";

		var expected = new G18_StoreCategorySize()
		{
			EntityIdentifierCode = "e7",
			IndustryCode = "D",
			Length = 9,
			UnitOrBasisForMeasurementCode = "BH",
		};

		var actual = Map.MapObject<G18_StoreCategorySize>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("e7", "D", false)]
	[InlineData("e7", "", true)]
	[InlineData("", "D", true)]
	public void Validation_OnlyOneOfEntityIdentifierCode(string entityIdentifierCode, string industryCode, bool isValidExpected)
	{
		var subject = new G18_StoreCategorySize();
		//Required fields
		//Test Parameters
		subject.EntityIdentifierCode = entityIdentifierCode;
		subject.IndustryCode = industryCode;
		//If one filled, all required
		if(subject.Length > 0 || subject.Length > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Length = 9;
			subject.UnitOrBasisForMeasurementCode = "BH";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "BH", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "BH", false)]
	public void Validation_AllAreRequiredLength(decimal length, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G18_StoreCategorySize();
		//Required fields
		//Test Parameters
		if (length > 0) 
			subject.Length = length;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
