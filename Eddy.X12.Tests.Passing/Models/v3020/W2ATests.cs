using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class W2ATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W2A*s*P*k*9*1*d*6D*2313*8*7*LzrL*N7*b*0";

		var expected = new W2A_EquipmentInformation()
		{
			EquipmentStatusCode = "s",
			EquipmentInitial = "P",
			EquipmentNumber = "k",
			EquipmentNumberCheckDigit = 9,
			Weight = 1,
			WeightQualifier = "d",
			EquipmentDescriptionCode = "6D",
			EquipmentLength = 2313,
			Height = 8,
			Width = 7,
			EquipmentType = "LzrL",
			ChassisType = "N7",
			EquipmentOwnerCode = "b",
			EquipmentOwnerCode2 = "0",
		};

		var actual = Map.MapObject<W2A_EquipmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredEquipmentStatusCode(string equipmentStatusCode, bool isValidExpected)
	{
		var subject = new W2A_EquipmentInformation();
		//Required fields
		subject.EquipmentInitial = "P";
		subject.EquipmentNumber = "k";
		//Test Parameters
		subject.EquipmentStatusCode = equipmentStatusCode;
		//If one filled, all required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier))
		{
			subject.Weight = 1;
			subject.WeightQualifier = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new W2A_EquipmentInformation();
		//Required fields
		subject.EquipmentStatusCode = "s";
		subject.EquipmentNumber = "k";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		//If one filled, all required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier))
		{
			subject.Weight = 1;
			subject.WeightQualifier = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new W2A_EquipmentInformation();
		//Required fields
		subject.EquipmentStatusCode = "s";
		subject.EquipmentInitial = "P";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		//If one filled, all required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier))
		{
			subject.Weight = 1;
			subject.WeightQualifier = "d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "d", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "d", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string weightQualifier, bool isValidExpected)
	{
		var subject = new W2A_EquipmentInformation();
		//Required fields
		subject.EquipmentStatusCode = "s";
		subject.EquipmentInitial = "P";
		subject.EquipmentNumber = "k";
		//Test Parameters
		if (weight > 0) 
			subject.Weight = weight;
		subject.WeightQualifier = weightQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
