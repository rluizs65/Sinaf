﻿using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Base.Core.Util
{
    public class Soundex : ISoundex
    {
        private int _maxSoundexCodeLength = 4;

        public Soundex(int maxSoundexCodeLength)
        {
            _maxSoundexCodeLength = maxSoundexCodeLength;
        }

        public string GetToken(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                throw new ArgumentNullException("word");
            }

            var soundexCode = new StringBuilder();

            word = Regex.Replace(word.ToUpper(), @"[^\w\s]", string.Empty);

            if (string.IsNullOrEmpty(word))
            {
                return string.Empty.PadRight(_maxSoundexCodeLength, '0');
            }

            soundexCode.Append(word.First());
            ApplySoundexRules(word, soundexCode);

            return PadAndFormatReturnCode(soundexCode, _maxSoundexCodeLength);
        }

        private static string PadAndFormatReturnCode(StringBuilder soundexCode, int maxSoundexCodeLength)
        {
            var returnValue = soundexCode.Replace("0", string.Empty).ToString();
            returnValue = returnValue.PadRight(maxSoundexCodeLength, '0');
            returnValue = returnValue.Substring(0, maxSoundexCodeLength);
            return returnValue;
        }

        private void ApplySoundexRules(string word, StringBuilder soundexCode)
        {
            var previousWasHorW = false;

            for (var i = 1; i < word.Length; i++)
            {
                var numberCharForCurrentLetter = GetCharNumberForLetter(word[i]);

                if (i == 1 && numberCharForCurrentLetter == GetCharNumberForLetter(soundexCode[0]))
                    continue;

                if (soundexCode.Length > 2 && previousWasHorW && numberCharForCurrentLetter == soundexCode[soundexCode.Length - 2])
                    continue;

                if (soundexCode.Length > 0 && numberCharForCurrentLetter == soundexCode[soundexCode.Length - 1])
                    continue;

                soundexCode.Append(numberCharForCurrentLetter);

                previousWasHorW = "HW".Contains(word[i]);
            }
        }

        private char GetCharNumberForLetter(char letter)
        {
            if ("BFPV".Contains(letter))
                return '1';

            if ("CGJKQSXZ".Contains(letter))
                return '2';

            if ("DT".Contains(letter))
                return '3';

            if ('L' == letter)
                return '4';

            if ("MN".Contains(letter))
                return '5';

            return 'R' == letter ? '6' : '0';
        }
    }
}