using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class PSITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PSI+A+++P+M+m+r+0+L+";

		var expected = new PSI_ServiceInformation()
		{
			ObjectIdentifier = "A",
			DateTimePeriod = null,
			Service = null,
			Quantity = "P",
			MonetaryAmount = "M",
			IndexValue = "m",
			FacilityTypeDescriptionCode = "r",
			ServiceTypeCode = "0",
			SpecialConditionCode = "L",
			SupportingEvidence = null,
		};

		var actual = Map.MapObject<PSI_ServiceInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredObjectIdentifier(string objectIdentifier, bool isValidExpected)
	{
		var subject = new PSI_ServiceInformation();
		//Required fields
		//Test Parameters
		subject.ObjectIdentifier = objectIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
