using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class DELTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DEL*9*5*n2*L*T";

		var expected = new DEL_DeliveryLogistics()
		{
			Quantity = 9,
			IdentificationCodeQualifier = "5",
			IdentificationCode = "n2",
			InvoiceNumber = "L",
			MoveTypeCode = "T",
		};

		var actual = Map.MapObject<DEL_DeliveryLogistics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validatation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new DEL_DeliveryLogistics();
		subject.IdentificationCodeQualifier = "5";
		subject.IdentificationCode = "n2";
		if (quantity > 0)
		subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validatation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new DEL_DeliveryLogistics();
		subject.Quantity = 9;
		subject.IdentificationCode = "n2";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n2", true)]
	public void Validatation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new DEL_DeliveryLogistics();
		subject.Quantity = 9;
		subject.IdentificationCodeQualifier = "5";
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
