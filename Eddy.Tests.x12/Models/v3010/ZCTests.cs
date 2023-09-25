using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class ZCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ZC*WCS*p*3*K*aF*tzN7nx*4Z*Rr";

		var expected = new ZC_CorrectionOrChangeReferenceInformation()
		{
			TransactionSetIdentifierCode = "WCS",
			ShipmentIdentificationNumber = "p",
			EquipmentInitial = "3",
			EquipmentNumber = "K",
			TransactionReferenceNumber = "aF",
			TransactionReferenceDate = "tzN7nx",
			CorrectionIndicator = "4Z",
			StandardCarrierAlphaCode = "Rr",
		};

		var actual = Map.MapObject<ZC_CorrectionOrChangeReferenceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4Z", true)]
	public void Validation_RequiredCorrectionIndicator(string correctionIndicator, bool isValidExpected)
	{
		var subject = new ZC_CorrectionOrChangeReferenceInformation();
		//Required fields
		//Test Parameters
		subject.CorrectionIndicator = correctionIndicator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
