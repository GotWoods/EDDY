using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class G18Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G18*68*S*5*nn";

		var expected = new G18_StoreCategorySize()
		{
			EntityIdentifierCode = "68",
			IndustryCode = "S",
			Length = 5,
			UnitOrBasisForMeasurementCode = "nn",
		};

		var actual = Map.MapObject<G18_StoreCategorySize>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("68", "S", false)]
	[InlineData("68", "", true)]
	[InlineData("", "S", true)]
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
			subject.Length = 5;
			subject.UnitOrBasisForMeasurementCode = "nn";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "nn", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "nn", false)]
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
