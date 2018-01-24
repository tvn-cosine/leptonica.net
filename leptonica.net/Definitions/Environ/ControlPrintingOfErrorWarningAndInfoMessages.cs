namespace Leptonica 
{ 
    /// <summary>
    /// Control printing of error, warning and info messages
    /// </summary>
    enum ControlPrintingOfErrorWarningAndInfoMessages
    {
        /// <summary>
        /// Get the severity from the environment
        /// </summary>
        L_SEVERITY_EXTERNAL = 0,
        /// <summary>
        /// Lowest severity: print all messages
        /// </summary>
        L_SEVERITY_ALL = 1,
        /// <summary>
        /// Print debugging and higher messages 
        /// </summary>
        L_SEVERITY_DEBUG = 2,
        /// <summary>
        /// Print informational and higher messages
        /// </summary>
        L_SEVERITY_INFO = 3,
        /// <summary>
        /// Print warning and higher messages
        /// </summary>
        L_SEVERITY_WARNING = 4,
        /// <summary>
        /// Print error and higher messages  
        /// </summary>
        L_SEVERITY_ERROR = 5,
        /// <summary>
        /// Highest severity: print no messages 
        /// </summary>
        L_SEVERITY_NONE = 6    
    }
}
