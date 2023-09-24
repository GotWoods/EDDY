using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class PRITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PRI*ny*z*T*M*r*F*N*Tg*z*vW*v*Z*2*HD";

		var expected = new PRI_ExternalReferenceIdentifier()
		{
			ReferenceUsageCode = "ny",
			TariffAgencyCode = "z",
			TariffNumber = "T",
			TariffNumberSuffix = "M",
			TariffSupplementIdentifier = "r",
			TariffSection = "F",
			TariffItemNumber = "N",
			ReferenceNumberQualifier = "Tg",
			ReferenceNumber = "z",
			StandardCarrierAlphaCode = "vW",
			DocketControlNumber = "v",
			DocketIdentification = "Z",
			RevisionNumber = 2,
			GroupTitle = "HD",
		};

		var actual = Map.MapObject<PRI_ExternalReferenceIdentifier>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ny", true)]
	public void Validation_RequiredReferenceUsageCode(string referenceUsageCode, bool isValidExpected)
	{
		var subject = new PRI_ExternalReferenceIdentifier();
		subject.TariffAgencyCode = "z";
		subject.TariffNumber = "T";
		subject.ReferenceUsageCode = referenceUsageCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredTariffAgencyCode(string tariffAgencyCode, bool isValidExpected)
	{
		var subject = new PRI_ExternalReferenceIdentifier();
		subject.ReferenceUsageCode = "ny";
		subject.TariffNumber = "T";
		subject.TariffAgencyCode = tariffAgencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredTariffNumber(string tariffNumber, bool isValidExpected)
	{
		var subject = new PRI_ExternalReferenceIdentifier();
		subject.ReferenceUsageCode = "ny";
		subject.TariffAgencyCode = "z";
		subject.TariffNumber = tariffNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
