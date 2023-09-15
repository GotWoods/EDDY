using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class M2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M2*lq*l0QD*Cqo91b*Rk3*ge*F5PTPI*o*m";

		var expected = new M2_SalesDeliveryTerms()
		{
			SalesTermsCode = "lq",
			SalesReferenceNumber = "l0QD",
			SalesReferenceDate = "Cqo91b",
			TransportationTermsCode = "Rk3",
			SalesComment = "ge",
			DeliveryDate = "F5PTPI",
			LocationQualifier = "o",
			LocationIdentifier = "m",
		};

		var actual = Map.MapObject<M2_SalesDeliveryTerms>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lq", true)]
	public void Validation_RequiredSalesTermsCode(string salesTermsCode, bool isValidExpected)
	{
		var subject = new M2_SalesDeliveryTerms();
		subject.SalesTermsCode = salesTermsCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "o";
			subject.LocationIdentifier = "m";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("o", "m", true)]
	[InlineData("o", "", false)]
	[InlineData("", "m", false)]
	public void Validation_AllAreRequiredLocationQualifier(string locationQualifier, string locationIdentifier, bool isValidExpected)
	{
		var subject = new M2_SalesDeliveryTerms();
		subject.SalesTermsCode = "lq";
		subject.LocationQualifier = locationQualifier;
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
