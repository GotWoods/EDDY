using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class M2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M2*zT*8k88*YtjTc9*1Ow*xk*TQJxnQ";

		var expected = new M2_SalesDeliveryTerms()
		{
			SalesTermsCode = "zT",
			SalesReferenceNumber = "8k88",
			SalesReferenceDate = "YtjTc9",
			TransportationTermsCode = "1Ow",
			SalesComment = "xk",
			DeliveryDate = "TQJxnQ",
		};

		var actual = Map.MapObject<M2_SalesDeliveryTerms>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zT", true)]
	public void Validation_RequiredSalesTermsCode(string salesTermsCode, bool isValidExpected)
	{
		var subject = new M2_SalesDeliveryTerms();
		subject.SalesTermsCode = salesTermsCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
