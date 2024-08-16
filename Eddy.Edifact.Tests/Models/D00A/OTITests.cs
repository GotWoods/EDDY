using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class OTITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "OTI++N++G+c++L+1+V";

		var expected = new OTI_OtherInsurance()
		{
			ObjectIdentification = null,
			PayerResponsibilityLevelCode = "N",
			DateTimePeriod = null,
			ServiceTypeCode = "G",
			MonetaryAmount = "c",
			AdjustmentInformation = null,
			InsuranceCoverTypeCode = "L",
			RelationshipDescriptionCode = "1",
			YesOrNoIndicatorCode = "V",
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
		subject.PayerResponsibilityLevelCode = "N";
		//Test Parameters
		if (objectIdentification != "") 
			subject.ObjectIdentification = new E206_ObjectIdentification();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
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
