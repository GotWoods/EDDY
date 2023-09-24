using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class M2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M2*10*vCIf*TRfxfH*hK8*Bf*1iN9Zr*8*X";

		var expected = new M2_SalesDeliveryTerms()
		{
			SalesTermsCode = "10",
			SalesReferenceNumber = "vCIf",
			SalesReferenceDate = "TRfxfH",
			TransportationTermsCode = "hK8",
			SalesComment = "Bf",
			DeliveryDate = "1iN9Zr",
			LocationQualifier = "8",
			LocationIdentifier = "X",
		};

		var actual = Map.MapObject<M2_SalesDeliveryTerms>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("10", true)]
	public void Validation_RequiredSalesTermsCode(string salesTermsCode, bool isValidExpected)
	{
		var subject = new M2_SalesDeliveryTerms();
		subject.SalesTermsCode = salesTermsCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "8";
			subject.LocationIdentifier = "X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("8", "X", true)]
	[InlineData("8", "", false)]
	[InlineData("", "X", false)]
	public void Validation_AllAreRequiredLocationQualifier(string locationQualifier, string locationIdentifier, bool isValidExpected)
	{
		var subject = new M2_SalesDeliveryTerms();
		subject.SalesTermsCode = "10";
		subject.LocationQualifier = locationQualifier;
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
