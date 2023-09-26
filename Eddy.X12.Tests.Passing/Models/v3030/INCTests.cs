using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class INCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "INC*Is*n1*1*8*3";

		var expected = new INC_InstallmentInformation()
		{
			TermsTypeCode = "Is",
			UnitOrBasisForMeasurementCode = "n1",
			Quantity = 1,
			Quantity2 = 8,
			MonetaryAmount = 3,
		};

		var actual = Map.MapObject<INC_InstallmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Is", true)]
	public void Validation_RequiredTermsTypeCode(string termsTypeCode, bool isValidExpected)
	{
		var subject = new INC_InstallmentInformation();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "n1";
		subject.Quantity = 1;
		subject.Quantity2 = 8;
		//Test Parameters
		subject.TermsTypeCode = termsTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n1", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new INC_InstallmentInformation();
		//Required fields
		subject.TermsTypeCode = "Is";
		subject.Quantity = 1;
		subject.Quantity2 = 8;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new INC_InstallmentInformation();
		//Required fields
		subject.TermsTypeCode = "Is";
		subject.UnitOrBasisForMeasurementCode = "n1";
		subject.Quantity2 = 8;
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredQuantity2(decimal quantity2, bool isValidExpected)
	{
		var subject = new INC_InstallmentInformation();
		//Required fields
		subject.TermsTypeCode = "Is";
		subject.UnitOrBasisForMeasurementCode = "n1";
		subject.Quantity = 1;
		//Test Parameters
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
