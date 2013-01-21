using System;

namespace HippoValidator.W3CCSSValidationClient
{
    public interface IW3CCssValidator
    {
        ValidationResult Validate(Uri url, UserMedium usermedium = UserMedium.All, Profile profile = Profile.Css2,
                                  Language language = Language.English, WarningLevel warningLevel = WarningLevel.Two,
                                  bool vextwarning = false);
    }
}