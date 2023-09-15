using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class G5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G5*c*4*5*6wtiqarx*5*w*623*M*88*a*8*8q*8*H*BV*o*Vnn7kckq";

		var expected = new G5_WeightInformation()
		{
			EquipmentInitial = "c",
			EquipmentNumber = "4",
			WaybillNumber = 5,
			Date = "6wtiqarx",
			Weight = 5,
			WeightQualifier = "w",
			TareWeight = 623,
			TareQualifierCode = "M",
			WeightAllowance = 88,
			WeightAllowanceTypeCode = "a",
			FreightRate = 8,
			RateValueQualifier = "8q",
			InterchangeTrainIdentification = "8",
			CommodityCode = "H",
			ReferenceIdentificationQualifier = "BV",
			ReferenceIdentification = "o",
			Date2 = "Vnn7kckq",
		};

		var actual = Map.MapObject<G5_WeightInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new G5_WeightInformation();
		subject.EquipmentNumber = "4";
		subject.Weight = 5;
		subject.WeightQualifier = "w";
		subject.EquipmentInitial = equipmentInitial;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 5;
			subject.Date = "6wtiqarx";
		}
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 623;
			subject.TareQualifierCode = "M";
		}
		//If one is filled, all are required
		if(subject.WeightAllowance > 0 || subject.WeightAllowance > 0 || !string.IsNullOrEmpty(subject.WeightAllowanceTypeCode))
		{
			subject.WeightAllowance = 88;
			subject.WeightAllowanceTypeCode = "a";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 8;
			subject.RateValueQualifier = "8q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "BV";
			subject.ReferenceIdentification = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new G5_WeightInformation();
		subject.EquipmentInitial = "c";
		subject.Weight = 5;
		subject.WeightQualifier = "w";
		subject.EquipmentNumber = equipmentNumber;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 5;
			subject.Date = "6wtiqarx";
		}
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 623;
			subject.TareQualifierCode = "M";
		}
		//If one is filled, all are required
		if(subject.WeightAllowance > 0 || subject.WeightAllowance > 0 || !string.IsNullOrEmpty(subject.WeightAllowanceTypeCode))
		{
			subject.WeightAllowance = 88;
			subject.WeightAllowanceTypeCode = "a";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 8;
			subject.RateValueQualifier = "8q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "BV";
			subject.ReferenceIdentification = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "6wtiqarx", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "6wtiqarx", false)]
	public void Validation_AllAreRequiredWaybillNumber(int waybillNumber, string date, bool isValidExpected)
	{
		var subject = new G5_WeightInformation();
		subject.EquipmentInitial = "c";
		subject.EquipmentNumber = "4";
		subject.Weight = 5;
		subject.WeightQualifier = "w";
		if (waybillNumber > 0)
			subject.WaybillNumber = waybillNumber;
		subject.Date = date;
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 623;
			subject.TareQualifierCode = "M";
		}
		//If one is filled, all are required
		if(subject.WeightAllowance > 0 || subject.WeightAllowance > 0 || !string.IsNullOrEmpty(subject.WeightAllowanceTypeCode))
		{
			subject.WeightAllowance = 88;
			subject.WeightAllowanceTypeCode = "a";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 8;
			subject.RateValueQualifier = "8q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "BV";
			subject.ReferenceIdentification = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredWeight(decimal weight, bool isValidExpected)
	{
		var subject = new G5_WeightInformation();
		subject.EquipmentInitial = "c";
		subject.EquipmentNumber = "4";
		subject.WeightQualifier = "w";
		if (weight > 0)
			subject.Weight = weight;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 5;
			subject.Date = "6wtiqarx";
		}
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 623;
			subject.TareQualifierCode = "M";
		}
		//If one is filled, all are required
		if(subject.WeightAllowance > 0 || subject.WeightAllowance > 0 || !string.IsNullOrEmpty(subject.WeightAllowanceTypeCode))
		{
			subject.WeightAllowance = 88;
			subject.WeightAllowanceTypeCode = "a";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 8;
			subject.RateValueQualifier = "8q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "BV";
			subject.ReferenceIdentification = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredWeightQualifier(string weightQualifier, bool isValidExpected)
	{
		var subject = new G5_WeightInformation();
		subject.EquipmentInitial = "c";
		subject.EquipmentNumber = "4";
		subject.Weight = 5;
		subject.WeightQualifier = weightQualifier;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 5;
			subject.Date = "6wtiqarx";
		}
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 623;
			subject.TareQualifierCode = "M";
		}
		//If one is filled, all are required
		if(subject.WeightAllowance > 0 || subject.WeightAllowance > 0 || !string.IsNullOrEmpty(subject.WeightAllowanceTypeCode))
		{
			subject.WeightAllowance = 88;
			subject.WeightAllowanceTypeCode = "a";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 8;
			subject.RateValueQualifier = "8q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "BV";
			subject.ReferenceIdentification = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(623, "M", true)]
	[InlineData(623, "", false)]
	[InlineData(0, "M", false)]
	public void Validation_AllAreRequiredTareWeight(int tareWeight, string tareQualifierCode, bool isValidExpected)
	{
		var subject = new G5_WeightInformation();
		subject.EquipmentInitial = "c";
		subject.EquipmentNumber = "4";
		subject.Weight = 5;
		subject.WeightQualifier = "w";
		if (tareWeight > 0)
			subject.TareWeight = tareWeight;
		subject.TareQualifierCode = tareQualifierCode;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 5;
			subject.Date = "6wtiqarx";
		}
		//If one is filled, all are required
		if(subject.WeightAllowance > 0 || subject.WeightAllowance > 0 || !string.IsNullOrEmpty(subject.WeightAllowanceTypeCode))
		{
			subject.WeightAllowance = 88;
			subject.WeightAllowanceTypeCode = "a";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 8;
			subject.RateValueQualifier = "8q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "BV";
			subject.ReferenceIdentification = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(88, "a", true)]
	[InlineData(88, "", false)]
	[InlineData(0, "a", false)]
	public void Validation_AllAreRequiredWeightAllowance(int weightAllowance, string weightAllowanceTypeCode, bool isValidExpected)
	{
		var subject = new G5_WeightInformation();
		subject.EquipmentInitial = "c";
		subject.EquipmentNumber = "4";
		subject.Weight = 5;
		subject.WeightQualifier = "w";
		if (weightAllowance > 0)
			subject.WeightAllowance = weightAllowance;
		subject.WeightAllowanceTypeCode = weightAllowanceTypeCode;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 5;
			subject.Date = "6wtiqarx";
		}
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 623;
			subject.TareQualifierCode = "M";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 8;
			subject.RateValueQualifier = "8q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "BV";
			subject.ReferenceIdentification = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "8q", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "8q", false)]
	public void Validation_AllAreRequiredFreightRate(decimal freightRate, string rateValueQualifier, bool isValidExpected)
	{
		var subject = new G5_WeightInformation();
		subject.EquipmentInitial = "c";
		subject.EquipmentNumber = "4";
		subject.Weight = 5;
		subject.WeightQualifier = "w";
		if (freightRate > 0)
			subject.FreightRate = freightRate;
		subject.RateValueQualifier = rateValueQualifier;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 5;
			subject.Date = "6wtiqarx";
		}
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 623;
			subject.TareQualifierCode = "M";
		}
		//If one is filled, all are required
		if(subject.WeightAllowance > 0 || subject.WeightAllowance > 0 || !string.IsNullOrEmpty(subject.WeightAllowanceTypeCode))
		{
			subject.WeightAllowance = 88;
			subject.WeightAllowanceTypeCode = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "BV";
			subject.ReferenceIdentification = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("BV", "o", true)]
	[InlineData("BV", "", false)]
	[InlineData("", "o", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new G5_WeightInformation();
		subject.EquipmentInitial = "c";
		subject.EquipmentNumber = "4";
		subject.Weight = 5;
		subject.WeightQualifier = "w";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 5;
			subject.Date = "6wtiqarx";
		}
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 623;
			subject.TareQualifierCode = "M";
		}
		//If one is filled, all are required
		if(subject.WeightAllowance > 0 || subject.WeightAllowance > 0 || !string.IsNullOrEmpty(subject.WeightAllowanceTypeCode))
		{
			subject.WeightAllowance = 88;
			subject.WeightAllowanceTypeCode = "a";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 8;
			subject.RateValueQualifier = "8q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
