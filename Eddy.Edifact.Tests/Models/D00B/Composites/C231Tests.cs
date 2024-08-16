using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C231Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "w:k:t";

		var expected = new C231_MethodOfPayment()
		{
			TransportChargesPaymentMethodCode = "w",
			CodeListIdentificationCode = "k",
			CodeListResponsibleAgencyCode = "t",
		};

		var actual = Map.MapComposite<C231_MethodOfPayment>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredTransportChargesPaymentMethodCode(string transportChargesPaymentMethodCode, bool isValidExpected)
	{
		var subject = new C231_MethodOfPayment();
		//Required fields
		//Test Parameters
		subject.TransportChargesPaymentMethodCode = transportChargesPaymentMethodCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
