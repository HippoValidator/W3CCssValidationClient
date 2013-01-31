using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace HippoValidator.W3CCSSValidationClient
{
    public class W3CCssValidator : IW3CCssValidator
    {
        readonly XNamespace _namespace = "http://www.w3.org/2005/07/css-validator";

        private const string ValidatorUrl = "http://jigsaw.w3.org/css-validator/validator";

        public ValidationResult Validate(Uri url, UserMedium usermedium = UserMedium.All, Profile profile = Profile.Css2, Language language = Language.English,
                                         WarningLevel warningLevel = WarningLevel.Two, bool vextwarning = false)
        {
            if (url == null)
            {
                throw new ArgumentException("url cannot be null");
            }

            var jigsawUrl =
                string.Format("{0}?uri={1}&profile={2}&usermedium={3}&warning={4}&lang={5}&vextwarning={6}&output=soap12",
                              ValidatorUrl, url, ToParam(profile), ToParam(usermedium), ToParam(warningLevel), ToParam(language), vextwarning);

            var document = XDocument.Load(jigsawUrl);

            return new ValidationResult
                {
                    Errors = ParseIssues(document, "errors", "errorlist", "error", Severity.Error),
                    Warnings = ParseIssues(document, "warnings", "warninglist", "warning", Severity.Warning),
                };
        }

        private List<ValidationIssue> ParseIssues(XContainer document, string rootName, string listName, string tagName, Severity severity)
        {
            var elements = from e in document.Descendants(_namespace + rootName) select e;
            var issues = new List<ValidationIssue>();

            foreach (var element in elements)
            {
                foreach (var list in element.Descendants(_namespace + listName))
                {
                    foreach (var errorElement in list.Descendants(_namespace + tagName))
                    {
                        var issue = new ValidationIssue { Severity = severity };

                        if (errorElement.Descendants(_namespace + "line").Any())
                            issue.Row = int.Parse(errorElement.Descendants(_namespace + "line").First().Value);
                        if (errorElement.Descendants(_namespace + "col").Any())
                            issue.Column = int.Parse(errorElement.Descendants(_namespace + "col").First().Value);
                        if (errorElement.Descendants(_namespace + "message").Any())
                        {
                            issue.Title = errorElement.Descendants(_namespace + "message").First().Value;
                            issue.MessageId = Encoding.UTF8.GetString(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(issue.Title)));
                        }
 
                        issues.Add(issue);
                    }
                }
            }

            return issues;
        }

        private string ToParam(Language warningLevel)
        {
            switch (warningLevel)
            {
                case Language.English:
                    return "en";
                case Language.French:
                    return "fr";
                case Language.Italian:
                    return "it";
                case Language.Korean:
                    return "ko";
                case Language.Japanese:
                    return "ja";
                case Language.Spanish:
                    return "es";
                case Language.Chinese:
                    return "zh-cn";
                case Language.Dutch:
                    return "nl";
                case Language.German:
                    return "de";
                case Language.Polish:
                    return "pl";
                default:
                    throw new ArgumentOutOfRangeException("warningLevel");
            }
        }

        private string ToParam(WarningLevel warningLevel)
        {
            switch (warningLevel)
            {
                case WarningLevel.No:
                    return "no";
                case WarningLevel.Zero:
                    return "0";
                case WarningLevel.One:
                    return "1";
                case WarningLevel.Two:
                    return "2";
                default:
                    throw new ArgumentOutOfRangeException("warningLevel");
            }
        }

        private string ToParam(UserMedium usermedium)
        {
            switch (usermedium)
            {
                case UserMedium.All:
                    return "all";
                case UserMedium.Braille:
                    return "braille";
                case UserMedium.Embossed:
                    return "embossed";
                case UserMedium.Handheld:
                    return "handheld";
                case UserMedium.Print:
                    return "print";
                case UserMedium.Projection:
                    return "projection";
                case UserMedium.Screen:
                    return "screen";
                case UserMedium.Speech:
                    return "speech";
                case UserMedium.Tty:
                    return "tty";
                case UserMedium.Tv:
                    return "tv";
                default:
                    throw new ArgumentOutOfRangeException("usermedium");
            }
        }

        private string ToParam(Profile profile)
        {
            switch (profile)
            {
                case Profile.Css1:
                    return "css1";
                case Profile.Css2:
                    return "css2";
                case Profile.Css21:
                    return "css21";
                case Profile.Css3:
                    return "css3";
                case Profile.Svg:
                    return "svg";
                case Profile.Svgbasic:
                    return "svgbasic";
                case Profile.Svgtiny:
                    return "svgtiny";
                case Profile.Mobile:
                    return "mobile";
                case Profile.AtscTv:
                    return "atsc-tv";
                case Profile.Tv:
                    return "tv";
                case Profile.None:
                    return "none";
                default:
                    throw new ArgumentOutOfRangeException("profile");
            }
        }
    }
}