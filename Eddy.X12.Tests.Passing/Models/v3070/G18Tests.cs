using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class G18Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G18*AA*I*7*TU";

		var expected = new G18_StoreCategorySize()
		{
			EntityIdentifierCode = "AA",
			IndustryCode = "I",
			Length = 7,
			UnitOrBasisForMeasurementCode = "TU",
		};

		var actual = Map.MapObject<G18_StoreCategorySize>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("AA", "I", false)]
	[InlineData("AA", "", true)]
	[InlineData("", "I", true)]
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
			subject.Length = 7;
			subject.UnitOrBasisForMeasurementCode = "TU";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "TU", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "TU", false)]
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
