namespace Leptonica
{
    /// <summary>
    /// Flags for describing limited character sets
    /// </summary>
    public enum FlagsForDescribingLimitedCharacterSets
    {
        /// <summary>
        /// character set type is not specified  
        /// </summary>
        L_UNKNOWN = 0,
        /// <summary>
        /// 10 digits 
        /// </summary>
        L_ARABIC_NUMERALS = 1,
        /// <summary>
        /// 7 lower-case letters (i,v,x,l,c,d,m) 
        /// </summary>
        L_LC_ROMAN_NUMERALS = 2,
        /// <summary>
        /// 7 upper-case letters (I,V,X,L,C,D,M)
        /// </summary>
        L_UC_ROMAN_NUMERALS = 3,
        /// <summary>
        /// 26 lower-case letters
        /// </summary>
        L_LC_ALPHA = 4,
        /// <summary>
        /// 26 upper-case letters     
        /// </summary>
        L_UC_ALPHA = 5
    }
}
