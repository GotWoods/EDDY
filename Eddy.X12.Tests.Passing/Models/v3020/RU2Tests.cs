using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class RU2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RU2*o*g*uWsFiv*Qo*i*g*piK8Uy*ZDba8s";

		var expected = new RU2_EmployingCarrierResponse()
		{
			RailRetirementActivityCode = "o",
			ReferenceNumber = "g",
			Date = "uWsFiv",
			EmploymentStatusCode = "Qo",
			Amount = "i",
			FrequencyCode = "g",
			Date2 = "piK8Uy",
			Date3 = "ZDba8s",
		};

		var actual = Map.MapObject<RU2_EmployingCarrierResponse>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredRailRetirementActivityCode(string railRetirementActivityCode, bool isValidExpected)
	{
		var subject = new RU2_EmployingCarrierResponse();
		//Required fields
		subject.ReferenceNumber = "g";
		//Test Parameters
		subject.RailRetirementActivityCode = railRetirementActivityCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.EmploymentStatusCode))
		{
			subject.Date = "uWsFiv";
			subject.EmploymentStatusCode = "Qo";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new RU2_EmployingCarrierResponse();
		//Required fields
		subject.RailRetirementActivityCode = "o";
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.Date) || !string.IsNullOrEmpty(subject.EmploymentStatusCode))
		{
			subject.Date = "uWsFiv";
			subject.EmploymentStatusCode = "Qo";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("uWsFiv", "Qo", true)]
	[InlineData("uWsFiv", "", false)]
	[InlineData("", "Qo", false)]
	public void Validation_AllAreRequiredDate(string date, string employmentStatusCode, bool isValidExpected)
	{
		var subject = new RU2_EmployingCarrierResponse();
		//Required fields
		subject.RailRetirementActivityCode = "o";
		subject.ReferenceNumber = "g";
		//Test Parameters
		subject.Date = date;
		subject.EmploymentStatusCode = employmentStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
