using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class OTITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "OTI++U++s+B++q+W+R";

		var expected = new OTI_OtherInsurance()
		{
			ObjectIdentification = null,
			PayerResponsibilityLevelCode = "U",
			DateTimePeriod = null,
			ServiceTypeCode = "s",
			MonetaryAmountValue = "B",
			AdjustmentInformation = null,
			InsuranceCoverTypeCode = "q",
			RelationshipDescriptionCode = "W",
			YesNoCode = "R",
		};

		var actual = Map.MapObject<OTI_OtherInsurance>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredObjectIdentification(string objectIdentification, bool isValidExpected)
	{
		var subject = new OTI_OtherInsurance();
		//Required fields
		subject.PayerResponsibilityLevelCode = "U";
		//Test Parameters
		if (objectIdentification != "") 
			subject.ObjectIdentification = new E206_ObjectIdentification();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredPayerResponsibilityLevelCode(string payerResponsibilityLevelCode, bool isValidExpected)
	{
		var subject = new OTI_OtherInsurance();
		//Required fields
		subject.ObjectIdentification = new E206_ObjectIdentification();
		//Test Parameters
		subject.PayerResponsibilityLevelCode = payerResponsibilityLevelCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
