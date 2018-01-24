namespace Leptonica
{
    /// <summary>
    /// Flags for replacing invalid boxes
    /// </summary>
    public enum FlagsForReplacingInvalidBoxes
    {
        /// <summary>
        /// consider all boxes in the sequence
        /// </summary>
        L_USE_ALL_BOXES = 1,
        /// <summary>
        /// consider boxes with the same parity
        /// </summary>
        L_USE_SAME_PARITY_BOXES = 2
    }
}
