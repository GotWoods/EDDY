using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C231Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "P:l:Q";

		var expected = new C231_MethodOfPayment()
		{
			TransportChargesPaymentMethodCode = "P",
			CodeListIdentificationCode = "l",
			CodeListResponsibleAgencyCode = "Q",
		};

		var actual = Map.MapComposite<C231_MethodOfPayment>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredTransportChargesPaymentMethodCode(string transportChargesPaymentMethodCode, bool isValidExpected)
	{
		var subject = new C231_MethodOfPayment();
		//Required fields
		//Test Parameters
		subject.TransportChargesPaymentMethodCode = transportChargesPaymentMethodCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
