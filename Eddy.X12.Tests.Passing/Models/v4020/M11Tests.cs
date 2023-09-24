using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class M11Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M11*n*I*5*o*6*9*8*8*jx*j*0*BC*db*OW*hm*o*v3*Ow*0w";

		var expected = new M11_ManifestBillOfLadingDetails()
		{
			BillOfLadingWaybillNumber = "n",
			LocationIdentifier = "I",
			Quantity = 5,
			ManifestUnitCode = "o",
			Weight = 6,
			WeightUnitCode = "9",
			Volume = 8,
			VolumeUnitQualifier = "8",
			BillOfLadingTypeCode = "jx",
			PlaceOfReceiptByPreCarrier = "j",
			BillOfLadingWaybillNumber2 = "0",
			StandardCarrierAlphaCode = "BC",
			StandardCarrierAlphaCode2 = "db",
			StandardCarrierAlphaCode3 = "OW",
			StandardCarrierAlphaCode4 = "hm",
			ShippersExportDeclarationRequirements = "o",
			ExportExceptionCode = "v3",
			StandardCarrierAlphaCode5 = "Ow",
			StandardCarrierAlphaCode6 = "0w",
		};

		var actual = Map.MapObject<M11_ManifestBillOfLadingDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.LocationIdentifier = "I";
		subject.Quantity = 5;
		subject.ManifestUnitCode = "o";
		subject.Weight = 6;
		subject.WeightUnitCode = "9";
		subject.StandardCarrierAlphaCode = "BC";
		//Test Parameters
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 8;
			subject.VolumeUnitQualifier = "8";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "0";
			subject.StandardCarrierAlphaCode2 = "db";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "n";
		subject.Quantity = 5;
		subject.ManifestUnitCode = "o";
		subject.Weight = 6;
		subject.WeightUnitCode = "9";
		subject.StandardCarrierAlphaCode = "BC";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 8;
			subject.VolumeUnitQualifier = "8";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "0";
			subject.StandardCarrierAlphaCode2 = "db";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "n";
		subject.LocationIdentifier = "I";
		subject.ManifestUnitCode = "o";
		subject.Weight = 6;
		subject.WeightUnitCode = "9";
		subject.StandardCarrierAlphaCode = "BC";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 8;
			subject.VolumeUnitQualifier = "8";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "0";
			subject.StandardCarrierAlphaCode2 = "db";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredManifestUnitCode(string manifestUnitCode, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "n";
		subject.LocationIdentifier = "I";
		subject.Quantity = 5;
		subject.Weight = 6;
		subject.WeightUnitCode = "9";
		subject.StandardCarrierAlphaCode = "BC";
		//Test Parameters
		subject.ManifestUnitCode = manifestUnitCode;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 8;
			subject.VolumeUnitQualifier = "8";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "0";
			subject.StandardCarrierAlphaCode2 = "db";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredWeight(decimal weight, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "n";
		subject.LocationIdentifier = "I";
		subject.Quantity = 5;
		subject.ManifestUnitCode = "o";
		subject.WeightUnitCode = "9";
		subject.StandardCarrierAlphaCode = "BC";
		//Test Parameters
		if (weight > 0) 
			subject.Weight = weight;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 8;
			subject.VolumeUnitQualifier = "8";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "0";
			subject.StandardCarrierAlphaCode2 = "db";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredWeightUnitCode(string weightUnitCode, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "n";
		subject.LocationIdentifier = "I";
		subject.Quantity = 5;
		subject.ManifestUnitCode = "o";
		subject.Weight = 6;
		subject.StandardCarrierAlphaCode = "BC";
		//Test Parameters
		subject.WeightUnitCode = weightUnitCode;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 8;
			subject.VolumeUnitQualifier = "8";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "0";
			subject.StandardCarrierAlphaCode2 = "db";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "8", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "8", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string volumeUnitQualifier, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "n";
		subject.LocationIdentifier = "I";
		subject.Quantity = 5;
		subject.ManifestUnitCode = "o";
		subject.Weight = 6;
		subject.WeightUnitCode = "9";
		subject.StandardCarrierAlphaCode = "BC";
		//Test Parameters
		if (volume > 0) 
			subject.Volume = volume;
		subject.VolumeUnitQualifier = volumeUnitQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "0";
			subject.StandardCarrierAlphaCode2 = "db";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0", "db", true)]
	[InlineData("0", "", false)]
	[InlineData("", "db", false)]
	public void Validation_AllAreRequiredBillOfLadingWaybillNumber2(string billOfLadingWaybillNumber2, string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "n";
		subject.LocationIdentifier = "I";
		subject.Quantity = 5;
		subject.ManifestUnitCode = "o";
		subject.Weight = 6;
		subject.WeightUnitCode = "9";
		subject.StandardCarrierAlphaCode = "BC";
		//Test Parameters
		subject.BillOfLadingWaybillNumber2 = billOfLadingWaybillNumber2;
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 8;
			subject.VolumeUnitQualifier = "8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("BC", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "n";
		subject.LocationIdentifier = "I";
		subject.Quantity = 5;
		subject.ManifestUnitCode = "o";
		subject.Weight = 6;
		subject.WeightUnitCode = "9";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 8;
			subject.VolumeUnitQualifier = "8";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "0";
			subject.StandardCarrierAlphaCode2 = "db";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("hm", "OW", true)]
	[InlineData("hm", "", false)]
	[InlineData("", "OW", true)]
	public void Validation_ARequiresBStandardCarrierAlphaCode4(string standardCarrierAlphaCode4, string standardCarrierAlphaCode3, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "n";
		subject.LocationIdentifier = "I";
		subject.Quantity = 5;
		subject.ManifestUnitCode = "o";
		subject.Weight = 6;
		subject.WeightUnitCode = "9";
		subject.StandardCarrierAlphaCode = "BC";
		//Test Parameters
		subject.StandardCarrierAlphaCode4 = standardCarrierAlphaCode4;
		subject.StandardCarrierAlphaCode3 = standardCarrierAlphaCode3;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 8;
			subject.VolumeUnitQualifier = "8";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "0";
			subject.StandardCarrierAlphaCode2 = "db";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ow", "hm", true)]
	[InlineData("Ow", "", false)]
	[InlineData("", "hm", true)]
	public void Validation_ARequiresBStandardCarrierAlphaCode5(string standardCarrierAlphaCode5, string standardCarrierAlphaCode4, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "n";
		subject.LocationIdentifier = "I";
		subject.Quantity = 5;
		subject.ManifestUnitCode = "o";
		subject.Weight = 6;
		subject.WeightUnitCode = "9";
		subject.StandardCarrierAlphaCode = "BC";
		//Test Parameters
		subject.StandardCarrierAlphaCode5 = standardCarrierAlphaCode5;
		subject.StandardCarrierAlphaCode4 = standardCarrierAlphaCode4;
		//A Requires B
		if (standardCarrierAlphaCode4 != "")
			subject.StandardCarrierAlphaCode3 = "OW";
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 8;
			subject.VolumeUnitQualifier = "8";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "0";
			subject.StandardCarrierAlphaCode2 = "db";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0w", "Ow", true)]
	[InlineData("0w", "", false)]
	[InlineData("", "Ow", true)]
	public void Validation_ARequiresBStandardCarrierAlphaCode6(string standardCarrierAlphaCode6, string standardCarrierAlphaCode5, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "n";
		subject.LocationIdentifier = "I";
		subject.Quantity = 5;
		subject.ManifestUnitCode = "o";
		subject.Weight = 6;
		subject.WeightUnitCode = "9";
		subject.StandardCarrierAlphaCode = "BC";
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
        if (subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 8;
			subject.VolumeUnitQualifier = "8";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "0";
			subject.StandardCarrierAlphaCode2 = "db";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
