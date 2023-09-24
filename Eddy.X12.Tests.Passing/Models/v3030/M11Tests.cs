using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class M11Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M11*m*4*8*g*2*5*3*w*wd*A*R*j7*Me*ot*mR*8";

		var expected = new M11_ManifestBillOfLadingDetails()
		{
			BillOfLadingWaybillNumber = "m",
			LocationIdentifier = "4",
			Quantity = 8,
			ManifestUnitCode = "g",
			Weight = 2,
			WeightUnitCode = "5",
			Volume = 3,
			VolumeUnitQualifier = "w",
			BillOfLadingStatusCode = "wd",
			PlaceOfReceiptByPreCarrier = "A",
			BillOfLadingWaybillNumber2 = "R",
			StandardCarrierAlphaCode = "j7",
			StandardCarrierAlphaCode2 = "Me",
			StandardCarrierAlphaCode3 = "ot",
			StandardCarrierAlphaCode4 = "mR",
			ShippersExportDeclarationRequirements = "8",
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
		subject.LocationIdentifier = "4";
		subject.Quantity = 8;
		subject.ManifestUnitCode = "g";
		subject.Weight = 2;
		subject.WeightUnitCode = "5";
		subject.StandardCarrierAlphaCode = "j7";
		//Test Parameters
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 3;
			subject.VolumeUnitQualifier = "w";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "R";
			subject.StandardCarrierAlphaCode2 = "Me";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "m";
		subject.Quantity = 8;
		subject.ManifestUnitCode = "g";
		subject.Weight = 2;
		subject.WeightUnitCode = "5";
		subject.StandardCarrierAlphaCode = "j7";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 3;
			subject.VolumeUnitQualifier = "w";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "R";
			subject.StandardCarrierAlphaCode2 = "Me";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "m";
		subject.LocationIdentifier = "4";
		subject.ManifestUnitCode = "g";
		subject.Weight = 2;
		subject.WeightUnitCode = "5";
		subject.StandardCarrierAlphaCode = "j7";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 3;
			subject.VolumeUnitQualifier = "w";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "R";
			subject.StandardCarrierAlphaCode2 = "Me";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredManifestUnitCode(string manifestUnitCode, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "m";
		subject.LocationIdentifier = "4";
		subject.Quantity = 8;
		subject.Weight = 2;
		subject.WeightUnitCode = "5";
		subject.StandardCarrierAlphaCode = "j7";
		//Test Parameters
		subject.ManifestUnitCode = manifestUnitCode;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 3;
			subject.VolumeUnitQualifier = "w";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "R";
			subject.StandardCarrierAlphaCode2 = "Me";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredWeight(decimal weight, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "m";
		subject.LocationIdentifier = "4";
		subject.Quantity = 8;
		subject.ManifestUnitCode = "g";
		subject.WeightUnitCode = "5";
		subject.StandardCarrierAlphaCode = "j7";
		//Test Parameters
		if (weight > 0) 
			subject.Weight = weight;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 3;
			subject.VolumeUnitQualifier = "w";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "R";
			subject.StandardCarrierAlphaCode2 = "Me";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredWeightUnitCode(string weightUnitCode, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "m";
		subject.LocationIdentifier = "4";
		subject.Quantity = 8;
		subject.ManifestUnitCode = "g";
		subject.Weight = 2;
		subject.StandardCarrierAlphaCode = "j7";
		//Test Parameters
		subject.WeightUnitCode = weightUnitCode;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 3;
			subject.VolumeUnitQualifier = "w";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "R";
			subject.StandardCarrierAlphaCode2 = "Me";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "w", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "w", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string volumeUnitQualifier, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "m";
		subject.LocationIdentifier = "4";
		subject.Quantity = 8;
		subject.ManifestUnitCode = "g";
		subject.Weight = 2;
		subject.WeightUnitCode = "5";
		subject.StandardCarrierAlphaCode = "j7";
		//Test Parameters
		if (volume > 0) 
			subject.Volume = volume;
		subject.VolumeUnitQualifier = volumeUnitQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "R";
			subject.StandardCarrierAlphaCode2 = "Me";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("R", "Me", true)]
	[InlineData("R", "", false)]
	[InlineData("", "Me", false)]
	public void Validation_AllAreRequiredBillOfLadingWaybillNumber2(string billOfLadingWaybillNumber2, string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "m";
		subject.LocationIdentifier = "4";
		subject.Quantity = 8;
		subject.ManifestUnitCode = "g";
		subject.Weight = 2;
		subject.WeightUnitCode = "5";
		subject.StandardCarrierAlphaCode = "j7";
		//Test Parameters
		subject.BillOfLadingWaybillNumber2 = billOfLadingWaybillNumber2;
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 3;
			subject.VolumeUnitQualifier = "w";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j7", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "m";
		subject.LocationIdentifier = "4";
		subject.Quantity = 8;
		subject.ManifestUnitCode = "g";
		subject.Weight = 2;
		subject.WeightUnitCode = "5";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 3;
			subject.VolumeUnitQualifier = "w";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "R";
			subject.StandardCarrierAlphaCode2 = "Me";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
