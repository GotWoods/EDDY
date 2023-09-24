using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class G70Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G70*3*2*IL*SZ*q*Zx*M*w*262174";

		var expected = new G70_LineItemDetailMiscellaneous()
		{
			Pack = 3,
			Size = 2,
			UnitOfMeasurementCode = "IL",
			PurchaseOrderInstructionCode = "SZ",
			PriceReasonCode = "q",
			TermsExceptionCode = "Zx",
			TaxExemptCode = "M",
			Color = "w",
			PalletBlockAndTiers = 262174,
		};

		var actual = Map.MapObject<G70_LineItemDetailMiscellaneous>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "IL", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "IL", false)]
	public void Validation_AllAreRequiredSize(decimal size, string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new G70_LineItemDetailMiscellaneous();
		if (size > 0)
			subject.Size = size;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
