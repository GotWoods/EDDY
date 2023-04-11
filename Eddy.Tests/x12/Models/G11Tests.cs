using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G11Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G11*s*Y*O*a*i*X*sy*5*6*d";

		var expected = new G11_CouponReportingSpecifications()
		{
			ReportingStructureIdentifier = "s",
			Category = "Y",
			Category2 = "O",
			Category3 = "a",
			Category4 = "i",
			Category5 = "X",
			ReferenceIdentificationQualifier = "sy",
			ReferenceIdentification = "5",
			YesNoConditionOrResponseCode = "6",
			FreeFormDescription = "d",
		};

		var actual = Map.MapObject<G11_CouponReportingSpecifications>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredReportingStructureIdentifier(string reportingStructureIdentifier, bool isValidExpected)
	{
		var subject = new G11_CouponReportingSpecifications();
		subject.Category = "Y";
		subject.ReportingStructureIdentifier = reportingStructureIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredCategory(string category, bool isValidExpected)
	{
		var subject = new G11_CouponReportingSpecifications();
		subject.ReportingStructureIdentifier = "s";
		subject.Category = category;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("sy", "5", true)]
	[InlineData("", "5", false)]
	[InlineData("sy", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new G11_CouponReportingSpecifications();
		subject.ReportingStructureIdentifier = "s";
		subject.Category = "Y";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
