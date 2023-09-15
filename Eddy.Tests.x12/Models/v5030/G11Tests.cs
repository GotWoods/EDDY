using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class G11Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G11*S*e*S*d*9*k*PT*2*i*c";

		var expected = new G11_CouponReportingSpecifications()
		{
			ReportingStructureIdentifier = "S",
			Category = "e",
			Category2 = "S",
			Category3 = "d",
			Category4 = "9",
			Category5 = "k",
			ReferenceIdentificationQualifier = "PT",
			ReferenceIdentification = "2",
			YesNoConditionOrResponseCode = "i",
			FreeFormDescription = "c",
		};

		var actual = Map.MapObject<G11_CouponReportingSpecifications>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredReportingStructureIdentifier(string reportingStructureIdentifier, bool isValidExpected)
	{
		var subject = new G11_CouponReportingSpecifications();
		subject.Category = "e";
		subject.ReportingStructureIdentifier = reportingStructureIdentifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "PT";
			subject.ReferenceIdentification = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredCategory(string category, bool isValidExpected)
	{
		var subject = new G11_CouponReportingSpecifications();
		subject.ReportingStructureIdentifier = "S";
		subject.Category = category;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "PT";
			subject.ReferenceIdentification = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("PT", "2", true)]
	[InlineData("PT", "", false)]
	[InlineData("", "2", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new G11_CouponReportingSpecifications();
		subject.ReportingStructureIdentifier = "S";
		subject.Category = "e";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
