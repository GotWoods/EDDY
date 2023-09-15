using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G21Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G21*K*6ooVRI*egYdV77NKeZX*ev8MEaHtbVOi*7*5";

		var expected = new G21_ProductInformation()
		{
			AuthorizeDeAuthorizeCode = "K",
			Date = "6ooVRI",
			UPCConsumerPackageCode = "egYdV77NKeZX",
			UPCCaseCode = "ev8MEaHtbVOi",
			Pack = 7,
			UnitPrice = 5,
		};

		var actual = Map.MapObject<G21_ProductInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredAuthorizeDeAuthorizeCode(string authorizeDeAuthorizeCode, bool isValidExpected)
	{
		var subject = new G21_ProductInformation();
		subject.Date = "6ooVRI";
		subject.UPCConsumerPackageCode = "egYdV77NKeZX";
		subject.AuthorizeDeAuthorizeCode = authorizeDeAuthorizeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6ooVRI", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new G21_ProductInformation();
		subject.AuthorizeDeAuthorizeCode = "K";
		subject.UPCConsumerPackageCode = "egYdV77NKeZX";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("egYdV77NKeZX", true)]
	public void Validation_RequiredUPCConsumerPackageCode(string uPCConsumerPackageCode, bool isValidExpected)
	{
		var subject = new G21_ProductInformation();
		subject.AuthorizeDeAuthorizeCode = "K";
		subject.Date = "6ooVRI";
		subject.UPCConsumerPackageCode = uPCConsumerPackageCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
