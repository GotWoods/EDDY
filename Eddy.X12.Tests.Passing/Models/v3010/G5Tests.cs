using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G5*Z*c*8*3cyDJe*8*b*315*w*97*H*8*td*a*a*Xs*Z*34yl7m";

		var expected = new G5_ScaleInformationSegment()
		{
			EquipmentInitial = "Z",
			EquipmentNumber = "c",
			WaybillNumber = 8,
			WaybillDate = "3cyDJe",
			Weight = 8,
			WeightQualifier = "b",
			TareWeight = 315,
			TareQualifierCode = "w",
			WeightAllowance = 97,
			WeightAllowanceTypeCode = "H",
			FreightRate = 8,
			RateValueQualifier = "td",
			InterchangeTrainIdentification = "a",
			CommodityCode = "a",
			ReferenceNumberQualifier = "Xs",
			ReferenceNumber = "Z",
			Date = "34yl7m",
		};

		var actual = Map.MapObject<G5_ScaleInformationSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredEquipmentInitial(string equipmentInitial, bool isValidExpected)
	{
		var subject = new G5_ScaleInformationSegment();
		subject.EquipmentNumber = "c";
		subject.Weight = 8;
		subject.WeightQualifier = "b";
		subject.EquipmentInitial = equipmentInitial;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredEquipmentNumber(string equipmentNumber, bool isValidExpected)
	{
		var subject = new G5_ScaleInformationSegment();
		subject.EquipmentInitial = "Z";
		subject.Weight = 8;
		subject.WeightQualifier = "b";
		subject.EquipmentNumber = equipmentNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredWeight(decimal weight, bool isValidExpected)
	{
		var subject = new G5_ScaleInformationSegment();
		subject.EquipmentInitial = "Z";
		subject.EquipmentNumber = "c";
		subject.WeightQualifier = "b";
		if (weight > 0)
			subject.Weight = weight;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredWeightQualifier(string weightQualifier, bool isValidExpected)
	{
		var subject = new G5_ScaleInformationSegment();
		subject.EquipmentInitial = "Z";
		subject.EquipmentNumber = "c";
		subject.Weight = 8;
		subject.WeightQualifier = weightQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
