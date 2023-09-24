using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class G70Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G70*7*5*tQ*VK*d*1O*n*5*223857*9";

		var expected = new G70_LineItemDetailMiscellaneous()
		{
			Pack = 7,
			Size = 5,
			UnitOrBasisForMeasurementCode = "tQ",
			PurchaseOrderInstructionCode = "VK",
			PriceReasonCode = "d",
			TermsExceptionCode = "1O",
			TaxExemptCode = "n",
			Color = "5",
			PalletBlockAndTiers = 223857,
			InnerPack = 9,
		};

		var actual = Map.MapObject<G70_LineItemDetailMiscellaneous>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "tQ", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "tQ", false)]
	public void Validation_AllAreRequiredSize(decimal size, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G70_LineItemDetailMiscellaneous();
		if (size > 0)
			subject.Size = size;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
