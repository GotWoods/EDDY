using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G70Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G70*9*8*ZF*Q2*G*TF*1*v*967417";

		var expected = new G70_LineItemDetailMiscellaneous()
		{
			Pack = 9,
			Size = 8,
			UnitOfMeasurementCode = "ZF",
			PurchaseOrderInstructionCode = "Q2",
			PriceReasonCode = "G",
			TermsExceptionCode = "TF",
			TaxExemptCode = "1",
			Color = "v",
			PalletBlockAndTiers = 967417,
		};

		var actual = Map.MapObject<G70_LineItemDetailMiscellaneous>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
