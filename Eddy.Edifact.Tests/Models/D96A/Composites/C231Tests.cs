using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C231Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "L:r:u";

		var expected = new C231_MethodOfPayment()
		{
			TransportChargesMethodOfPaymentCoded = "L",
			CodeListQualifier = "r",
			CodeListResponsibleAgencyCoded = "u",
		};

		var actual = Map.MapComposite<C231_MethodOfPayment>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredTransportChargesMethodOfPaymentCoded(string transportChargesMethodOfPaymentCoded, bool isValidExpected)
	{
		var subject = new C231_MethodOfPayment();
		//Required fields
		//Test Parameters
		subject.TransportChargesMethodOfPaymentCoded = transportChargesMethodOfPaymentCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
