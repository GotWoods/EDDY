using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class G5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G5*X*q*9*OWx2tuNn*5*K*857*8*62*S*6*WW*I*Q*i0*S*6qwjsRs0";

		var expected = new G5_WeightInformation()
		{
			EquipmentInitial = "X",
			EquipmentNumber = "q",
			WaybillNumber = 9,
			Date = "OWx2tuNn",
			Weight = 5,
			WeightQualifier = "K",
			TareWeight = 857,
			TareQualifierCode = "8",
			WeightAllowance = 62,
			WeightAllowanceTypeCode = "S",
			FreightRate = 6,
			RateValueQualifier = "WW",
			InterchangeTrainIdentification = "I",
			CommodityCode = "Q",
			ReferenceIdentificationQualifier = "i0",
			ReferenceIdentification = "S",
			Date2 = "6qwjsRs0",
		};

		var actual = Map.MapObject<G5_WeightInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new G5_WeightInformation();
		subject.EquipmentNumber = "q";
		subject.Weight = 5;
		subject.WeightQualifier = "K";
		subject.EquipmentInitial = equipmentInitial;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 9;
			subject.Date = "OWx2tuNn";
		}
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 857;
			subject.TareQualifierCode = "8";
		}
		//If one is filled, all are required
		if(subject.WeightAllowance > 0 || subject.WeightAllowance > 0 || !string.IsNullOrEmpty(subject.WeightAllowanceTypeCode))
		{
			subject.WeightAllowance = 62;
			subject.WeightAllowanceTypeCode = "S";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 6;
			subject.RateValueQualifier = "WW";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "i0";
			subject.ReferenceIdentification = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new G5_WeightInformation();
		subject.EquipmentInitial = "X";
		subject.Weight = 5;
		subject.WeightQualifier = "K";
		subject.EquipmentNumber = equipmentNumber;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 9;
			subject.Date = "OWx2tuNn";
		}
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 857;
			subject.TareQualifierCode = "8";
		}
		//If one is filled, all are required
		if(subject.WeightAllowance > 0 || subject.WeightAllowance > 0 || !string.IsNullOrEmpty(subject.WeightAllowanceTypeCode))
		{
			subject.WeightAllowance = 62;
			subject.WeightAllowanceTypeCode = "S";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 6;
			subject.RateValueQualifier = "WW";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "i0";
			subject.ReferenceIdentification = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "OWx2tuNn", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "OWx2tuNn", false)]
	public void Validation_AllAreRequiredWaybillNumber(int waybillNumber, string date, bool isValidExpected)
	{
		var subject = new G5_WeightInformation();
		subject.EquipmentInitial = "X";
		subject.EquipmentNumber = "q";
		subject.Weight = 5;
		subject.WeightQualifier = "K";
		if (waybillNumber > 0)
			subject.WaybillNumber = waybillNumber;
		subject.Date = date;
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 857;
			subject.TareQualifierCode = "8";
		}
		//If one is filled, all are required
		if(subject.WeightAllowance > 0 || subject.WeightAllowance > 0 || !string.IsNullOrEmpty(subject.WeightAllowanceTypeCode))
		{
			subject.WeightAllowance = 62;
			subject.WeightAllowanceTypeCode = "S";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 6;
			subject.RateValueQualifier = "WW";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "i0";
			subject.ReferenceIdentification = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredWeight(decimal weight, bool isValidExpected)
	{
		var subject = new G5_WeightInformation();
		subject.EquipmentInitial = "X";
		subject.EquipmentNumber = "q";
		subject.WeightQualifier = "K";
		if (weight > 0)
			subject.Weight = weight;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 9;
			subject.Date = "OWx2tuNn";
		}
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 857;
			subject.TareQualifierCode = "8";
		}
		//If one is filled, all are required
		if(subject.WeightAllowance > 0 || subject.WeightAllowance > 0 || !string.IsNullOrEmpty(subject.WeightAllowanceTypeCode))
		{
			subject.WeightAllowance = 62;
			subject.WeightAllowanceTypeCode = "S";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 6;
			subject.RateValueQualifier = "WW";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "i0";
			subject.ReferenceIdentification = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredWeightQualifier(string weightQualifier, bool isValidExpected)
	{
		var subject = new G5_WeightInformation();
		subject.EquipmentInitial = "X";
		subject.EquipmentNumber = "q";
		subject.Weight = 5;
		subject.WeightQualifier = weightQualifier;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 9;
			subject.Date = "OWx2tuNn";
		}
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 857;
			subject.TareQualifierCode = "8";
		}
		//If one is filled, all are required
		if(subject.WeightAllowance > 0 || subject.WeightAllowance > 0 || !string.IsNullOrEmpty(subject.WeightAllowanceTypeCode))
		{
			subject.WeightAllowance = 62;
			subject.WeightAllowanceTypeCode = "S";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 6;
			subject.RateValueQualifier = "WW";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "i0";
			subject.ReferenceIdentification = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(857, "8", true)]
	[InlineData(857, "", false)]
	[InlineData(0, "8", false)]
	public void Validation_AllAreRequiredTareWeight(int tareWeight, string tareQualifierCode, bool isValidExpected)
	{
		var subject = new G5_WeightInformation();
		subject.EquipmentInitial = "X";
		subject.EquipmentNumber = "q";
		subject.Weight = 5;
		subject.WeightQualifier = "K";
		if (tareWeight > 0)
			subject.TareWeight = tareWeight;
		subject.TareQualifierCode = tareQualifierCode;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 9;
			subject.Date = "OWx2tuNn";
		}
		//If one is filled, all are required
		if(subject.WeightAllowance > 0 || subject.WeightAllowance > 0 || !string.IsNullOrEmpty(subject.WeightAllowanceTypeCode))
		{
			subject.WeightAllowance = 62;
			subject.WeightAllowanceTypeCode = "S";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 6;
			subject.RateValueQualifier = "WW";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "i0";
			subject.ReferenceIdentification = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(62, "S", true)]
	[InlineData(62, "", false)]
	[InlineData(0, "S", false)]
	public void Validation_AllAreRequiredWeightAllowance(int weightAllowance, string weightAllowanceTypeCode, bool isValidExpected)
	{
		var subject = new G5_WeightInformation();
		subject.EquipmentInitial = "X";
		subject.EquipmentNumber = "q";
		subject.Weight = 5;
		subject.WeightQualifier = "K";
		if (weightAllowance > 0)
			subject.WeightAllowance = weightAllowance;
		subject.WeightAllowanceTypeCode = weightAllowanceTypeCode;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 9;
			subject.Date = "OWx2tuNn";
		}
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 857;
			subject.TareQualifierCode = "8";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 6;
			subject.RateValueQualifier = "WW";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "i0";
			subject.ReferenceIdentification = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "WW", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "WW", false)]
	public void Validation_AllAreRequiredFreightRate(decimal freightRate, string rateValueQualifier, bool isValidExpected)
	{
		var subject = new G5_WeightInformation();
		subject.EquipmentInitial = "X";
		subject.EquipmentNumber = "q";
		subject.Weight = 5;
		subject.WeightQualifier = "K";
		if (freightRate > 0)
			subject.FreightRate = freightRate;
		subject.RateValueQualifier = rateValueQualifier;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 9;
			subject.Date = "OWx2tuNn";
		}
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 857;
			subject.TareQualifierCode = "8";
		}
		//If one is filled, all are required
		if(subject.WeightAllowance > 0 || subject.WeightAllowance > 0 || !string.IsNullOrEmpty(subject.WeightAllowanceTypeCode))
		{
			subject.WeightAllowance = 62;
			subject.WeightAllowanceTypeCode = "S";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "i0";
			subject.ReferenceIdentification = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("i0", "S", true)]
	[InlineData("i0", "", false)]
	[InlineData("", "S", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new G5_WeightInformation();
		subject.EquipmentInitial = "X";
		subject.EquipmentNumber = "q";
		subject.Weight = 5;
		subject.WeightQualifier = "K";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 9;
			subject.Date = "OWx2tuNn";
		}
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 857;
			subject.TareQualifierCode = "8";
		}
		//If one is filled, all are required
		if(subject.WeightAllowance > 0 || subject.WeightAllowance > 0 || !string.IsNullOrEmpty(subject.WeightAllowanceTypeCode))
		{
			subject.WeightAllowance = 62;
			subject.WeightAllowanceTypeCode = "S";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 6;
			subject.RateValueQualifier = "WW";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
