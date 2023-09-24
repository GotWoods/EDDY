using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class W2ATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W2A*k*m*B*3*2*2*UV*7887*2*7*z3kW*pI*0A*DH";

		var expected = new W2A_EquipmentInformation()
		{
			EquipmentStatusCode = "k",
			EquipmentInitial = "m",
			EquipmentNumber = "B",
			EquipmentNumberCheckDigit = 3,
			Weight = 2,
			WeightQualifier = "2",
			EquipmentDescriptionCode = "UV",
			EquipmentLength = 7887,
			Height = 2,
			Width = 7,
			EquipmentType = "z3kW",
			ChassisType = "pI",
			StandardCarrierAlphaCode = "0A",
			StandardCarrierAlphaCode2 = "DH",
		};

		var actual = Map.MapObject<W2A_EquipmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredEquipmentStatusCode(string equipmentStatusCode, bool isValidExpected)
	{
		var subject = new W2A_EquipmentInformation();
		//Required fields
		subject.EquipmentInitial = "m";
		subject.EquipmentNumber = "B";
		//Test Parameters
		subject.EquipmentStatusCode = equipmentStatusCode;
		//If one filled, all required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier))
		{
			subject.Weight = 2;
			subject.WeightQualifier = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new W2A_EquipmentInformation();
		//Required fields
		subject.EquipmentStatusCode = "k";
		subject.EquipmentNumber = "B";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		//If one filled, all required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier))
		{
			subject.Weight = 2;
			subject.WeightQualifier = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new W2A_EquipmentInformation();
		//Required fields
		subject.EquipmentStatusCode = "k";
		subject.EquipmentInitial = "m";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		//If one filled, all required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier))
		{
			subject.Weight = 2;
			subject.WeightQualifier = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "2", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "2", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string weightQualifier, bool isValidExpected)
	{
		var subject = new W2A_EquipmentInformation();
		//Required fields
		subject.EquipmentStatusCode = "k";
		subject.EquipmentInitial = "m";
		subject.EquipmentNumber = "B";
		//Test Parameters
		if (weight > 0) 
			subject.Weight = weight;
		subject.WeightQualifier = weightQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
