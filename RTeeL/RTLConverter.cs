namespace RTeeL {
    using System.Text;
    using System.Text.RegularExpressions;

    public static class RtlConverter {
        private const string ArabicFarsiRegex = @"([\u0600-\u06FF\(\)\[\]\{\}<>«»]+)";
        private const string Brackets = "()[]{}<>«»";

        public static string FixArabicAndFarsi(string input) {
            var sb = new StringBuilder();
            var firstLine = true;
            foreach(var line in Regex.Split(input, "\r\n")) {
                if(!firstLine)
                    sb.Append("\r\n");
                firstLine = false;
                var words = line.Split(' ');
                var firstWord = true;
                for(var i = words.Length - 1; i >= 0; i--) {
                    if(!firstWord)
                        sb.Append(" "); // It's a new word, make it appear that way also!
                    firstWord = false;
                    var split = Regex.Split(words[i], ArabicFarsiRegex);
                    for(var j = split.Length - 1; j >= 0; j--)
                        sb.Append(Regex.IsMatch(split[j], ArabicFarsiRegex) ? ConnectArabicAndFarsi(split[j]) : split[j]);
                }
            }
            return sb.ToString();
        }

        private static string ConnectArabicAndFarsi(string word) {
            var sb = new StringBuilder();
            for(var i = word.Length - 1; i >= 0; i--) {
                var bracketIndex = Brackets.IndexOf(word[i]); // Check if we're dealing with a bracket
                if(bracketIndex >= 0) {
                    sb.Append(Brackets[bracketIndex % 2 == 0 ? bracketIndex + 1 : bracketIndex - 1]); // Flip brackets
                    continue;
                }
                if(!IsArabic(word[i]))
                    sb.Append(word[i]); // Leave it alone
                else {
                    var ld = LetterDefinitions.GetArabicDefinition(word[i]);
                    if(ld == null) {
                        sb.Append(word[i]);
                        continue;
                    }
                    if(i == word.Length - 1 || !ld.ConnectToNext) {
                        if(i > 0 && ld.ConnectToPrevious) {
                            var prev = GetNextOrPrevious(word, i); // Get "Previous" (next)
                            if(prev == null) {
                                sb.Append(ld.Isolated);
                                continue;
                            }
                            var final = prev.ConnectToNext; // Check if Final or Isolated
                            if(ld.LamAlef != null && prev.Id == ld.LamAlef.Id) {
                                if(i > 1) {
                                    prev = GetNextOrPrevious(word, i - 1);
                                    final = prev != null && prev.ConnectToNext;
                                }
                                else
                                    final = false;
                                // if previous character(s) == tashkeel, then append and skip
                                if(i > 1 && IsTashkeel(word[i - 1])) {
                                    i--;
                                    sb.Append(word[i]);
                                }
                                if(i > 1 && IsTashkeel(word[i - 1])) {
                                    i--;
                                    sb.Append(word[i]);
                                }
                                // finally append Lam-Alef and skip next iteration (Lam of the Lam-Alef)
                                sb.Append(final ? ld.LamAlef.Final : ld.LamAlef.Isolated);
                                i--;
                                continue;
                            }
                            sb.Append(final ? ld.Final : ld.Isolated); // Not LamAlef
                        }
                        else
                            sb.Append(ld.Isolated); // It's Isolated...
                    }
                    else {
                        var next = GetNextOrPrevious(word, i, false); // Get "Next" (previous)
                        var isNextConnected = next != null && next.ConnectToPrevious;
                        if(i > 0) {
                            var prev = GetNextOrPrevious(word, i); // Get "Previous" (next)
                            if(prev != null && prev.ConnectToNext)
                                sb.Append(isNextConnected ? ld.Mid : ld.Final);
                            else
                                sb.Append(isNextConnected ? ld.First : ld.Isolated);
                        }
                        else
                            sb.Append(isNextConnected ? ld.First : ld.Isolated);
                    }
                }
            }
            return sb.Replace("\0", "").ToString(); // Strip any null characters, some might end up beeing null when they're not supposed to be there...
        }

        private static bool IsTashkeel(char c) { return c >= 0x0618 && c <= 0x061A || c >= 0x064B && c <= 0x065B; }

        private static bool IsArabic(char c) {
            return c >= 0x0621 && c <= 0x064A || c == 0x067E || c == 0x0686 || c == 0x0698 || c == 0x06A9 || c == 0x06AF || c == 0x06CC;
            /* 
               0x0621 to 0x064A                                  < Arabic
               0x067E, 0x0686, 0x0698, 0x06A9, 0x06AF and 0x06CC < Farsi 
            */
        }

        private static LetterDefinition GetNextOrPrevious(string word, int index, bool isPrevious = true) {
            var factor = isPrevious ? -1 : 1;
            var limit = isPrevious ? 0 : word.Length - 1;
            if(index != limit && IsTashkeel(word[index]))
                index += factor;
            if(index != limit && IsTashkeel(word[index]))
                index += factor;
            if(index != limit && IsTashkeel(word[index + factor]))
                index += factor;
            if(index != limit && IsTashkeel(word[index + factor]))
                index += factor;
            return index != limit ? LetterDefinitions.GetArabicDefinition(word[index + factor]) : null;
        }
    }
}