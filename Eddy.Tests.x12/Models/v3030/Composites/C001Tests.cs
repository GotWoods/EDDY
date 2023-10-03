using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3030;
using Eddy.x12.Models.v3030.Composites;

namespace Eddy.x12.Tests.Models.v3030.Composites;

public class C001Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "Df*7*8*x6*5*3*OQ*4*3*BJ*4*7*QN*8*7";

		var expected = new C001_CompositeUnitOfMeasure()
		{
			UnitOrBasisForMeasurementCode = "Df",
			Exponent = 7,
			Multiplier = 8,
			UnitOrBasisForMeasurementCode2 = "x6",
			Exponent2 = 5,
			Multiplier2 = 3,
			UnitOrBasisForMeasurementCode3 = "OQ",
			Exponent3 = 4,
			Multiplier3 = 3,
			UnitOrBasisForMeasurementCode4 = "BJ",
			Exponent4 = 4,
			Multiplier4 = 7,
			UnitOrBasisForMeasurementCode5 = "QN",
			Exponent5 = 8,
			Multiplier5 = 7,
		};

		var actual = Map.MapObject<C001_CompositeUnitOfMeasure>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Df", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new C001_CompositeUnitOfMeasure();
		//Required fields
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
