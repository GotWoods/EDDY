using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class G11Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G11*H*e*S*3*C*3*hp*W*k*r";

		var expected = new G11_CouponReportingSpecifications()
		{
			Level = "H",
			Category = "e",
			Category2 = "S",
			Category3 = "3",
			Category4 = "C",
			Category5 = "3",
			ReferenceIdentificationQualifier = "hp",
			ReferenceIdentification = "W",
			YesNoConditionOrResponseCode = "k",
			FreeFormDescription = "r",
		};

		var actual = Map.MapObject<G11_CouponReportingSpecifications>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredLevel(string level, bool isValidExpected)
	{
		var subject = new G11_CouponReportingSpecifications();
		subject.Category = "e";
		subject.Level = level;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "hp";
			subject.ReferenceIdentification = "W";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredCategory(string category, bool isValidExpected)
	{
		var subject = new G11_CouponReportingSpecifications();
		subject.Level = "H";
		subject.Category = category;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "hp";
			subject.ReferenceIdentification = "W";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("hp", "W", true)]
	[InlineData("hp", "", false)]
	[InlineData("", "W", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new G11_CouponReportingSpecifications();
		subject.Level = "H";
		subject.Category = "e";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
