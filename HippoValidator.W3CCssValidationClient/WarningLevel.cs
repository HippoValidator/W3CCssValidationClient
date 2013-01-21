namespace HippoValidator.W3CCSSValidationClient
{
    /// <summary>
    /// This parameter is useful to tune the verbosity of the CSS Validator. Indeed, The validator can give you two types of messages: errors and warnings. Errors are given when the checked CSS does not respect the CSS recommendation. Warnings are different from errors since they do not state a problem regarding the specification. They are here to warn (!) the CSS developper that some points might be dangerous and could lead to a strange behaviour on some user agents.
    ///
    /// A typical warning concerns font-family: if you do not provide a generic font, you will get a warning saying that you should add one at the end of the rule, otherwise a user agent that doesn't know any of the other fonts will switch to it's default one, which may result in strange display.
    /// </summary>
    public enum WarningLevel
    {
        /// <summary>
        /// No warnings.
        /// </summary>
        No,
        /// <summary>
        /// Less warnings.
        /// </summary>
        Zero,
        /// <summary>
        /// More warnings.
        /// </summary>
        One,
        /// <summary>
        /// Even more warnings.
        /// </summary>
        Two,
    }
}