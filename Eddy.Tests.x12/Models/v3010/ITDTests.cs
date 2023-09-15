using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class ITDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ITD*2g*c*9*3m3E11*3*xH5QWn*7*v*YVibqS*9*6*z*3*i";

		var expected = new ITD_TermsOfSaleDeferredTermsOfSale()
		{
			TermsTypeCode = "2g",
			TermsBasisDateCode = "c",
			TermsDiscountPercent = 9,
			TermsDiscountDueDate = "3m3E11",
			TermsDiscountDaysDue = 3,
			TermsNetDueDate = "xH5QWn",
			TermsNetDays = 7,
			TermsDiscountAmount = "v",
			TermsDeferredDueDate = "YVibqS",
			DeferredAmountDue = "9",
			PercentOfInvoicePayable = 6,
			Description = "z",
			DayOfMonth = 3,
			PaymentMethodCode = "i",
		};

		var actual = Map.MapObject<ITD_TermsOfSaleDeferredTermsOfSale>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
