using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5010;

namespace Eddy.x12.Tests.Models.v5010;

public class M11Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M11*m*9*8*n*7*g*6*w*XH*t*v*N0*vX*ka*UR*C*Qv*Sr*cn*y*N*0*Xny*2";

		var expected = new M11_ManifestBillOfLadingDetails()
		{
			BillOfLadingWaybillNumber = "m",
			LocationIdentifier = "9",
			Quantity = 8,
			ManifestUnitCode = "n",
			Weight = 7,
			WeightUnitCode = "g",
			Volume = 6,
			VolumeUnitQualifier = "w",
			BillOfLadingTypeCode = "XH",
			PlaceOfReceiptByPreCarrier = "t",
			BillOfLadingWaybillNumber2 = "v",
			StandardCarrierAlphaCode = "N0",
			StandardCarrierAlphaCode2 = "vX",
			StandardCarrierAlphaCode3 = "ka",
			StandardCarrierAlphaCode4 = "UR",
			ShippersExportDeclarationRequirements = "C",
			ExportExceptionCode = "Qv",
			StandardCarrierAlphaCode5 = "Sr",
			StandardCarrierAlphaCode6 = "cn",
			LocationIdentifier2 = "y",
			LocationIdentifier3 = "N",
			TransportationMethodTypeCode = "0",
			PaymentMethodCode = "Xny",
			IndustryCode = "2",
		};

		var actual = Map.MapObject<M11_ManifestBillOfLadingDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.LocationIdentifier = "9";
		subject.StandardCarrierAlphaCode = "N0";
		//Test Parameters
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.ManifestUnitCode))
		{
			subject.Quantity = 8;
			subject.ManifestUnitCode = "n";
		}
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 7;
			subject.WeightUnitCode = "g";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 6;
			subject.VolumeUnitQualifier = "w";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "v";
			subject.StandardCarrierAlphaCode2 = "vX";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "m";
		subject.StandardCarrierAlphaCode = "N0";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.ManifestUnitCode))
		{
			subject.Quantity = 8;
			subject.ManifestUnitCode = "n";
		}
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 7;
			subject.WeightUnitCode = "g";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 6;
			subject.VolumeUnitQualifier = "w";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "v";
			subject.StandardCarrierAlphaCode2 = "vX";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "n", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "n", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, string manifestUnitCode, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "m";
		subject.LocationIdentifier = "9";
		subject.StandardCarrierAlphaCode = "N0";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.ManifestUnitCode = manifestUnitCode;
		//If one filled, all required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 7;
			subject.WeightUnitCode = "g";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 6;
			subject.VolumeUnitQualifier = "w";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "v";
			subject.StandardCarrierAlphaCode2 = "vX";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "g", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "g", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string weightUnitCode, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "m";
		subject.LocationIdentifier = "9";
		subject.StandardCarrierAlphaCode = "N0";
		//Test Parameters
		if (weight > 0) 
			subject.Weight = weight;
		subject.WeightUnitCode = weightUnitCode;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.ManifestUnitCode))
		{
			subject.Quantity = 8;
			subject.ManifestUnitCode = "n";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 6;
			subject.VolumeUnitQualifier = "w";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "v";
			subject.StandardCarrierAlphaCode2 = "vX";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "w", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "w", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string volumeUnitQualifier, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "m";
		subject.LocationIdentifier = "9";
		subject.StandardCarrierAlphaCode = "N0";
		//Test Parameters
		if (volume > 0) 
			subject.Volume = volume;
		subject.VolumeUnitQualifier = volumeUnitQualifier;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.ManifestUnitCode))
		{
			subject.Quantity = 8;
			subject.ManifestUnitCode = "n";
		}
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 7;
			subject.WeightUnitCode = "g";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "v";
			subject.StandardCarrierAlphaCode2 = "vX";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("v", "vX", true)]
	[InlineData("v", "", false)]
	[InlineData("", "vX", false)]
	public void Validation_AllAreRequiredBillOfLadingWaybillNumber2(string billOfLadingWaybillNumber2, string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "m";
		subject.LocationIdentifier = "9";
		subject.StandardCarrierAlphaCode = "N0";
		//Test Parameters
		subject.BillOfLadingWaybillNumber2 = billOfLadingWaybillNumber2;
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.ManifestUnitCode))
		{
			subject.Quantity = 8;
			subject.ManifestUnitCode = "n";
		}
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 7;
			subject.WeightUnitCode = "g";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 6;
			subject.VolumeUnitQualifier = "w";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N0", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "m";
		subject.LocationIdentifier = "9";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.ManifestUnitCode))
		{
			subject.Quantity = 8;
			subject.ManifestUnitCode = "n";
		}
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 7;
			subject.WeightUnitCode = "g";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 6;
			subject.VolumeUnitQualifier = "w";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "v";
			subject.StandardCarrierAlphaCode2 = "vX";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("UR", "ka", true)]
	[InlineData("UR", "", false)]
	[InlineData("", "ka", true)]
	public void Validation_ARequiresBStandardCarrierAlphaCode4(string standardCarrierAlphaCode4, string standardCarrierAlphaCode3, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "m";
		subject.LocationIdentifier = "9";
		subject.StandardCarrierAlphaCode = "N0";
		//Test Parameters
		subject.StandardCarrierAlphaCode4 = standardCarrierAlphaCode4;
		subject.StandardCarrierAlphaCode3 = standardCarrierAlphaCode3;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.ManifestUnitCode))
		{
			subject.Quantity = 8;
			subject.ManifestUnitCode = "n";
		}
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 7;
			subject.WeightUnitCode = "g";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 6;
			subject.VolumeUnitQualifier = "w";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "v";
			subject.StandardCarrierAlphaCode2 = "vX";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Sr", "UR", true)]
	[InlineData("Sr", "", false)]
	[InlineData("", "UR", true)]
	public void Validation_ARequiresBStandardCarrierAlphaCode5(string standardCarrierAlphaCode5, string standardCarrierAlphaCode4, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "m";
		subject.LocationIdentifier = "9";
		subject.StandardCarrierAlphaCode = "N0";
		//Test Parameters
		subject.StandardCarrierAlphaCode5 = standardCarrierAlphaCode5;
		subject.StandardCarrierAlphaCode4 = standardCarrierAlphaCode4;
		//A Requires B
		if (standardCarrierAlphaCode4 != "")
			subject.StandardCarrierAlphaCode3 = "ka";
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.ManifestUnitCode))
		{
			subject.Quantity = 8;
			subject.ManifestUnitCode = "n";
		}
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 7;
			subject.WeightUnitCode = "g";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 6;
			subject.VolumeUnitQualifier = "w";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "v";
			subject.StandardCarrierAlphaCode2 = "vX";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("cn", "Sr", true)]
	[InlineData("cn", "", false)]
	[InlineData("", "Sr", true)]
	public void Validation_ARequiresBStandardCarrierAlphaCode6(string standardCarrierAlphaCode6, string standardCarrierAlphaCode5, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "m";
		subject.LocationIdentifier = "9";
		subject.StandardCarrierAlphaCode = "N0";
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
			subject.Quantity = 8;
			subject.ManifestUnitCode = "n";
		}
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 7;
			subject.WeightUnitCode = "g";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 6;
			subject.VolumeUnitQualifier = "w";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "v";
			subject.StandardCarrierAlphaCode2 = "vX";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
