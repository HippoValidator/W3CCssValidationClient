namespace HippoValidator.W3CCSSValidationClient
{
    /// <summary>
    /// The CSS validator can check different CSS profiles. A profile lists all the features that an implementation on a particular platform is expected to implement. This definition is taken from the CSS site . The default choice corresponds to the current most used one: CSS 2.
    /// </summary>
    public enum Profile
    {
        /// <summary>
        /// CSS level 1.
        /// </summary>
        Css1,
        /// <summary>
        /// CSS level 2.
        /// </summary>
        Css2,
        /// <summary>
        /// CSS level 2.1.
        /// </summary>
        Css21,
        /// <summary>
        /// CSS level 3.
        /// </summary>
        Css3,
        /// <summary>
        /// SVG.
        /// </summary>
        Svg,
        /// <summary>
        /// SVG Basic.
        /// </summary>
        Svgbasic,
        /// <summary>
        /// SVG tiny.
        /// </summary>
        Svgtiny,
        /// <summary>
        /// Mobile.
        /// </summary>
        Mobile,
        /// <summary>
        /// ATSC TV profile.
        /// </summary>
        AtscTv,
        /// <summary>
        /// TV profile.
        /// </summary>
        Tv,
        /// <summary>
        /// No special profile.
        /// </summary>
        None,
    }
}