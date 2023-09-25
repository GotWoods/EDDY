using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class W2ATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W2A*n*a*r*7*3*E*0h*8896*2*5*DDcK*xs*D*W";

		var expected = new W2A_EquipmentInformation()
		{
			EquipmentStatusCode = "n",
			EquipmentInitial = "a",
			EquipmentNumber = "r",
			EquipmentNumberCheckDigit = 7,
			Weight = 3,
			WeightQualifier = "E",
			EquipmentDescriptionCode = "0h",
			EquipmentLength = 8896,
			Height = 2,
			Width = 5,
			EquipmentType = "DDcK",
			ChassisType = "xs",
			EquipmentOwnerCode = "D",
			EquipmentOwnerCode2 = "W",
		};

		var actual = Map.MapObject<W2A_EquipmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredEquipmentStatusCode(string equipmentStatusCode, bool isValidExpected)
	{
		var subject = new W2A_EquipmentInformation();
		//Required fields
		subject.EquipmentInitial = "a";
		subject.EquipmentNumber = "r";
		//Test Parameters
		subject.EquipmentStatusCode = equipmentStatusCode;
		//If one filled, all required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier))
		{
			subject.Weight = 3;
			subject.WeightQualifier = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new W2A_EquipmentInformation();
		//Required fields
		subject.EquipmentStatusCode = "n";
		subject.EquipmentNumber = "r";
		//Test Parameters
		subject.EquipmentInitial = equipmentInitial;
		//If one filled, all required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier))
		{
			subject.Weight = 3;
			subject.WeightQualifier = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new W2A_EquipmentInformation();
		//Required fields
		subject.EquipmentStatusCode = "n";
		subject.EquipmentInitial = "a";
		//Test Parameters
		subject.EquipmentNumber = equipmentNumber;
		//If one filled, all required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.WeightQualifier))
		{
			subject.Weight = 3;
			subject.WeightQualifier = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "E", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "E", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string weightQualifier, bool isValidExpected)
	{
		var subject = new W2A_EquipmentInformation();
		//Required fields
		subject.EquipmentStatusCode = "n";
		subject.EquipmentInitial = "a";
		subject.EquipmentNumber = "r";
		//Test Parameters
		if (weight > 0) 
			subject.Weight = weight;
		subject.WeightQualifier = weightQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
