using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class CIVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CIV*ku*J*5*q0*q*p*wE*I*Bs*jntu5*rs*Od*u*WQN*u4*0*K*E";

		var expected = new CIV_CivilActionLiability()
		{
			PublicRecordOrObligationCode = "ku",
			AmountQualifierCode = "J",
			MonetaryAmount = 5,
			RateValueQualifier = "q0",
			Name = "q",
			Name2 = "p",
			ReferenceIdentificationQualifier = "wE",
			ReferenceIdentification = "I",
			CityName = "Bs",
			CountyDesignatorCode = "jntu5",
			StateOrProvinceCode = "rs",
			DateTimePeriodFormatQualifier = "Od",
			DateTimePeriod = "u",
			DateTimeQualifier = "WQN",
			DateTimePeriodFormatQualifier2 = "u4",
			DateTimePeriod2 = "0",
			Description = "K",
			ReferenceIdentification2 = "E",
		};

		var actual = Map.MapObject<CIV_CivilActionLiability>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ku", true)]
	public void Validatation_RequiredPublicRecordOrObligationCode(string publicRecordOrObligationCode, bool isValidExpected)
	{
		var subject = new CIV_CivilActionLiability();
		subject.AmountQualifierCode = "J";
		subject.MonetaryAmount = 5;
		subject.PublicRecordOrObligationCode = publicRecordOrObligationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validatation_RequiredAmountQualifierCode(string amountQualifierCode, bool isValidExpected)
	{
		var subject = new CIV_CivilActionLiability();
		subject.PublicRecordOrObligationCode = "ku";
		subject.MonetaryAmount = 5;
		subject.AmountQualifierCode = amountQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validatation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new CIV_CivilActionLiability();
		subject.PublicRecordOrObligationCode = "ku";
		subject.AmountQualifierCode = "J";
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("wE", "I", true)]
	[InlineData("", "I", false)]
	[InlineData("wE", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new CIV_CivilActionLiability();
		subject.PublicRecordOrObligationCode = "ku";
		subject.AmountQualifierCode = "J";
		subject.MonetaryAmount = 5;
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Od", "u", true)]
	[InlineData("", "u", false)]
	[InlineData("Od", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new CIV_CivilActionLiability();
		subject.PublicRecordOrObligationCode = "ku";
		subject.AmountQualifierCode = "J";
		subject.MonetaryAmount = 5;
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("u4", "0", true)]
	[InlineData("", "0", false)]
	[InlineData("u4", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier2(string dateTimePeriodFormatQualifier2, string dateTimePeriod2, bool isValidExpected)
	{
		var subject = new CIV_CivilActionLiability();
		subject.PublicRecordOrObligationCode = "ku";
		subject.AmountQualifierCode = "J";
		subject.MonetaryAmount = 5;
		subject.DateTimePeriodFormatQualifier2 = dateTimePeriodFormatQualifier2;
		subject.DateTimePeriod2 = dateTimePeriod2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
