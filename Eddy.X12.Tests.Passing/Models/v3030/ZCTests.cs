using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class ZCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ZC*2ze*7*v*m*1*qZsIDL*Ob*Ej";

		var expected = new ZC_CorrectionOrChangeReferenceInformation()
		{
			TransactionSetIdentifierCode = "2ze",
			ShipmentIdentificationNumber = "7",
			EquipmentInitial = "v",
			EquipmentNumber = "m",
			TransactionReferenceNumber = "1",
			TransactionReferenceDate = "qZsIDL",
			CorrectionIndicator = "Ob",
			StandardCarrierAlphaCode = "Ej",
		};

		var actual = Map.MapObject<ZC_CorrectionOrChangeReferenceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ob", true)]
	public void Validation_RequiredCorrectionIndicator(string correctionIndicator, bool isValidExpected)
	{
		var subject = new ZC_CorrectionOrChangeReferenceInformation();
		//Required fields
		//Test Parameters
		subject.CorrectionIndicator = correctionIndicator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
