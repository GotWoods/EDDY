using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class SVCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SVC**8*7*D*9**5";

		var expected = new SVC_ServiceInformation()
		{
			CompositeMedicalProcedureIdentifier = null,
			MonetaryAmount = 8,
			MonetaryAmount2 = 7,
			ProductServiceID = "D",
			Quantity = 9,
			CompositeMedicalProcedureIdentifier2 = null,
			Quantity2 = 5,
		};

		var actual = Map.MapObject<SVC_ServiceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredCompositeMedicalProcedureIdentifier(string compositeMedicalProcedureIdentifier, bool isValidExpected)
	{
		var subject = new SVC_ServiceInformation();
		//Required fields
		subject.MonetaryAmount = 8;
		//Test Parameters
		if (compositeMedicalProcedureIdentifier != "") 
			subject.CompositeMedicalProcedureIdentifier = new C003_CompositeMedicalProcedureIdentifier();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new SVC_ServiceInformation();
		//Required fields
		subject.CompositeMedicalProcedureIdentifier = new C003_CompositeMedicalProcedureIdentifier();
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
