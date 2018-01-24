namespace Leptonica
{
    /// <summary>
    /// Arithmetic and logical operator flags
    /// </summary>
    public enum ArithmeticAndLogicalOperatorFlags
    {
        L_ARITH_ADD = 1,
        L_ARITH_SUBTRACT = 2,
        /// <summary>
        /// on numas only
        /// </summary>
        L_ARITH_MULTIPLY = 3,
        /// <summary>
        /// on numas only 
        /// </summary>
        L_ARITH_DIVIDE = 4,
        /// <summary>
        /// on numas only
        /// </summary>
        L_UNION = 5,
        /// <summary>
        /// on numas only
        /// </summary>
        L_INTERSECTION = 6,
        /// <summary>
        /// on numas only
        /// </summary>
        L_SUBTRACTION = 7,
        /// <summary>
        /// on numas only
        /// </summary>
        L_EXCLUSIVE_OR = 8
    }
}
