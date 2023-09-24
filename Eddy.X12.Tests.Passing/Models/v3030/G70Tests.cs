using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class G70Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G70*7*3*H7*7T*K*5k*J*p*696321";

		var expected = new G70_LineItemDetailMiscellaneous()
		{
			Pack = 7,
			Size = 3,
			UnitOrBasisForMeasurementCode = "H7",
			PurchaseOrderInstructionCode = "7T",
			PriceReasonCode = "K",
			TermsExceptionCode = "5k",
			TaxExemptCode = "J",
			Color = "p",
			PalletBlockAndTiers = 696321,
		};

		var actual = Map.MapObject<G70_LineItemDetailMiscellaneous>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "H7", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "H7", false)]
	public void Validation_AllAreRequiredSize(decimal size, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G70_LineItemDetailMiscellaneous();
		if (size > 0)
			subject.Size = size;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
