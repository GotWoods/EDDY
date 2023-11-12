using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class FU2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FU2*Y1*2*9*8*C*P*FXJ*P*i*O4*e";

		var expected = new FU2_DealValue()
		{
			UnitOrBasisForMeasurementCode = "Y1",
			Quantity = 2,
			MonetaryAmount = 9,
			Description = "8",
			YesNoConditionOrResponseCode = "C",
			YesNoConditionOrResponseCode2 = "P",
			TransportationTermsCode = "FXJ",
			LocationQualifier = "P",
			IdentificationCodeQualifier = "i",
			IdentificationCode = "O4",
			Description2 = "e",
		};

		var actual = Map.MapObject<FU2_DealValue>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y1", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new FU2_DealValue();
		//Required fields
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//At Least one
		subject.Quantity = 2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TransportationTermsCode) || !string.IsNullOrEmpty(subject.TransportationTermsCode) || !string.IsNullOrEmpty(subject.LocationQualifier))
		{
			subject.TransportationTermsCode = "FXJ";
			subject.LocationQualifier = "P";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "i";
			subject.IdentificationCode = "O4";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.TransportationTermsCode) || !string.IsNullOrEmpty(subject.TransportationTermsCode) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.TransportationTermsCode = "FXJ";
			subject.IdentificationCodeQualifier = "i";
			subject.Description2 = "e";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, 0, false)]
	[InlineData(2, 0, true)]
	[InlineData(0, 9, true)]
	public void Validation_AtLeastOneQuantity(decimal quantity, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new FU2_DealValue();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "Y1";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TransportationTermsCode) || !string.IsNullOrEmpty(subject.TransportationTermsCode) || !string.IsNullOrEmpty(subject.LocationQualifier))
		{
			subject.TransportationTermsCode = "FXJ";
			subject.LocationQualifier = "P";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "i";
			subject.IdentificationCode = "O4";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.TransportationTermsCode) || !string.IsNullOrEmpty(subject.TransportationTermsCode) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.TransportationTermsCode = "FXJ";
			subject.IdentificationCodeQualifier = "i";
			subject.Description2 = "e";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData(2, 9, false)]
	[InlineData(2, 0, true)]
	[InlineData(0, 9, true)]
	public void Validation_OnlyOneOfQuantity(decimal quantity, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new FU2_DealValue();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "Y1";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TransportationTermsCode) || !string.IsNullOrEmpty(subject.TransportationTermsCode) || !string.IsNullOrEmpty(subject.LocationQualifier))
		{
			subject.TransportationTermsCode = "FXJ";
			subject.LocationQualifier = "P";
		}
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "i";
			subject.IdentificationCode = "O4";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.TransportationTermsCode) || !string.IsNullOrEmpty(subject.TransportationTermsCode) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.TransportationTermsCode = "FXJ";
			subject.IdentificationCodeQualifier = "i";
			subject.Description2 = "e";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("FXJ", "P", true)]
	[InlineData("FXJ", "", false)]
	[InlineData("", "P", false)]
	public void Validation_AllAreRequiredTransportationTermsCode(string transportationTermsCode, string locationQualifier, bool isValidExpected)
	{
		var subject = new FU2_DealValue();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "Y1";
		//Test Parameters
		subject.TransportationTermsCode = transportationTermsCode;
		subject.LocationQualifier = locationQualifier;

        subject.Description2 = "ABC";

		//At Least one
		subject.Quantity = 2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "i";
			subject.IdentificationCode = "O4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("FXJ", "i", "e", true)]
	[InlineData("FXJ", "", "", false)]
	[InlineData("", "i", "e", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_TransportationTermsCode(string transportationTermsCode, string identificationCodeQualifier, string description2, bool isValidExpected)
	{
		var subject = new FU2_DealValue();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "Y1";
		//Test Parameters
		subject.TransportationTermsCode = transportationTermsCode;
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.Description2 = description2;

        if (subject.TransportationTermsCode != "")
            subject.LocationQualifier = "AB";

		//At Least one
		subject.Quantity = 2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "i";
			subject.IdentificationCode = "O4";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("i", "O4", true)]
	[InlineData("i", "", false)]
	[InlineData("", "O4", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new FU2_DealValue();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "Y1";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		//At Least one
		subject.Quantity = 2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TransportationTermsCode) || !string.IsNullOrEmpty(subject.TransportationTermsCode) || !string.IsNullOrEmpty(subject.LocationQualifier))
		{
			subject.TransportationTermsCode = "FXJ";
			subject.LocationQualifier = "P";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.TransportationTermsCode) || !string.IsNullOrEmpty(subject.TransportationTermsCode) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.TransportationTermsCode = "FXJ";
			subject.Description2 = "e";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
