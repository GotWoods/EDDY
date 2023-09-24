using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class M11Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M11*c*7*6*p*1*6*4*X*fS*S*b*Vd*8u*Zw*Aa";

		var expected = new M11_ManifestBillOfLadingDetails()
		{
			BillOfLadingWaybillNumber = "c",
			LocationIdentifier = "7",
			Quantity = 6,
			ManifestUnitCode = "p",
			Weight = 1,
			WeightUnitQualifier = "6",
			Volume = 4,
			VolumeUnitQualifier = "X",
			BillOfLadingStatusCode = "fS",
			PlaceOfReceiptByPreCarrier = "S",
			BillOfLadingWaybillNumber2 = "b",
			StandardCarrierAlphaCode = "Vd",
			StandardCarrierAlphaCode2 = "8u",
			StandardCarrierAlphaCode3 = "Zw",
			StandardCarrierAlphaCode4 = "Aa",
		};

		var actual = Map.MapObject<M11_ManifestBillOfLadingDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredBillOfLadingWaybillNumber(string billOfLadingWaybillNumber, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.LocationIdentifier = "7";
		subject.Quantity = 6;
		subject.ManifestUnitCode = "p";
		subject.Weight = 1;
		subject.WeightUnitQualifier = "6";
		subject.StandardCarrierAlphaCode = "Vd";
		//Test Parameters
		subject.BillOfLadingWaybillNumber = billOfLadingWaybillNumber;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 4;
			subject.VolumeUnitQualifier = "X";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "b";
			subject.StandardCarrierAlphaCode2 = "8u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "c";
		subject.Quantity = 6;
		subject.ManifestUnitCode = "p";
		subject.Weight = 1;
		subject.WeightUnitQualifier = "6";
		subject.StandardCarrierAlphaCode = "Vd";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 4;
			subject.VolumeUnitQualifier = "X";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "b";
			subject.StandardCarrierAlphaCode2 = "8u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "c";
		subject.LocationIdentifier = "7";
		subject.ManifestUnitCode = "p";
		subject.Weight = 1;
		subject.WeightUnitQualifier = "6";
		subject.StandardCarrierAlphaCode = "Vd";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 4;
			subject.VolumeUnitQualifier = "X";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "b";
			subject.StandardCarrierAlphaCode2 = "8u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredManifestUnitCode(string manifestUnitCode, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "c";
		subject.LocationIdentifier = "7";
		subject.Quantity = 6;
		subject.Weight = 1;
		subject.WeightUnitQualifier = "6";
		subject.StandardCarrierAlphaCode = "Vd";
		//Test Parameters
		subject.ManifestUnitCode = manifestUnitCode;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 4;
			subject.VolumeUnitQualifier = "X";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "b";
			subject.StandardCarrierAlphaCode2 = "8u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredWeight(decimal weight, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "c";
		subject.LocationIdentifier = "7";
		subject.Quantity = 6;
		subject.ManifestUnitCode = "p";
		subject.WeightUnitQualifier = "6";
		subject.StandardCarrierAlphaCode = "Vd";
		//Test Parameters
		if (weight > 0) 
			subject.Weight = weight;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 4;
			subject.VolumeUnitQualifier = "X";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "b";
			subject.StandardCarrierAlphaCode2 = "8u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredWeightUnitQualifier(string weightUnitQualifier, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "c";
		subject.LocationIdentifier = "7";
		subject.Quantity = 6;
		subject.ManifestUnitCode = "p";
		subject.Weight = 1;
		subject.StandardCarrierAlphaCode = "Vd";
		//Test Parameters
		subject.WeightUnitQualifier = weightUnitQualifier;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 4;
			subject.VolumeUnitQualifier = "X";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "b";
			subject.StandardCarrierAlphaCode2 = "8u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "X", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "X", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string volumeUnitQualifier, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "c";
		subject.LocationIdentifier = "7";
		subject.Quantity = 6;
		subject.ManifestUnitCode = "p";
		subject.Weight = 1;
		subject.WeightUnitQualifier = "6";
		subject.StandardCarrierAlphaCode = "Vd";
		//Test Parameters
		if (volume > 0) 
			subject.Volume = volume;
		subject.VolumeUnitQualifier = volumeUnitQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "b";
			subject.StandardCarrierAlphaCode2 = "8u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("b", "8u", true)]
	[InlineData("b", "", false)]
	[InlineData("", "8u", false)]
	public void Validation_AllAreRequiredBillOfLadingWaybillNumber2(string billOfLadingWaybillNumber2, string standardCarrierAlphaCode2, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "c";
		subject.LocationIdentifier = "7";
		subject.Quantity = 6;
		subject.ManifestUnitCode = "p";
		subject.Weight = 1;
		subject.WeightUnitQualifier = "6";
		subject.StandardCarrierAlphaCode = "Vd";
		//Test Parameters
		subject.BillOfLadingWaybillNumber2 = billOfLadingWaybillNumber2;
		subject.StandardCarrierAlphaCode2 = standardCarrierAlphaCode2;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 4;
			subject.VolumeUnitQualifier = "X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Vd", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new M11_ManifestBillOfLadingDetails();
		//Required fields
		subject.BillOfLadingWaybillNumber = "c";
		subject.LocationIdentifier = "7";
		subject.Quantity = 6;
		subject.ManifestUnitCode = "p";
		subject.Weight = 1;
		subject.WeightUnitQualifier = "6";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.VolumeUnitQualifier))
		{
			subject.Volume = 4;
			subject.VolumeUnitQualifier = "X";
		}
		if(!string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.BillOfLadingWaybillNumber2) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode2))
		{
			subject.BillOfLadingWaybillNumber2 = "b";
			subject.StandardCarrierAlphaCode2 = "8u";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
