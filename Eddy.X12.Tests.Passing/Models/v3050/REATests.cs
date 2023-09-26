using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class REATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "REA*mr*2*Ub4hKM*G*rs2EWL*K*kh*z*qs*5*x*h";

		var expected = new REA_RealEstatePropertyInformation()
		{
			TypeOfRealEstateAssetCode = "mr",
			Quantity = 2,
			Date = "Ub4hKM",
			PropertyOwnershipRightsCode = "G",
			Date2 = "rs2EWL",
			StatusOfPlansForRealEstateAssetCode = "K",
			DateTimePeriodFormatQualifier = "kh",
			DateTimePeriod = "z",
			UnitOrBasisForMeasurementCode = "qs",
			Quantity2 = 5,
			LocationQualifier = "x",
			ReferenceNumber = "h",
		};

		var actual = Map.MapObject<REA_RealEstatePropertyInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mr", true)]
	public void Validation_RequiredTypeOfRealEstateAssetCode(string typeOfRealEstateAssetCode, bool isValidExpected)
	{
		var subject = new REA_RealEstatePropertyInformation();
		//Required fields
		//Test Parameters
		subject.TypeOfRealEstateAssetCode = typeOfRealEstateAssetCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "kh";
			subject.DateTimePeriod = "z";
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "qs";
			subject.Quantity2 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("kh", "z", true)]
	[InlineData("kh", "", false)]
	[InlineData("", "z", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new REA_RealEstatePropertyInformation();
		//Required fields
		subject.TypeOfRealEstateAssetCode = "mr";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "qs";
			subject.Quantity2 = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("qs", 5, true)]
	[InlineData("qs", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity2, bool isValidExpected)
	{
		var subject = new REA_RealEstatePropertyInformation();
		//Required fields
		subject.TypeOfRealEstateAssetCode = "mr";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "kh";
			subject.DateTimePeriod = "z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
