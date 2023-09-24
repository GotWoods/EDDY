using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G70Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G70*4*8*Mt*Cd*U*R1*R*m*826289*5";

		var expected = new G70_LineItemDetailMiscellaneous()
		{
			Pack = 4,
			Size = 8,
			UnitOrBasisForMeasurementCode = "Mt",
			PurchaseOrderInstructionCode = "Cd",
			PriceReasonCode = "U",
			TermsExceptionCode = "R1",
			TaxExemptCode = "R",
			Color = "m",
			PalletBlockAndTiers = 826289,
			InnerPack = 5,
		};

		var actual = Map.MapObject<G70_LineItemDetailMiscellaneous>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(8, "Mt", true)]
	[InlineData(0, "Mt", false)]
	[InlineData(8, "", false)]
	public void Validation_AllAreRequiredSize(decimal size, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G70_LineItemDetailMiscellaneous();
		if (size > 0)
		subject.Size = size;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
