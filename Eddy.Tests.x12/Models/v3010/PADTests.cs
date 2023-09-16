using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class PADTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PAD*b*KB*Gv*Q3S*3";

		var expected = new PAD_ProductAdjustmentDetail()
		{
			AssignedIdentification = "b",
			ProductTransferTypeCode = "KB",
			ChangeOrResponseTypeCode = "Gv",
			PriceMultiplierQualifier = "Q3S",
			Multiplier = 3,
		};

		var actual = Map.MapObject<PAD_ProductAdjustmentDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
