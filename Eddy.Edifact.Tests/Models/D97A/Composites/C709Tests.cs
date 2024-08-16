using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class C709Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "o:U:T:2:z:p:t";

		var expected = new C709_MessageIdentifier()
		{
			MessageTypeIdentifier = "o",
			Version = "U",
			Release = "T",
			ControlAgency = "2",
			AssociationAssignedIdentification = "z",
			RevisionNumber = "p",
			DocumentMessageStatusCoded = "t",
		};

		var actual = Map.MapComposite<C709_MessageIdentifier>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredMessageTypeIdentifier(string messageTypeIdentifier, bool isValidExpected)
	{
		var subject = new C709_MessageIdentifier();
		//Required fields
		subject.Version = "U";
		subject.Release = "T";
		subject.ControlAgency = "2";
		//Test Parameters
		subject.MessageTypeIdentifier = messageTypeIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredVersion(string version, bool isValidExpected)
	{
		var subject = new C709_MessageIdentifier();
		//Required fields
		subject.MessageTypeIdentifier = "o";
		subject.Release = "T";
		subject.ControlAgency = "2";
		//Test Parameters
		subject.Version = version;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredRelease(string release, bool isValidExpected)
	{
		var subject = new C709_MessageIdentifier();
		//Required fields
		subject.MessageTypeIdentifier = "o";
		subject.Version = "U";
		subject.ControlAgency = "2";
		//Test Parameters
		subject.Release = release;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredControlAgency(string controlAgency, bool isValidExpected)
	{
		var subject = new C709_MessageIdentifier();
		//Required fields
		subject.MessageTypeIdentifier = "o";
		subject.Version = "U";
		subject.Release = "T";
		//Test Parameters
		subject.ControlAgency = controlAgency;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
