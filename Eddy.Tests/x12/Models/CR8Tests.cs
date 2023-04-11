using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class CR8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CR8*K*O*U1VEEud1*O9xCprIV*V*X*V*h*t";

		var expected = new CR8_ImplantCertification()
		{
			ImplantTypeCode = "K",
			ImplantStatusCode = "O",
			Date = "U1VEEud1",
			Date2 = "O9xCprIV",
			ReferenceIdentification = "V",
			ReferenceIdentification2 = "X",
			ReferenceIdentification3 = "V",
			YesNoConditionOrResponseCode = "h",
			YesNoConditionOrResponseCode2 = "t",
		};

		var actual = Map.MapObject<CR8_ImplantCertification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validatation_RequiredImplantTypeCode(string implantTypeCode, bool isValidExpected)
	{
		var subject = new CR8_ImplantCertification();
		subject.ImplantStatusCode = "O";
		subject.ImplantTypeCode = implantTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validatation_RequiredImplantStatusCode(string implantStatusCode, bool isValidExpected)
	{
		var subject = new CR8_ImplantCertification();
		subject.ImplantTypeCode = "K";
		subject.ImplantStatusCode = implantStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
