namespace Eddy.Edifact.Tests;

public class EdifactDocumentTests
{
    private readonly string _sample;

    public EdifactDocumentTests()
    {
        _sample = @"UNB+UNOA:1+123456789:14+987654321:14+230815:1200+987654++++++1'
UNH+1+APERAK:D:96A:UN'
BGM+16+123456+9'
DTM+137:20230815:102'
RFF+ACW:987654'
NAD+MS+123456789:160:ZZZ'
NAD+MR+987654321:160:ZZZ'

ERC+12:INTERCHANGE ERROR'
FTX+AAI+++Message rejected due to incorrect syntax in segment 5'
FTX+AAI+++Segment UNB is missing mandatory element S003'
FTX+AAI+++Segment UNT does not match segment count'

UNT+11+1'
UNZ+1+987654'
";
    }

    [Fact]
    public void ParseBasicDocument()
    {
        var doc = EdiFactDocument.Parse(_sample);
        VerifyDocument(doc);
        Assert.Equal("UNB+UNOA:1+123456789:14+987654321:14+230815:1200+987654++++++1",
            doc.InterchangeControlHeader.Source.RawText);
        Assert.Equal(1, doc.InterchangeControlHeader.Source.LineNumber); //no UNA - UNB is line 1
    }

    [Fact]
    public void ParseBasicDocumentWithDefaultUNAHeader()
    {
        var withUna = "UNA:+.? '" + _sample;
        var doc = EdiFactDocument.Parse(withUna);
        VerifyDocument(doc);
        Assert.NotNull(doc.ServiceStringAdvice);
        Assert.Equal(1, doc.ServiceStringAdvice.Source.LineNumber);
        Assert.Equal(2, doc.InterchangeControlHeader.Source.LineNumber); //UNA present - UNB is line 2
    }

    [Fact]
    public void ParseBasicDocumentWithUniqueUNAHeader()
    {
        var withUna = "UNA|!.? ~" + _sample
            .Replace(":", "|")
            .Replace("+", "!")
            .Replace("'", "~");
        var doc = EdiFactDocument.Parse(withUna);
        VerifyDocument(doc);
    }

    private void VerifyDocument(EdiFactDocument doc)
    {
        Assert.True(doc.IsValid);

        Assert.Equal("UNOA", doc.InterchangeControlHeader.SyntaxIdentifier.SyntaxIdentifier);
        Assert.Equal("1", doc.InterchangeControlHeader.SyntaxIdentifier.SyntaxVersionNumber);
        Assert.Equal("123456789", doc.InterchangeControlHeader.InterchangeSender.InterchangeSenderIdentification);
        Assert.Equal("14", doc.InterchangeControlHeader.InterchangeSender.IdentificationCodeQualifier);
        Assert.Equal("987654321", doc.InterchangeControlHeader.InterchangeRecipient.InterchangeRecipientIdentification);
        Assert.Equal("14", doc.InterchangeControlHeader.InterchangeRecipient.IdentificationCodeQualifier);

        Assert.Equal("230815", doc.InterchangeControlHeader.DateAndTimeOfPreparation.Date);
        Assert.Equal("1200", doc.InterchangeControlHeader.DateAndTimeOfPreparation.Time);

        Assert.Equal("987654", doc.InterchangeControlHeader.InterchangeControlReference);
        Assert.Equal("1", doc.InterchangeControlHeader.TestIndicator);

        Assert.Single(doc.FunctionalGroups);
        Assert.Single(doc.FunctionalGroups[0].Messages);
        Assert.Equal(9, doc.FunctionalGroups[0].Messages[0].Segments.Count);

        Assert.Single(doc.Interchanges);
        var interchange = doc.Interchanges[0];
        Assert.Same(doc.InterchangeControlHeader, interchange.Header);
        Assert.NotNull(interchange.Trailer);
        Assert.Equal("987654", interchange.Trailer.InterchangeControlReference);
        Assert.Null(doc.FunctionalGroups[0].Header); //no UNG in the sample - implicit group

        var message = doc.FunctionalGroups[0].Messages[0];
        Assert.NotNull(message.Header);
        Assert.Equal("APERAK", message.MessageType);
        Assert.Equal("D96A", message.Version);
        Assert.NotNull(message.Trailer);
        Assert.Equal("1", message.Trailer.MessageReferenceNumber);

        Assert.NotNull(interchange.Header.Source);
    }
}