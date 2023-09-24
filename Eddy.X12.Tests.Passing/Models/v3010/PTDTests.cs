using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class PTDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PTD*iS*QX3*4*Nz*S*sM";

		var expected = new PTD_ProductTransferAndResaleDetail()
		{
			ProductTransferTypeCode = "iS",
			PriceMultiplierQualifier = "QX3",
			Multiplier = 4,
			ReferenceNumberQualifier = "Nz",
			ReferenceNumber = "S",
			ProductTransferMovementTypeCode = "sM",
		};

		var actual = Map.MapObject<PTD_ProductTransferAndResaleDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("iS", true)]
	public void Validation_RequiredProductTransferTypeCode(string productTransferTypeCode, bool isValidExpected)
	{
		var subject = new PTD_ProductTransferAndResaleDetail();
		subject.ProductTransferTypeCode = productTransferTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
