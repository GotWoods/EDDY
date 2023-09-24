using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G84Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G84*4*R*Y";

		var expected = new G84_DeliveryReturnRecordOfTotals()
		{
			Quantity = 4,
			TotalInvoiceAmount = "R",
			TotalDepositDollarAmount = "Y",
		};

		var actual = Map.MapObject<G84_DeliveryReturnRecordOfTotals>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
