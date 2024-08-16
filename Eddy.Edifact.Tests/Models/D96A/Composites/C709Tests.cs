using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C709Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "T:O:j:M:F:G";

		var expected = new C709_MessageIdentifier()
		{
			MessageTypeIdentifier = "T",
			Version = "O",
			Release = "j",
			ControlAgency = "M",
			AssociationAssignedIdentification = "F",
			RevisionNumber = "G",
		};

		var actual = Map.MapComposite<C709_MessageIdentifier>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredMessageTypeIdentifier(string messageTypeIdentifier, bool isValidExpected)
	{
		var subject = new C709_MessageIdentifier();
		//Required fields
		subject.Version = "O";
		subject.Release = "j";
		subject.ControlAgency = "M";
		//Test Parameters
		subject.MessageTypeIdentifier = messageTypeIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredVersion(string version, bool isValidExpected)
	{
		var subject = new C709_MessageIdentifier();
		//Required fields
		subject.MessageTypeIdentifier = "T";
		subject.Release = "j";
		subject.ControlAgency = "M";
		//Test Parameters
		subject.Version = version;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredRelease(string release, bool isValidExpected)
	{
		var subject = new C709_MessageIdentifier();
		//Required fields
		subject.MessageTypeIdentifier = "T";
		subject.Version = "O";
		subject.ControlAgency = "M";
		//Test Parameters
		subject.Release = release;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredControlAgency(string controlAgency, bool isValidExpected)
	{
		var subject = new C709_MessageIdentifier();
		//Required fields
		subject.MessageTypeIdentifier = "T";
		subject.Version = "O";
		subject.Release = "j";
		//Test Parameters
		subject.ControlAgency = controlAgency;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
