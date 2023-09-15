using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class G11Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G11*B*M*t*c*n*l*Dk*R*i*e";

		var expected = new G11_CouponReportingSpecifications()
		{
			ReportingStructureIdentifier = "B",
			Category = "M",
			Category2 = "t",
			Category3 = "c",
			Category4 = "n",
			Category5 = "l",
			ReferenceIdentificationQualifier = "Dk",
			ReferenceIdentification = "R",
			YesNoConditionOrResponseCode = "i",
			FreeFormDescription = "e",
		};

		var actual = Map.MapObject<G11_CouponReportingSpecifications>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredReportingStructureIdentifier(string reportingStructureIdentifier, bool isValidExpected)
	{
		var subject = new G11_CouponReportingSpecifications();
		subject.Category = "M";
		subject.ReportingStructureIdentifier = reportingStructureIdentifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "Dk";
			subject.ReferenceIdentification = "R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredCategory(string category, bool isValidExpected)
	{
		var subject = new G11_CouponReportingSpecifications();
		subject.ReportingStructureIdentifier = "B";
		subject.Category = category;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "Dk";
			subject.ReferenceIdentification = "R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Dk", "R", true)]
	[InlineData("Dk", "", false)]
	[InlineData("", "R", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new G11_CouponReportingSpecifications();
		subject.ReportingStructureIdentifier = "B";
		subject.Category = "M";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
