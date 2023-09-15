using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class M2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M2*Fr*wsmv*kCbt0vL0*4UY*FV*A1D1etAY*a*K";

		var expected = new M2_SalesDeliveryTerms()
		{
			SalesTermsCode = "Fr",
			SalesReferenceNumber = "wsmv",
			SalesReferenceDate = "kCbt0vL0",
			TransportationTermsCode = "4UY",
			SalesComment = "FV",
			DeliveryDate = "A1D1etAY",
			LocationQualifier = "a",
			LocationIdentifier = "K",
		};

		var actual = Map.MapObject<M2_SalesDeliveryTerms>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Fr", true)]
	public void Validation_RequiredSalesTermsCode(string salesTermsCode, bool isValidExpected)
	{
		var subject = new M2_SalesDeliveryTerms();
		subject.SalesTermsCode = salesTermsCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "a";
			subject.LocationIdentifier = "K";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("a", "K", true)]
	[InlineData("a", "", false)]
	[InlineData("", "K", false)]
	public void Validation_AllAreRequiredLocationQualifier(string locationQualifier, string locationIdentifier, bool isValidExpected)
	{
		var subject = new M2_SalesDeliveryTerms();
		subject.SalesTermsCode = "Fr";
		subject.LocationQualifier = locationQualifier;
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
