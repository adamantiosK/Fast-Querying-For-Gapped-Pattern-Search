namespace FSGPM.Helper
{
    public static class GapCreatorHelper
    {
        public static string CreateGap(List<char> chars, int count, List<string> excludePatterns, bool IsPattern = false)
        {
            Random random = new Random();

            char[] gapChars = new char[count];

            for (int i = 0; i < count; i++)
            {
                int randomIndex = random.Next(chars.Count);
                gapChars[i] = chars[randomIndex];
            }

            string gap = new string(gapChars);

            while (excludePatterns.Any(pattern => gap.Contains(pattern)) || (!IsPattern && CheckPrefixesAndSuffixes(gap, excludePatterns)) || gap.Length < count)
            {
                foreach (string pattern in excludePatterns)
                {
                    if (gap.Contains(pattern))
                    {
                        gap = gap.Replace(pattern, "");
                    }
                }

                if (gap.Length == 0)
                {
                    gapChars = new char[count];

                    for (int i = 0; i < count; i++)
                    {
                        int randomIndex = random.Next(chars.Count);
                        gapChars[i] = chars[randomIndex];
                    }

                    gap = new string(gapChars);
                }
                else if (gap.Length < count)
                {
                    int remaining = count - gap.Length;
                    char[] remainingChars = new char[remaining];

                    for (int i = 0; i < remaining; i++)
                    {
                        int randomIndex = random.Next(chars.Count);
                        remainingChars[i] = chars[randomIndex];
                    }

                    gap += new string(remainingChars);
                }

                if (!IsPattern && CheckPrefixesAndSuffixes(gap, excludePatterns))
                {
                    if(gap.Length > excludePatterns[0].Length) {
                        gap = gap.Substring(excludePatterns[0].Length - 1, gap.Length - (excludePatterns[0].Length - 1));
                    }
                    else
                    {
                        gap = string.Empty;
                    }
                }

            }

            return gap;
        }

        private static bool CheckPrefixesAndSuffixes(string gap, List<string> excludePatterns)
        {
            foreach (string pattern in excludePatterns)
            {
                for (int i = 1; i < pattern.Length; i++)
                {
                    string prefix = pattern.Substring(0, i);
                    string suffix = pattern.Substring(pattern.Length - i);

                    if (gap.StartsWith(suffix) || gap.EndsWith(prefix))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

    }
}
