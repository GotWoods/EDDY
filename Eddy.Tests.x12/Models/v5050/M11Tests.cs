using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.Tests.Models.v5050;

public class M11Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M11*D*k*9*M*1*g*7*H*fY*p*L*jt*go*o1*r8*0*v6*hG*i3*z*7*6*S2f*9*e*2B*A90Upr7O*2";

		var expected = new M11_ManifestBillOfLadingDetails()
		{
			BillOfLadingWaybillNumber = "D",
			LocationIdentifier = "k",
			Quantity = 9,
			ManifestUnitCode = "M",
			Weight = 1,
			WeightUnitCode = "g",
			Volume = 7,
			VolumeUnitQualifier = "H",
			BillOfLadingTypeCode = "fY",
			PlaceOfReceiptByPreCarrier = "p",
			BillOfLadingWaybillNumber2 = "L",
			StandardCarrierAlphaCode = "jt",
			StandardCarrierAlphaCode2 = "go",
			StandardCarrierAlphaCode3 = "o1",
			StandardCarrierAlphaCode4 = "r8",
			ShippersExportDeclarationRequirements = "0",
			ExportExceptionCode = "v6",
			StandardCarrierAlphaCode5 = "hG",
			StandardCarrierAlphaCode6 = "i3",
			LocationIdentifier2 = "z",
			LocationIdentifier3 = "7",
			TransportationMethodTypeCode = "6",
			PaymentMethodCode = "S2f",
			IndustryCode = "9",
			LocationQualifier = "e",
			ServiceLevelCode = "2B",
			Date = "A90Upr7O",
			YesNoConditionOrResponseCode = "2",
		};

		var actual = Map.MapObject<M11_ManifestBillOfLadingDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.LocationIdentifier = "k";
		subject.StandardCarrierAlphaCode = "jt";
		subject.LocationQualifier = "e";
		//Test Parameters
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.ManifestUnitCode))
		{
			subject.Quantity = 9;
			subject.ManifestUnitCode = "M";
		}
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 1;
			subject.WeightUnitCode = "g";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 7;
			subject.VolumeUnitQualifier = "H";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "L";
			subject.StandardCarrierAlphaCode2 = "go";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "D";
		subject.StandardCarrierAlphaCode = "jt";
		subject.LocationQualifier = "e";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.ManifestUnitCode))
		{
			subject.Quantity = 9;
			subject.ManifestUnitCode = "M";
		}
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 1;
			subject.WeightUnitCode = "g";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 7;
			subject.VolumeUnitQualifier = "H";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "L";
			subject.StandardCarrierAlphaCode2 = "go";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "M", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "M", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, string manifestUnitCode, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "D";
		subject.LocationIdentifier = "k";
		subject.StandardCarrierAlphaCode = "jt";
		subject.LocationQualifier = "e";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.ManifestUnitCode = manifestUnitCode;
		//If one filled, all required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 1;
			subject.WeightUnitCode = "g";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 7;
			subject.VolumeUnitQualifier = "H";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "L";
			subject.StandardCarrierAlphaCode2 = "go";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "g", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "g", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string weightUnitCode, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "D";
		subject.LocationIdentifier = "k";
		subject.StandardCarrierAlphaCode = "jt";
		subject.LocationQualifier = "e";
		//Test Parameters
		if (weight > 0) 
			subject.Weight = weight;
		subject.WeightUnitCode = weightUnitCode;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.ManifestUnitCode))
		{
			subject.Quantity = 9;
			subject.ManifestUnitCode = "M";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 7;
			subject.VolumeUnitQualifier = "H";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "L";
			subject.StandardCarrierAlphaCode2 = "go";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "H", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "H", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string volumeUnitQualifier, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "D";
		subject.LocationIdentifier = "k";
		subject.StandardCarrierAlphaCode = "jt";
		subject.LocationQualifier = "e";
		//Test Parameters
		if (volume > 0) 
			subject.Volume = volume;
		subject.VolumeUnitQualifier = volumeUnitQualifier;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.ManifestUnitCode))
		{
			subject.Quantity = 9;
			subject.ManifestUnitCode = "M";
		}
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 1;
			subject.WeightUnitCode = "g";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "L";
			subject.StandardCarrierAlphaCode2 = "go";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("L", "go", true)]
	[InlineData("L", "", false)]
	[InlineData("", "go", false)]
	public void Validation_AllAreRequiredBillOfLadingWaybillNumber2(string billOfLadingWaybillNumber2, string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "D";
		subject.LocationIdentifier = "k";
		subject.StandardCarrierAlphaCode = "jt";
		subject.LocationQualifier = "e";
		//Test Parameters
		subject.BillOfLadingWaybillNumber2 = billOfLadingWaybillNumber2;
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.ManifestUnitCode))
		{
			subject.Quantity = 9;
			subject.ManifestUnitCode = "M";
		}
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 1;
			subject.WeightUnitCode = "g";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 7;
			subject.VolumeUnitQualifier = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jt", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "D";
		subject.LocationIdentifier = "k";
		subject.LocationQualifier = "e";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.ManifestUnitCode))
		{
			subject.Quantity = 9;
			subject.ManifestUnitCode = "M";
		}
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 1;
			subject.WeightUnitCode = "g";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 7;
			subject.VolumeUnitQualifier = "H";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "L";
			subject.StandardCarrierAlphaCode2 = "go";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("r8", "o1", true)]
	[InlineData("r8", "", false)]
	[InlineData("", "o1", true)]
	public void Validation_ARequiresBStandardCarrierAlphaCode4(string standardCarrierAlphaCode4, string standardCarrierAlphaCode3, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "D";
		subject.LocationIdentifier = "k";
		subject.StandardCarrierAlphaCode = "jt";
		subject.LocationQualifier = "e";
		//Test Parameters
		subject.StandardCarrierAlphaCode4 = standardCarrierAlphaCode4;
		subject.StandardCarrierAlphaCode3 = standardCarrierAlphaCode3;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.ManifestUnitCode))
		{
			subject.Quantity = 9;
			subject.ManifestUnitCode = "M";
		}
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 1;
			subject.WeightUnitCode = "g";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 7;
			subject.VolumeUnitQualifier = "H";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "L";
			subject.StandardCarrierAlphaCode2 = "go";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("hG", "r8", true)]
	[InlineData("hG", "", false)]
	[InlineData("", "r8", true)]
	public void Validation_ARequiresBStandardCarrierAlphaCode5(string standardCarrierAlphaCode5, string standardCarrierAlphaCode4, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "D";
		subject.LocationIdentifier = "k";
		subject.StandardCarrierAlphaCode = "jt";
		subject.LocationQualifier = "e";
		//Test Parameters
		subject.StandardCarrierAlphaCode5 = standardCarrierAlphaCode5;
		subject.StandardCarrierAlphaCode4 = standardCarrierAlphaCode4;
		//A Requires B
		if (standardCarrierAlphaCode4 != "")
			subject.StandardCarrierAlphaCode3 = "o1";
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.ManifestUnitCode))
		{
			subject.Quantity = 9;
			subject.ManifestUnitCode = "M";
		}
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 1;
			subject.WeightUnitCode = "g";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 7;
			subject.VolumeUnitQualifier = "H";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "L";
			subject.StandardCarrierAlphaCode2 = "go";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("i3", "hG", true)]
	[InlineData("i3", "", false)]
	[InlineData("", "hG", true)]
	public void Validation_ARequiresBStandardCarrierAlphaCode6(string standardCarrierAlphaCode6, string standardCarrierAlphaCode5, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "D";
		subject.LocationIdentifier = "k";
		subject.StandardCarrierAlphaCode = "jt";
		subject.LocationQualifier = "e";
		//Test Parameters
		subject.StandardCarrierAlphaCode6 = standardCarrierAlphaCode6;
		subject.StandardCarrierAlphaCode5 = standardCarrierAlphaCode5;
        //A Requires B
        if (standardCarrierAlphaCode5 != "")
        {
            subject.StandardCarrierAlphaCode4 = "2z";
            subject.StandardCarrierAlphaCode3 = "2z";
            subject.StandardCarrierAlphaCode2 = "2z";
        }
        //If one filled, all required
        if (subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.ManifestUnitCode))
		{
			subject.Quantity = 9;
			subject.ManifestUnitCode = "M";
		}
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 1;
			subject.WeightUnitCode = "g";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 7;
			subject.VolumeUnitQualifier = "H";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "L";
			subject.StandardCarrierAlphaCode2 = "go";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredLocationQualifier(string locationQualifier, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "D";
		subject.LocationIdentifier = "k";
		subject.StandardCarrierAlphaCode = "jt";
		//Test Parameters
		subject.LocationQualifier = locationQualifier;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.ManifestUnitCode))
		{
			subject.Quantity = 9;
			subject.ManifestUnitCode = "M";
		}
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 1;
			subject.WeightUnitCode = "g";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 7;
			subject.VolumeUnitQualifier = "H";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "L";
			subject.StandardCarrierAlphaCode2 = "go";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
