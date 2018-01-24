namespace Leptonica 
{ 
    /// <summary>
    /// Constants for deciding when text block is divided into paragraphs
    /// </summary>
    public enum ConstantsForDecidingWhenTextBlockIsDividedIntoParagraphs
    {
        /// <summary>
        /// tab or space at beginning of line
        /// </summary>
        SPLIT_ON_LEADING_WHITE = 1,
        /// <summary>
        /// newline with optional white space
        /// </summary>
        SPLIT_ON_BLANK_LINE = 2,
        /// <summary>
        /// leading white space or newline
        /// </summary>
        SPLIT_ON_BOTH = 3      
    } 
}
