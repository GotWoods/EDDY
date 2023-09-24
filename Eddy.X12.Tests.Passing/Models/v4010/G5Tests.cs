using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class G5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G5*R*n*9*s0EG4gCW*9*e*678*u*29*U*9*a0*e*S*h4*n*TvHIdfab";

		var expected = new G5_WeightInformation()
		{
			EquipmentInitial = "R",
			EquipmentNumber = "n",
			WaybillNumber = 9,
			Date = "s0EG4gCW",
			Weight = 9,
			WeightQualifier = "e",
			TareWeight = 678,
			TareQualifierCode = "u",
			WeightAllowance = 29,
			WeightAllowanceTypeCode = "U",
			FreightRate = 9,
			RateValueQualifier = "a0",
			InterchangeTrainIdentification = "e",
			CommodityCode = "S",
			ReferenceIdentificationQualifier = "h4",
			ReferenceIdentification = "n",
			Date2 = "TvHIdfab",
		};

		var actual = Map.MapObject<G5_WeightInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new G5_WeightInformation();
		subject.EquipmentNumber = "n";
		subject.Weight = 9;
		subject.WeightQualifier = "e";
		subject.EquipmentInitial = equipmentInitial;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 9;
			subject.Date = "s0EG4gCW";
		}
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 678;
			subject.TareQualifierCode = "u";
		}
		//If one is filled, all are required
		if(subject.WeightAllowance > 0 || subject.WeightAllowance > 0 || !string.IsNullOrEmpty(subject.WeightAllowanceTypeCode))
		{
			subject.WeightAllowance = 29;
			subject.WeightAllowanceTypeCode = "U";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 9;
			subject.RateValueQualifier = "a0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "h4";
			subject.ReferenceIdentification = "n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new G5_WeightInformation();
		subject.EquipmentInitial = "R";
		subject.Weight = 9;
		subject.WeightQualifier = "e";
		subject.EquipmentNumber = equipmentNumber;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 9;
			subject.Date = "s0EG4gCW";
		}
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 678;
			subject.TareQualifierCode = "u";
		}
		//If one is filled, all are required
		if(subject.WeightAllowance > 0 || subject.WeightAllowance > 0 || !string.IsNullOrEmpty(subject.WeightAllowanceTypeCode))
		{
			subject.WeightAllowance = 29;
			subject.WeightAllowanceTypeCode = "U";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 9;
			subject.RateValueQualifier = "a0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "h4";
			subject.ReferenceIdentification = "n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "s0EG4gCW", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "s0EG4gCW", false)]
	public void Validation_AllAreRequiredWaybillNumber(int waybillNumber, string date, bool isValidExpected)
	{
		var subject = new G5_WeightInformation();
		subject.EquipmentInitial = "R";
		subject.EquipmentNumber = "n";
		subject.Weight = 9;
		subject.WeightQualifier = "e";
		if (waybillNumber > 0)
			subject.WaybillNumber = waybillNumber;
		subject.Date = date;
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 678;
			subject.TareQualifierCode = "u";
		}
		//If one is filled, all are required
		if(subject.WeightAllowance > 0 || subject.WeightAllowance > 0 || !string.IsNullOrEmpty(subject.WeightAllowanceTypeCode))
		{
			subject.WeightAllowance = 29;
			subject.WeightAllowanceTypeCode = "U";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 9;
			subject.RateValueQualifier = "a0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "h4";
			subject.ReferenceIdentification = "n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredWeight(decimal weight, bool isValidExpected)
	{
		var subject = new G5_WeightInformation();
		subject.EquipmentInitial = "R";
		subject.EquipmentNumber = "n";
		subject.WeightQualifier = "e";
		if (weight > 0)
			subject.Weight = weight;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 9;
			subject.Date = "s0EG4gCW";
		}
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 678;
			subject.TareQualifierCode = "u";
		}
		//If one is filled, all are required
		if(subject.WeightAllowance > 0 || subject.WeightAllowance > 0 || !string.IsNullOrEmpty(subject.WeightAllowanceTypeCode))
		{
			subject.WeightAllowance = 29;
			subject.WeightAllowanceTypeCode = "U";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 9;
			subject.RateValueQualifier = "a0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "h4";
			subject.ReferenceIdentification = "n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredWeightQualifier(string weightQualifier, bool isValidExpected)
	{
		var subject = new G5_WeightInformation();
		subject.EquipmentInitial = "R";
		subject.EquipmentNumber = "n";
		subject.Weight = 9;
		subject.WeightQualifier = weightQualifier;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 9;
			subject.Date = "s0EG4gCW";
		}
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 678;
			subject.TareQualifierCode = "u";
		}
		//If one is filled, all are required
		if(subject.WeightAllowance > 0 || subject.WeightAllowance > 0 || !string.IsNullOrEmpty(subject.WeightAllowanceTypeCode))
		{
			subject.WeightAllowance = 29;
			subject.WeightAllowanceTypeCode = "U";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 9;
			subject.RateValueQualifier = "a0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "h4";
			subject.ReferenceIdentification = "n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(678, "u", true)]
	[InlineData(678, "", false)]
	[InlineData(0, "u", false)]
	public void Validation_AllAreRequiredTareWeight(int tareWeight, string tareQualifierCode, bool isValidExpected)
	{
		var subject = new G5_WeightInformation();
		subject.EquipmentInitial = "R";
		subject.EquipmentNumber = "n";
		subject.Weight = 9;
		subject.WeightQualifier = "e";
		if (tareWeight > 0)
			subject.TareWeight = tareWeight;
		subject.TareQualifierCode = tareQualifierCode;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 9;
			subject.Date = "s0EG4gCW";
		}
		//If one is filled, all are required
		if(subject.WeightAllowance > 0 || subject.WeightAllowance > 0 || !string.IsNullOrEmpty(subject.WeightAllowanceTypeCode))
		{
			subject.WeightAllowance = 29;
			subject.WeightAllowanceTypeCode = "U";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 9;
			subject.RateValueQualifier = "a0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "h4";
			subject.ReferenceIdentification = "n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(29, "U", true)]
	[InlineData(29, "", false)]
	[InlineData(0, "U", false)]
	public void Validation_AllAreRequiredWeightAllowance(int weightAllowance, string weightAllowanceTypeCode, bool isValidExpected)
	{
		var subject = new G5_WeightInformation();
		subject.EquipmentInitial = "R";
		subject.EquipmentNumber = "n";
		subject.Weight = 9;
		subject.WeightQualifier = "e";
		if (weightAllowance > 0)
			subject.WeightAllowance = weightAllowance;
		subject.WeightAllowanceTypeCode = weightAllowanceTypeCode;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 9;
			subject.Date = "s0EG4gCW";
		}
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 678;
			subject.TareQualifierCode = "u";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 9;
			subject.RateValueQualifier = "a0";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "h4";
			subject.ReferenceIdentification = "n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "a0", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "a0", false)]
	public void Validation_AllAreRequiredFreightRate(decimal freightRate, string rateValueQualifier, bool isValidExpected)
	{
		var subject = new G5_WeightInformation();
		subject.EquipmentInitial = "R";
		subject.EquipmentNumber = "n";
		subject.Weight = 9;
		subject.WeightQualifier = "e";
		if (freightRate > 0)
			subject.FreightRate = freightRate;
		subject.RateValueQualifier = rateValueQualifier;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 9;
			subject.Date = "s0EG4gCW";
		}
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 678;
			subject.TareQualifierCode = "u";
		}
		//If one is filled, all are required
		if(subject.WeightAllowance > 0 || subject.WeightAllowance > 0 || !string.IsNullOrEmpty(subject.WeightAllowanceTypeCode))
		{
			subject.WeightAllowance = 29;
			subject.WeightAllowanceTypeCode = "U";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "h4";
			subject.ReferenceIdentification = "n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("h4", "n", true)]
	[InlineData("h4", "", false)]
	[InlineData("", "n", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new G5_WeightInformation();
		subject.EquipmentInitial = "R";
		subject.EquipmentNumber = "n";
		subject.Weight = 9;
		subject.WeightQualifier = "e";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 9;
			subject.Date = "s0EG4gCW";
		}
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 678;
			subject.TareQualifierCode = "u";
		}
		//If one is filled, all are required
		if(subject.WeightAllowance > 0 || subject.WeightAllowance > 0 || !string.IsNullOrEmpty(subject.WeightAllowanceTypeCode))
		{
			subject.WeightAllowance = 29;
			subject.WeightAllowanceTypeCode = "U";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 9;
			subject.RateValueQualifier = "a0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
