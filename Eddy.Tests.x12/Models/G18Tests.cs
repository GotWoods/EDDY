using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G18Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G18*Lw*e*9*Wb";

		var expected = new G18_StoreCategorySize()
		{
			EntityIdentifierCode = "Lw",
			IndustryCode = "e",
			Length = 9,
			UnitOrBasisForMeasurementCode = "Wb",
		};

		var actual = Map.MapObject<G18_StoreCategorySize>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Lw", "e", false)]
	[InlineData("", "e", true)]
	[InlineData("Lw", "", true)]
	public void Validation_OnlyOneOfEntityIdentifierCode(string entityIdentifierCode, string industryCode, bool isValidExpected)
	{
		var subject = new G18_StoreCategorySize();
		subject.EntityIdentifierCode = entityIdentifierCode;
		subject.IndustryCode = industryCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(9, "Wb", true)]
	[InlineData(0, "Wb", false)]
	[InlineData(9, "", false)]
	public void Validation_AllAreRequiredLength(decimal length, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G18_StoreCategorySize();
		if (length > 0)
		subject.Length = length;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
