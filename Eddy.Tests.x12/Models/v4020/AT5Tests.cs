using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class AT5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AT5*dU*Ri*7c*Jj*1*3";

		var expected = new AT5_BillOfLadingHandlingRequirements()
		{
			SpecialHandlingCode = "dU",
			SpecialServicesCode = "Ri",
			SpecialHandlingDescription = "7c",
			UnitOrBasisForMeasurementCode = "Jj",
			Temperature = 1,
			Temperature2 = 3,
		};

		var actual = Map.MapObject<AT5_BillOfLadingHandlingRequirements>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("dU", "7c", false)]
	[InlineData("dU", "", true)]
	[InlineData("", "7c", true)]
	public void Validation_OnlyOneOfSpecialHandlingCode(string specialHandlingCode, string specialHandlingDescription, bool isValidExpected)
	{
		var subject = new AT5_BillOfLadingHandlingRequirements();
		//Required fields
		//Test Parameters
		subject.SpecialHandlingCode = specialHandlingCode;
		subject.SpecialHandlingDescription = specialHandlingDescription;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Temperature > 0 || subject.Temperature2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "Jj";
			subject.Temperature = 1;
			subject.Temperature2 = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ri", "7c", false)]
	[InlineData("Ri", "", true)]
	[InlineData("", "7c", true)]
	public void Validation_OnlyOneOfSpecialServicesCode(string specialServicesCode, string specialHandlingDescription, bool isValidExpected)
	{
		var subject = new AT5_BillOfLadingHandlingRequirements();
		//Required fields
		//Test Parameters
		subject.SpecialServicesCode = specialServicesCode;
		subject.SpecialHandlingDescription = specialHandlingDescription;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Temperature > 0 || subject.Temperature2 > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "Jj";
			subject.Temperature = 1;
			subject.Temperature2 = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", 0, 0, true)]
	[InlineData("Jj", 1, 3, true)]
	[InlineData("Jj", 0, 0, false)]
	[InlineData("", 1, 3, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_UnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal temperature, decimal temperature2, bool isValidExpected)
	{
		var subject = new AT5_BillOfLadingHandlingRequirements();
		//Required fields
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (temperature > 0) 
			subject.Temperature = temperature;
		if (temperature2 > 0) 
			subject.Temperature2 = temperature2;
		//A Requires B
		if (temperature > 0)
			subject.UnitOrBasisForMeasurementCode = "Jj";
		if (temperature2 > 0)
			subject.UnitOrBasisForMeasurementCode = "Jj";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "Jj", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "Jj", true)]
	public void Validation_ARequiresBTemperature(decimal temperature, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new AT5_BillOfLadingHandlingRequirements();
		//Required fields
		//Test Parameters
		if (temperature > 0) 
			subject.Temperature = temperature;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Temperature2 > 0)
		{
			subject.Temperature2 = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "Jj", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "Jj", true)]
	public void Validation_ARequiresBTemperature2(decimal temperature2, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new AT5_BillOfLadingHandlingRequirements();
		//Required fields
		//Test Parameters
		if (temperature2 > 0) 
			subject.Temperature2 = temperature2;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Temperature > 0)
		{
			subject.Temperature = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
