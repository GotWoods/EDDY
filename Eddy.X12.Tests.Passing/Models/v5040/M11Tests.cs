using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.Tests.Models.v5040;

public class M11Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M11*N*q*2*T*5*q*7*z*Az*V*d*Nu*9u*h5*Ry*I*aK*iE*9e*G*5*i*huK*0*m*Vv*CU19IfHO*x";

		var expected = new M11_ManifestBillOfLadingDetails()
		{
			BillOfLadingWaybillNumber = "N",
			LocationIdentifier = "q",
			Quantity = 2,
			ManifestUnitCode = "T",
			Weight = 5,
			WeightUnitCode = "q",
			Volume = 7,
			VolumeUnitQualifier = "z",
			BillOfLadingTypeCode = "Az",
			PlaceOfReceiptByPreCarrier = "V",
			BillOfLadingWaybillNumber2 = "d",
			StandardCarrierAlphaCode = "Nu",
			StandardCarrierAlphaCode2 = "9u",
			StandardCarrierAlphaCode3 = "h5",
			StandardCarrierAlphaCode4 = "Ry",
			ShippersExportDeclarationRequirements = "I",
			ExportExceptionCode = "aK",
			StandardCarrierAlphaCode5 = "iE",
			StandardCarrierAlphaCode6 = "9e",
			LocationIdentifier2 = "G",
			LocationIdentifier3 = "5",
			TransportationMethodTypeCode = "i",
			PaymentMethodCode = "huK",
			IndustryCode = "0",
			LocationQualifier = "m",
			ServiceLevelCode = "Vv",
			Date = "CU19IfHO",
			YesNoConditionOrResponseCode = "x",
		};

		var actual = Map.MapObject<M11_ManifestBillOfLadingDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.LocationIdentifier = "q";
		subject.StandardCarrierAlphaCode = "Nu";
		subject.LocationQualifier = "m";
		//Test Parameters
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.ManifestUnitCode))
		{
			subject.Quantity = 2;
			subject.ManifestUnitCode = "T";
		}
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 5;
			subject.WeightUnitCode = "q";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 7;
			subject.VolumeUnitQualifier = "z";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "d";
			subject.StandardCarrierAlphaCode2 = "9u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "N";
		subject.StandardCarrierAlphaCode = "Nu";
		subject.LocationQualifier = "m";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.ManifestUnitCode))
		{
			subject.Quantity = 2;
			subject.ManifestUnitCode = "T";
		}
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 5;
			subject.WeightUnitCode = "q";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 7;
			subject.VolumeUnitQualifier = "z";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "d";
			subject.StandardCarrierAlphaCode2 = "9u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "T", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "T", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, string manifestUnitCode, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "N";
		subject.LocationIdentifier = "q";
		subject.StandardCarrierAlphaCode = "Nu";
		subject.LocationQualifier = "m";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.ManifestUnitCode = manifestUnitCode;
		//If one filled, all required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 5;
			subject.WeightUnitCode = "q";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 7;
			subject.VolumeUnitQualifier = "z";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "d";
			subject.StandardCarrierAlphaCode2 = "9u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "q", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "q", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string weightUnitCode, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "N";
		subject.LocationIdentifier = "q";
		subject.StandardCarrierAlphaCode = "Nu";
		subject.LocationQualifier = "m";
		//Test Parameters
		if (weight > 0) 
			subject.Weight = weight;
		subject.WeightUnitCode = weightUnitCode;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.ManifestUnitCode))
		{
			subject.Quantity = 2;
			subject.ManifestUnitCode = "T";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 7;
			subject.VolumeUnitQualifier = "z";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "d";
			subject.StandardCarrierAlphaCode2 = "9u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "z", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "z", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string volumeUnitQualifier, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "N";
		subject.LocationIdentifier = "q";
		subject.StandardCarrierAlphaCode = "Nu";
		subject.LocationQualifier = "m";
		//Test Parameters
		if (volume > 0) 
			subject.Volume = volume;
		subject.VolumeUnitQualifier = volumeUnitQualifier;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.ManifestUnitCode))
		{
			subject.Quantity = 2;
			subject.ManifestUnitCode = "T";
		}
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 5;
			subject.WeightUnitCode = "q";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "d";
			subject.StandardCarrierAlphaCode2 = "9u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("d", "9u", true)]
	[InlineData("d", "", false)]
	[InlineData("", "9u", false)]
	public void Validation_AllAreRequiredBillOfLadingWaybillNumber2(string billOfLadingWaybillNumber2, string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "N";
		subject.LocationIdentifier = "q";
		subject.StandardCarrierAlphaCode = "Nu";
		subject.LocationQualifier = "m";
		//Test Parameters
		subject.BillOfLadingWaybillNumber2 = billOfLadingWaybillNumber2;
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.ManifestUnitCode))
		{
			subject.Quantity = 2;
			subject.ManifestUnitCode = "T";
		}
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 5;
			subject.WeightUnitCode = "q";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 7;
			subject.VolumeUnitQualifier = "z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Nu", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "N";
		subject.LocationIdentifier = "q";
		subject.LocationQualifier = "m";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.ManifestUnitCode))
		{
			subject.Quantity = 2;
			subject.ManifestUnitCode = "T";
		}
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 5;
			subject.WeightUnitCode = "q";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 7;
			subject.VolumeUnitQualifier = "z";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "d";
			subject.StandardCarrierAlphaCode2 = "9u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ry", "h5", true)]
	[InlineData("Ry", "", false)]
	[InlineData("", "h5", true)]
	public void Validation_ARequiresBStandardCarrierAlphaCode4(string standardCarrierAlphaCode4, string standardCarrierAlphaCode3, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "N";
		subject.LocationIdentifier = "q";
		subject.StandardCarrierAlphaCode = "Nu";
		subject.LocationQualifier = "m";
		//Test Parameters
		subject.StandardCarrierAlphaCode4 = standardCarrierAlphaCode4;
		subject.StandardCarrierAlphaCode3 = standardCarrierAlphaCode3;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.ManifestUnitCode))
		{
			subject.Quantity = 2;
			subject.ManifestUnitCode = "T";
		}
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 5;
			subject.WeightUnitCode = "q";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 7;
			subject.VolumeUnitQualifier = "z";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "d";
			subject.StandardCarrierAlphaCode2 = "9u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("iE", "Ry", true)]
	[InlineData("iE", "", false)]
	[InlineData("", "Ry", true)]
	public void Validation_ARequiresBStandardCarrierAlphaCode5(string standardCarrierAlphaCode5, string standardCarrierAlphaCode4, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "N";
		subject.LocationIdentifier = "q";
		subject.StandardCarrierAlphaCode = "Nu";
		subject.LocationQualifier = "m";
		//Test Parameters
		subject.StandardCarrierAlphaCode5 = standardCarrierAlphaCode5;
		subject.StandardCarrierAlphaCode4 = standardCarrierAlphaCode4;
		//A Requires B
		if (standardCarrierAlphaCode4 != "")
			subject.StandardCarrierAlphaCode3 = "h5";
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.ManifestUnitCode))
		{
			subject.Quantity = 2;
			subject.ManifestUnitCode = "T";
		}
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 5;
			subject.WeightUnitCode = "q";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 7;
			subject.VolumeUnitQualifier = "z";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "d";
			subject.StandardCarrierAlphaCode2 = "9u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("9e", "iE", true)]
	[InlineData("9e", "", false)]
	[InlineData("", "iE", true)]
	public void Validation_ARequiresBStandardCarrierAlphaCode6(string standardCarrierAlphaCode6, string standardCarrierAlphaCode5, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "N";
		subject.LocationIdentifier = "q";
		subject.StandardCarrierAlphaCode = "Nu";
		subject.LocationQualifier = "m";
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
			subject.Quantity = 2;
			subject.ManifestUnitCode = "T";
		}
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 5;
			subject.WeightUnitCode = "q";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 7;
			subject.VolumeUnitQualifier = "z";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "d";
			subject.StandardCarrierAlphaCode2 = "9u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredLocationQualifier(string locationQualifier, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "N";
		subject.LocationIdentifier = "q";
		subject.StandardCarrierAlphaCode = "Nu";
		//Test Parameters
		subject.LocationQualifier = locationQualifier;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.ManifestUnitCode))
		{
			subject.Quantity = 2;
			subject.ManifestUnitCode = "T";
		}
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightUnitCode))
		{
			subject.Weight = 5;
			subject.WeightUnitCode = "q";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 7;
			subject.VolumeUnitQualifier = "z";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "d";
			subject.StandardCarrierAlphaCode2 = "9u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
