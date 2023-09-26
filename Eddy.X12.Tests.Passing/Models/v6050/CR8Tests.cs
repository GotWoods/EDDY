using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6050;

namespace Eddy.x12.Tests.Models.v6050;

public class CR8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CR8*n*u*tSjbVn4d*meNASGAP*Z*1*d*b*t";

		var expected = new CR8_ImplantCertification()
		{
			ImplantTypeCode = "n",
			ImplantStatusCode = "u",
			Date = "tSjbVn4d",
			Date2 = "meNASGAP",
			ReferenceIdentification = "Z",
			ReferenceIdentification2 = "1",
			ReferenceIdentification3 = "d",
			YesNoConditionOrResponseCode = "b",
			YesNoConditionOrResponseCode2 = "t",
		};

		var actual = Map.MapObject<CR8_ImplantCertification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredImplantTypeCode(string implantTypeCode, bool isValidExpected)
	{
		var subject = new CR8_ImplantCertification();
		//Required fields
		subject.ImplantStatusCode = "u";
		//Test Parameters
		subject.ImplantTypeCode = implantTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredImplantStatusCode(string implantStatusCode, bool isValidExpected)
	{
		var subject = new CR8_ImplantCertification();
		//Required fields
		subject.ImplantTypeCode = "n";
		//Test Parameters
		subject.ImplantStatusCode = implantStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
