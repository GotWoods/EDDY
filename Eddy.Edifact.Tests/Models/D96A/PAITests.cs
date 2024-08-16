using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class PAITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PAI+";

		var expected = new PAI_PaymentInstructions()
		{
			PaymentInstructionDetails = null,
		};

		var actual = Map.MapObject<PAI_PaymentInstructions>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredPaymentInstructionDetails(string paymentInstructionDetails, bool isValidExpected)
	{
		var subject = new PAI_PaymentInstructions();
		//Required fields
		//Test Parameters
		if (paymentInstructionDetails != "") 
			subject.PaymentInstructionDetails = new C534_PaymentInstructionDetails();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
