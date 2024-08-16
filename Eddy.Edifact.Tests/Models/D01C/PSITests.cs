using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C;

public class PSITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PSI+1+++0+D+I+J+K+W+";

		var expected = new PSI_ServiceInformation()
		{
			ObjectIdentifier = "1",
			DateTimePeriod = null,
			Service = null,
			Quantity = "0",
			MonetaryAmount = "D",
			IndexText = "I",
			FacilityTypeDescriptionCode = "J",
			ServiceTypeCode = "K",
			SpecialConditionCode = "W",
			SupportingEvidence = null,
		};

		var actual = Map.MapObject<PSI_ServiceInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredObjectIdentifier(string objectIdentifier, bool isValidExpected)
	{
		var subject = new PSI_ServiceInformation();
		//Required fields
		//Test Parameters
		subject.ObjectIdentifier = objectIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
