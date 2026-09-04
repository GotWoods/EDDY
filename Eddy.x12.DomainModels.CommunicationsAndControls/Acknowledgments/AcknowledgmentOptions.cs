using System;

namespace Eddy.x12.DomainModels.CommunicationsAndControls.Acknowledgments
{
    /// <summary>
    /// Controls how <see cref="FunctionalAcknowledgmentBuilder"/> and <see cref="ImplementationAcknowledgmentBuilder"/>
    /// build the ISA/GS/ST envelope and the acceptance decisions of the 997/999 they generate. Every property has a
    /// sensible default derived from the document being acknowledged, so callers only need to set what they want to
    /// override.
    /// </summary>
    public class AcknowledgmentOptions
    {
        /// <summary>ISA06/GS02 of the generated acknowledgment. Defaults to the input's ISA08 (the receiver becomes the sender).</summary>
        public string SenderId { get; set; }

        /// <summary>ISA05 of the generated acknowledgment. Defaults to the input's ISA07.</summary>
        public string SenderQualifier { get; set; }

        /// <summary>ISA08/GS03 of the generated acknowledgment. Defaults to the input's ISA06 (the sender becomes the receiver).</summary>
        public string ReceiverId { get; set; }

        /// <summary>ISA07 of the generated acknowledgment. Defaults to the input's ISA05.</summary>
        public string ReceiverQualifier { get; set; }

        /// <summary>
        /// ISA13 of the generated interchange. Defaults to the same control number as the input interchange being
        /// acknowledged, since the caller is free to supply their own outbound numbering by setting this.
        /// </summary>
        public int? InterchangeControlNumber { get; set; }

        /// <summary>
        /// GS06 of the generated functional group(s). When the input has a single functional group this is used as-is
        /// (defaulting to that group's own GS06). When the input has several functional groups this is treated as a
        /// starting value that increments by one per generated group; the default keeps each generated group's own
        /// input GS06.
        /// </summary>
        public int? GroupControlNumber { get; set; }

        /// <summary>
        /// ST02 of the first generated transaction set; subsequent transaction sets (one per acknowledged functional
        /// group) increment from here, preserving the string's width (e.g. "0001", "0002", ...).
        /// </summary>
        public string TransactionSetControlNumber { get; set; } = "0001";

        /// <summary>Supplies the current date/time used for ISA9/10 and GS04/05. Defaults to <see cref="DateTime.Now"/>.</summary>
        public Func<DateTime> Clock { get; set; } = () => DateTime.Now;

        /// <summary>ISA15 of the generated interchange. Defaults to the input's own ISA15.</summary>
        public string UsageIndicator { get; set; }

        /// <summary>
        /// When true (the default), a transaction set whose only problems are data-element-level issues (AK3 segment
        /// syntax error code 8) is reported as accepted with errors noted (AK501/IK501 = "E"). When false, such a
        /// transaction set is rejected (AK501/IK501 = "R") instead. Transaction sets with a recognized structural
        /// problem (an unrecognized or unexpected segment, or an SE count/control-number mismatch) are always
        /// rejected regardless of this setting.
        /// </summary>
        public bool AcceptWithErrors { get; set; } = true;

        /// <summary>
        /// When true (the default), AK3/AK4 (or IK3/IK4 for a 999) detail loops are emitted for every segment-level
        /// problem found. When false, those detail loops are omitted; AK5/AK9 (or IK5/AK9) still reflect the errors.
        /// </summary>
        public bool IncludeAK3AK4 { get; set; } = true;
    }
}
