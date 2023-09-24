using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.Tests.Models.v5040;

public class G5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G5*k*j*6*C4hBUl6f*7*e*142*P*18*c*9*TJ*5*0*ib*L*271JFPb5";

		var expected = new G5_ScaleInformation()
		{
			EquipmentInitial = "k",
			EquipmentNumber = "j",
			WaybillNumber = 6,
			Date = "C4hBUl6f",
			Weight = 7,
			WeightQualifier = "e",
			TareWeight = 142,
			TareQualifierCode = "P",
			WeightAllowance = 18,
			WeightAllowanceTypeCode = "c",
			FreightRate = 9,
			RateValueQualifier = "TJ",
			InterchangeTrainIdentification = "5",
			CommodityCode = "0",
			ReferenceIdentificationQualifier = "ib",
			ReferenceIdentification = "L",
			Date2 = "271JFPb5",
		};

		var actual = Map.MapObject<G5_ScaleInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new G5_ScaleInformation();
		subject.EquipmentNumber = "j";
		subject.Weight = 7;
		subject.WeightQualifier = "e";
		subject.EquipmentInitial = equipmentInitial;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 6;
			subject.Date = "C4hBUl6f";
		}
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 142;
			subject.TareQualifierCode = "P";
		}
		//If one is filled, all are required
		if(subject.WeightAllowance > 0 || subject.WeightAllowance > 0 || !string.IsNullOrEmpty(subject.WeightAllowanceTypeCode))
		{
			subject.WeightAllowance = 18;
			subject.WeightAllowanceTypeCode = "c";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 9;
			subject.RateValueQualifier = "TJ";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "ib";
			subject.ReferenceIdentification = "L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new G5_ScaleInformation();
		subject.EquipmentInitial = "k";
		subject.Weight = 7;
		subject.WeightQualifier = "e";
		subject.EquipmentNumber = equipmentNumber;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 6;
			subject.Date = "C4hBUl6f";
		}
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 142;
			subject.TareQualifierCode = "P";
		}
		//If one is filled, all are required
		if(subject.WeightAllowance > 0 || subject.WeightAllowance > 0 || !string.IsNullOrEmpty(subject.WeightAllowanceTypeCode))
		{
			subject.WeightAllowance = 18;
			subject.WeightAllowanceTypeCode = "c";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 9;
			subject.RateValueQualifier = "TJ";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "ib";
			subject.ReferenceIdentification = "L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "C4hBUl6f", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "C4hBUl6f", false)]
	public void Validation_AllAreRequiredWaybillNumber(int waybillNumber, string date, bool isValidExpected)
	{
		var subject = new G5_ScaleInformation();
		subject.EquipmentInitial = "k";
		subject.EquipmentNumber = "j";
		subject.Weight = 7;
		subject.WeightQualifier = "e";
		if (waybillNumber > 0)
			subject.WaybillNumber = waybillNumber;
		subject.Date = date;
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 142;
			subject.TareQualifierCode = "P";
		}
		//If one is filled, all are required
		if(subject.WeightAllowance > 0 || subject.WeightAllowance > 0 || !string.IsNullOrEmpty(subject.WeightAllowanceTypeCode))
		{
			subject.WeightAllowance = 18;
			subject.WeightAllowanceTypeCode = "c";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 9;
			subject.RateValueQualifier = "TJ";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "ib";
			subject.ReferenceIdentification = "L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredWeight(decimal weight, bool isValidExpected)
	{
		var subject = new G5_ScaleInformation();
		subject.EquipmentInitial = "k";
		subject.EquipmentNumber = "j";
		subject.WeightQualifier = "e";
		if (weight > 0)
			subject.Weight = weight;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 6;
			subject.Date = "C4hBUl6f";
		}
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 142;
			subject.TareQualifierCode = "P";
		}
		//If one is filled, all are required
		if(subject.WeightAllowance > 0 || subject.WeightAllowance > 0 || !string.IsNullOrEmpty(subject.WeightAllowanceTypeCode))
		{
			subject.WeightAllowance = 18;
			subject.WeightAllowanceTypeCode = "c";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 9;
			subject.RateValueQualifier = "TJ";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "ib";
			subject.ReferenceIdentification = "L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredWeightQualifier(string weightQualifier, bool isValidExpected)
	{
		var subject = new G5_ScaleInformation();
		subject.EquipmentInitial = "k";
		subject.EquipmentNumber = "j";
		subject.Weight = 7;
		subject.WeightQualifier = weightQualifier;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 6;
			subject.Date = "C4hBUl6f";
		}
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 142;
			subject.TareQualifierCode = "P";
		}
		//If one is filled, all are required
		if(subject.WeightAllowance > 0 || subject.WeightAllowance > 0 || !string.IsNullOrEmpty(subject.WeightAllowanceTypeCode))
		{
			subject.WeightAllowance = 18;
			subject.WeightAllowanceTypeCode = "c";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 9;
			subject.RateValueQualifier = "TJ";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "ib";
			subject.ReferenceIdentification = "L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(142, "P", true)]
	[InlineData(142, "", false)]
	[InlineData(0, "P", false)]
	public void Validation_AllAreRequiredTareWeight(int tareWeight, string tareQualifierCode, bool isValidExpected)
	{
		var subject = new G5_ScaleInformation();
		subject.EquipmentInitial = "k";
		subject.EquipmentNumber = "j";
		subject.Weight = 7;
		subject.WeightQualifier = "e";
		if (tareWeight > 0)
			subject.TareWeight = tareWeight;
		subject.TareQualifierCode = tareQualifierCode;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 6;
			subject.Date = "C4hBUl6f";
		}
		//If one is filled, all are required
		if(subject.WeightAllowance > 0 || subject.WeightAllowance > 0 || !string.IsNullOrEmpty(subject.WeightAllowanceTypeCode))
		{
			subject.WeightAllowance = 18;
			subject.WeightAllowanceTypeCode = "c";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 9;
			subject.RateValueQualifier = "TJ";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "ib";
			subject.ReferenceIdentification = "L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(18, "c", true)]
	[InlineData(18, "", false)]
	[InlineData(0, "c", false)]
	public void Validation_AllAreRequiredWeightAllowance(int weightAllowance, string weightAllowanceTypeCode, bool isValidExpected)
	{
		var subject = new G5_ScaleInformation();
		subject.EquipmentInitial = "k";
		subject.EquipmentNumber = "j";
		subject.Weight = 7;
		subject.WeightQualifier = "e";
		if (weightAllowance > 0)
			subject.WeightAllowance = weightAllowance;
		subject.WeightAllowanceTypeCode = weightAllowanceTypeCode;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 6;
			subject.Date = "C4hBUl6f";
		}
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 142;
			subject.TareQualifierCode = "P";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 9;
			subject.RateValueQualifier = "TJ";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "ib";
			subject.ReferenceIdentification = "L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "TJ", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "TJ", false)]
	public void Validation_AllAreRequiredFreightRate(decimal freightRate, string rateValueQualifier, bool isValidExpected)
	{
		var subject = new G5_ScaleInformation();
		subject.EquipmentInitial = "k";
		subject.EquipmentNumber = "j";
		subject.Weight = 7;
		subject.WeightQualifier = "e";
		if (freightRate > 0)
			subject.FreightRate = freightRate;
		subject.RateValueQualifier = rateValueQualifier;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 6;
			subject.Date = "C4hBUl6f";
		}
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 142;
			subject.TareQualifierCode = "P";
		}
		//If one is filled, all are required
		if(subject.WeightAllowance > 0 || subject.WeightAllowance > 0 || !string.IsNullOrEmpty(subject.WeightAllowanceTypeCode))
		{
			subject.WeightAllowance = 18;
			subject.WeightAllowanceTypeCode = "c";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "ib";
			subject.ReferenceIdentification = "L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ib", "L", true)]
	[InlineData("ib", "", false)]
	[InlineData("", "L", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new G5_ScaleInformation();
		subject.EquipmentInitial = "k";
		subject.EquipmentNumber = "j";
		subject.Weight = 7;
		subject.WeightQualifier = "e";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 6;
			subject.Date = "C4hBUl6f";
		}
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 142;
			subject.TareQualifierCode = "P";
		}
		//If one is filled, all are required
		if(subject.WeightAllowance > 0 || subject.WeightAllowance > 0 || !string.IsNullOrEmpty(subject.WeightAllowanceTypeCode))
		{
			subject.WeightAllowance = 18;
			subject.WeightAllowanceTypeCode = "c";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 9;
			subject.RateValueQualifier = "TJ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
