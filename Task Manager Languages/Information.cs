using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Localization.Languages;

/// <summary>
/// A localization system for supporting multiple languages
/// </summary>
namespace TaskManager.Localization
{
    public class Information
    {
        public static Information Languages;
        static Information()
        {
            Information.Languages = new Information();
        }

        private Dictionary<string, ILanguage> languages;
        private string[] supported;
        private Information()
        {
            this.languages = new Dictionary<string, ILanguage>();
            this.languages.Add("en-US", new English_US());
            this.languages.Add("es", new Spanish());

            this.supported = new string[this.languages.Count];
            int i = 0;
            foreach (string key in this.languages.Keys)
                this.supported[i++] = key;
        }
        public readonly string DefaultLanguageName = "en-US";
        public ILanguage Default
        {
            get
            {
                return this.languages[DefaultLanguageName];
            }
        }
        public ILanguage this[string key]
        {
            get
            {
                ILanguage lang = this.languages[DefaultLanguageName];
                if (this.languages.ContainsKey(key))
                    lang = this.languages[key];
                return lang;
            }
        }
        public string[] SupportedLanguages
        {
            get
            {
                return this.supported;
            }
        }
    }
}