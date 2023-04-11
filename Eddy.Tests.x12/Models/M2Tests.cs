using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class M2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M2*OW*fHxy*5VvyCE69*Fcn*M6*rQHttyGC*V*i";

		var expected = new M2_SalesDeliveryTerms()
		{
			SalesTermsCode = "OW",
			SalesReferenceNumber = "fHxy",
			SalesReferenceDate = "5VvyCE69",
			TransportationTermsCode = "Fcn",
			SalesComment = "M6",
			DeliveryDate = "rQHttyGC",
			LocationQualifier = "V",
			LocationIdentifier = "i",
		};

		var actual = Map.MapObject<M2_SalesDeliveryTerms>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("OW", true)]
	public void Validation_RequiredSalesTermsCode(string salesTermsCode, bool isValidExpected)
	{
		var subject = new M2_SalesDeliveryTerms();
		subject.SalesTermsCode = salesTermsCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("V", "i", true)]
	[InlineData("", "i", false)]
	[InlineData("V", "", false)]
	public void Validation_AllAreRequiredLocationQualifier(string locationQualifier, string locationIdentifier, bool isValidExpected)
	{
		var subject = new M2_SalesDeliveryTerms();
		subject.SalesTermsCode = "OW";
		subject.LocationQualifier = locationQualifier;
		subject.LocationIdentifier = locationIdentifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
