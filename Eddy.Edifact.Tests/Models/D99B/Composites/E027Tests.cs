using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E027Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "5:x";

		var expected = new E027_InvoiceType()
		{
			InvoiceTypeCode = "5",
			FrequencyCode = "x",
		};

		var actual = Map.MapComposite<E027_InvoiceType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredInvoiceTypeCode(string invoiceTypeCode, bool isValidExpected)
	{
		var subject = new E027_InvoiceType();
		//Required fields
		//Test Parameters
		subject.InvoiceTypeCode = invoiceTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
