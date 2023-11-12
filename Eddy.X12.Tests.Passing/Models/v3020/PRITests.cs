using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class PRITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PRI*zC*W*P*Y*0*A*a*pg*H*jH*e*a*9*ES";

		var expected = new PRI_ExternalReferenceIdentifier()
		{
			ReferenceUsageCode = "zC",
			TariffAgencyCode = "W",
			TariffNumber = "P",
			TariffNumberSuffix = "Y",
			TariffSupplementIdentifier = "0",
			TariffSection = "A",
			TariffItemNumber = "a",
			ReferenceNumberQualifier = "pg",
			ReferenceNumber = "H",
			StandardCarrierAlphaCode = "jH",
			DocketControlNumber = "e",
			DocketIdentification = "a",
			RevisionNumber = 9,
			GroupTitle = "ES",
		};

		var actual = Map.MapObject<PRI_ExternalReferenceIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zC", true)]
	public void Validation_RequiredReferenceUsageCode(string referenceUsageCode, bool isValidExpected)
	{
		var subject = new PRI_ExternalReferenceIdentifier();
		subject.TariffAgencyCode = "W";
		subject.TariffNumber = "P";
		subject.ReferenceUsageCode = referenceUsageCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "pg";
			subject.ReferenceNumber = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredTariffAgencyCode(string tariffAgencyCode, bool isValidExpected)
	{
		var subject = new PRI_ExternalReferenceIdentifier();
		subject.ReferenceUsageCode = "zC";
		subject.TariffNumber = "P";
		subject.TariffAgencyCode = tariffAgencyCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "pg";
			subject.ReferenceNumber = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredTariffNumber(string tariffNumber, bool isValidExpected)
	{
		var subject = new PRI_ExternalReferenceIdentifier();
		subject.ReferenceUsageCode = "zC";
		subject.TariffAgencyCode = "W";
		subject.TariffNumber = tariffNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "pg";
			subject.ReferenceNumber = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("pg", "H", true)]
	[InlineData("pg", "", false)]
	[InlineData("", "H", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new PRI_ExternalReferenceIdentifier();
		subject.ReferenceUsageCode = "zC";
		subject.TariffAgencyCode = "W";
		subject.TariffNumber = "P";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
