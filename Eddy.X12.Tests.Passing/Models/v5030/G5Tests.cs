using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class G5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G5*B*3*5*iykoTxnZ*9*s*124*W*93*2*8*yq*u*y*7V*D*zd4ZrnkH";

		var expected = new G5_ScaleInformation()
		{
			EquipmentInitial = "B",
			EquipmentNumber = "3",
			WaybillNumber = 5,
			Date = "iykoTxnZ",
			Weight = 9,
			WeightQualifier = "s",
			TareWeight = 124,
			TareQualifierCode = "W",
			WeightAllowance = 93,
			WeightAllowanceTypeCode = "2",
			FreightRate = 8,
			RateValueQualifier = "yq",
			InterchangeTrainIdentification = "u",
			CommodityCode = "y",
			ReferenceIdentificationQualifier = "7V",
			ReferenceIdentification = "D",
			Date2 = "zd4ZrnkH",
		};

		var actual = Map.MapObject<G5_ScaleInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new G5_ScaleInformation();
		subject.EquipmentNumber = "3";
		subject.Weight = 9;
		subject.WeightQualifier = "s";
		subject.EquipmentInitial = equipmentInitial;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 5;
			subject.Date = "iykoTxnZ";
		}
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 124;
			subject.TareQualifierCode = "W";
		}
		//If one is filled, all are required
		if(subject.WeightAllowance > 0 || subject.WeightAllowance > 0 || !string.IsNullOrEmpty(subject.WeightAllowanceTypeCode))
		{
			subject.WeightAllowance = 93;
			subject.WeightAllowanceTypeCode = "2";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 8;
			subject.RateValueQualifier = "yq";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "7V";
			subject.ReferenceIdentification = "D";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new G5_ScaleInformation();
		subject.EquipmentInitial = "B";
		subject.Weight = 9;
		subject.WeightQualifier = "s";
		subject.EquipmentNumber = equipmentNumber;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 5;
			subject.Date = "iykoTxnZ";
		}
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 124;
			subject.TareQualifierCode = "W";
		}
		//If one is filled, all are required
		if(subject.WeightAllowance > 0 || subject.WeightAllowance > 0 || !string.IsNullOrEmpty(subject.WeightAllowanceTypeCode))
		{
			subject.WeightAllowance = 93;
			subject.WeightAllowanceTypeCode = "2";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 8;
			subject.RateValueQualifier = "yq";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "7V";
			subject.ReferenceIdentification = "D";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "iykoTxnZ", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "iykoTxnZ", false)]
	public void Validation_AllAreRequiredWaybillNumber(int waybillNumber, string date, bool isValidExpected)
	{
		var subject = new G5_ScaleInformation();
		subject.EquipmentInitial = "B";
		subject.EquipmentNumber = "3";
		subject.Weight = 9;
		subject.WeightQualifier = "s";
		if (waybillNumber > 0)
			subject.WaybillNumber = waybillNumber;
		subject.Date = date;
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 124;
			subject.TareQualifierCode = "W";
		}
		//If one is filled, all are required
		if(subject.WeightAllowance > 0 || subject.WeightAllowance > 0 || !string.IsNullOrEmpty(subject.WeightAllowanceTypeCode))
		{
			subject.WeightAllowance = 93;
			subject.WeightAllowanceTypeCode = "2";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 8;
			subject.RateValueQualifier = "yq";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "7V";
			subject.ReferenceIdentification = "D";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredWeight(decimal weight, bool isValidExpected)
	{
		var subject = new G5_ScaleInformation();
		subject.EquipmentInitial = "B";
		subject.EquipmentNumber = "3";
		subject.WeightQualifier = "s";
		if (weight > 0)
			subject.Weight = weight;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 5;
			subject.Date = "iykoTxnZ";
		}
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 124;
			subject.TareQualifierCode = "W";
		}
		//If one is filled, all are required
		if(subject.WeightAllowance > 0 || subject.WeightAllowance > 0 || !string.IsNullOrEmpty(subject.WeightAllowanceTypeCode))
		{
			subject.WeightAllowance = 93;
			subject.WeightAllowanceTypeCode = "2";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 8;
			subject.RateValueQualifier = "yq";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "7V";
			subject.ReferenceIdentification = "D";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredWeightQualifier(string weightQualifier, bool isValidExpected)
	{
		var subject = new G5_ScaleInformation();
		subject.EquipmentInitial = "B";
		subject.EquipmentNumber = "3";
		subject.Weight = 9;
		subject.WeightQualifier = weightQualifier;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 5;
			subject.Date = "iykoTxnZ";
		}
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 124;
			subject.TareQualifierCode = "W";
		}
		//If one is filled, all are required
		if(subject.WeightAllowance > 0 || subject.WeightAllowance > 0 || !string.IsNullOrEmpty(subject.WeightAllowanceTypeCode))
		{
			subject.WeightAllowance = 93;
			subject.WeightAllowanceTypeCode = "2";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 8;
			subject.RateValueQualifier = "yq";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "7V";
			subject.ReferenceIdentification = "D";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(124, "W", true)]
	[InlineData(124, "", false)]
	[InlineData(0, "W", false)]
	public void Validation_AllAreRequiredTareWeight(int tareWeight, string tareQualifierCode, bool isValidExpected)
	{
		var subject = new G5_ScaleInformation();
		subject.EquipmentInitial = "B";
		subject.EquipmentNumber = "3";
		subject.Weight = 9;
		subject.WeightQualifier = "s";
		if (tareWeight > 0)
			subject.TareWeight = tareWeight;
		subject.TareQualifierCode = tareQualifierCode;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 5;
			subject.Date = "iykoTxnZ";
		}
		//If one is filled, all are required
		if(subject.WeightAllowance > 0 || subject.WeightAllowance > 0 || !string.IsNullOrEmpty(subject.WeightAllowanceTypeCode))
		{
			subject.WeightAllowance = 93;
			subject.WeightAllowanceTypeCode = "2";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 8;
			subject.RateValueQualifier = "yq";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "7V";
			subject.ReferenceIdentification = "D";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(93, "2", true)]
	[InlineData(93, "", false)]
	[InlineData(0, "2", false)]
	public void Validation_AllAreRequiredWeightAllowance(int weightAllowance, string weightAllowanceTypeCode, bool isValidExpected)
	{
		var subject = new G5_ScaleInformation();
		subject.EquipmentInitial = "B";
		subject.EquipmentNumber = "3";
		subject.Weight = 9;
		subject.WeightQualifier = "s";
		if (weightAllowance > 0)
			subject.WeightAllowance = weightAllowance;
		subject.WeightAllowanceTypeCode = weightAllowanceTypeCode;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 5;
			subject.Date = "iykoTxnZ";
		}
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 124;
			subject.TareQualifierCode = "W";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 8;
			subject.RateValueQualifier = "yq";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "7V";
			subject.ReferenceIdentification = "D";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "yq", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "yq", false)]
	public void Validation_AllAreRequiredFreightRate(decimal freightRate, string rateValueQualifier, bool isValidExpected)
	{
		var subject = new G5_ScaleInformation();
		subject.EquipmentInitial = "B";
		subject.EquipmentNumber = "3";
		subject.Weight = 9;
		subject.WeightQualifier = "s";
		if (freightRate > 0)
			subject.FreightRate = freightRate;
		subject.RateValueQualifier = rateValueQualifier;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 5;
			subject.Date = "iykoTxnZ";
		}
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 124;
			subject.TareQualifierCode = "W";
		}
		//If one is filled, all are required
		if(subject.WeightAllowance > 0 || subject.WeightAllowance > 0 || !string.IsNullOrEmpty(subject.WeightAllowanceTypeCode))
		{
			subject.WeightAllowance = 93;
			subject.WeightAllowanceTypeCode = "2";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "7V";
			subject.ReferenceIdentification = "D";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("7V", "D", true)]
	[InlineData("7V", "", false)]
	[InlineData("", "D", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new G5_ScaleInformation();
		subject.EquipmentInitial = "B";
		subject.EquipmentNumber = "3";
		subject.Weight = 9;
		subject.WeightQualifier = "s";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one is filled, all are required
		if(subject.WaybillNumber > 0 || subject.WaybillNumber > 0 || !string.IsNullOrEmpty(subject.Date))
		{
			subject.WaybillNumber = 5;
			subject.Date = "iykoTxnZ";
		}
		//If one is filled, all are required
		if(subject.TareWeight > 0 || subject.TareWeight > 0 || !string.IsNullOrEmpty(subject.TareQualifierCode))
		{
			subject.TareWeight = 124;
			subject.TareQualifierCode = "W";
		}
		//If one is filled, all are required
		if(subject.WeightAllowance > 0 || subject.WeightAllowance > 0 || !string.IsNullOrEmpty(subject.WeightAllowanceTypeCode))
		{
			subject.WeightAllowance = 93;
			subject.WeightAllowanceTypeCode = "2";
		}
		//If one is filled, all are required
		if(subject.FreightRate > 0 || subject.FreightRate > 0 || !string.IsNullOrEmpty(subject.RateValueQualifier))
		{
			subject.FreightRate = 8;
			subject.RateValueQualifier = "yq";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
