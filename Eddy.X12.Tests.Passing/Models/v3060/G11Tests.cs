using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class G11Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G11*I*e*4*x*H*S*TP*r*G*M";

		var expected = new G11_CouponReportingSpecifications()
		{
			Level = "I",
			Category = "e",
			Category2 = "4",
			Category3 = "x",
			Category4 = "H",
			Category5 = "S",
			ReferenceIdentificationQualifier = "TP",
			ReferenceIdentification = "r",
			YesNoConditionOrResponseCode = "G",
			FreeFormDescription = "M",
		};

		var actual = Map.MapObject<G11_CouponReportingSpecifications>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredLevel(string level, bool isValidExpected)
	{
		var subject = new G11_CouponReportingSpecifications();
		subject.Category = "e";
		subject.Level = level;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "TP";
			subject.ReferenceIdentification = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredCategory(string category, bool isValidExpected)
	{
		var subject = new G11_CouponReportingSpecifications();
		subject.Level = "I";
		subject.Category = category;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "TP";
			subject.ReferenceIdentification = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("TP", "r", true)]
	[InlineData("TP", "", false)]
	[InlineData("", "r", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new G11_CouponReportingSpecifications();
		subject.Level = "I";
		subject.Category = "e";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
