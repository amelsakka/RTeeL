namespace RTeeL {
    using System.Linq;

    internal static class LetterDefinitions {
        private static readonly LetterDefinition[] ArabicDefinitions;

        static LetterDefinitions() {
            #region ArabicDefinitions

            ArabicDefinitions = new[] {
                                          new LetterDefinition((char)0x0621, (char)0xFE80, (char)0xFE80, (char)0xFE80, (char)0xFE80), // Arabic
                                          new LetterDefinition((char)0x0622, (char)0xFE81, (char)0xFE82, (char)0xFE82, (char)0xFE81, true, false,
                                                               new LetterDefinition((char)0x0644, (char)0xFEF5, (char)0xFEF6, (char)0xFEF6, (char)0xFEF5, true)), // Arabic
                                          new LetterDefinition((char)0x0623, (char)0xFE83, (char)0xFE84, (char)0xFE84, (char)0xFE83, true, false,
                                                               new LetterDefinition((char)0x0644, (char)0xFEF7, (char)0xFEF8, (char)0xFEF8, (char)0xFEF7, true)), // Arabic
                                          new LetterDefinition((char)0x0624, (char)0xFE85, (char)0xFE86, (char)0xFE86, (char)0xFE85, true), // Arabic
                                          new LetterDefinition((char)0x0625, (char)0xFE87, (char)0xFE88, (char)0xFE88, (char)0xFE87, true, false,
                                                               new LetterDefinition((char)0x0644, (char)0xFEF9, (char)0xFEFA, (char)0xFEFA, (char)0xFEF9, true)), // Arabic
                                          new LetterDefinition((char)0x0626, (char)0xFE8B, (char)0xFE8C, (char)0xFE8A, (char)0xFE89, true, true), // Arabic
                                          new LetterDefinition((char)0x0627, (char)0xFE8D, (char)0xFE8E, (char)0xFE8E, (char)0xFE8D, true, false,
                                                               new LetterDefinition((char)0x0644, (char)0xFEFB, (char)0xFEFC, (char)0xFEFC, (char)0xFEFB, true)), // Arabic
                                          new LetterDefinition((char)0x0628, (char)0xFE91, (char)0xFE92, (char)0xFE90, (char)0xFE8F, true, true), // Arabic
                                          new LetterDefinition((char)0x0629, (char)0x0000, (char)0x0000, (char)0xFE94, (char)0xFE93, true), // Arabic
                                          new LetterDefinition((char)0x062A, (char)0xFE97, (char)0xFE98, (char)0xFE96, (char)0xFE95, true, true), // Arabic
                                          new LetterDefinition((char)0x062B, (char)0xFE9B, (char)0xFE9C, (char)0xFE9A, (char)0xFE99, true, true), // Arabic
                                          new LetterDefinition((char)0x062C, (char)0xFE9F, (char)0xFEA0, (char)0xFE9E, (char)0xFE9D, true, true), // Arabic
                                          new LetterDefinition((char)0x062D, (char)0xFEA3, (char)0xFEA4, (char)0xFEA2, (char)0xFEA1, true, true), // Arabic
                                          new LetterDefinition((char)0x062E, (char)0xFEA7, (char)0xFEA8, (char)0xFEA6, (char)0xFEA5, true, true), // Arabic
                                          new LetterDefinition((char)0x062F, (char)0xFEA9, (char)0xFEAA, (char)0xFEAA, (char)0xFEA9, true), // Arabic
                                          new LetterDefinition((char)0x0630, (char)0xFEAB, (char)0xFEAC, (char)0xFEAC, (char)0xFEAB, true), // Arabic
                                          new LetterDefinition((char)0x0631, (char)0xFEAD, (char)0xFEAE, (char)0xFEAE, (char)0xFEAD, true), // Arabic
                                          new LetterDefinition((char)0x0632, (char)0xFEAF, (char)0xFEB0, (char)0xFEB0, (char)0xFEAF, true), // Arabic
                                          new LetterDefinition((char)0x0633, (char)0xFEB3, (char)0xFEB4, (char)0xFEB2, (char)0xFEB1, true, true), // Arabic
                                          new LetterDefinition((char)0x0634, (char)0xFEB7, (char)0xFEB8, (char)0xFEB6, (char)0xFEB5, true, true), // Arabic
                                          new LetterDefinition((char)0x0635, (char)0xFEBB, (char)0xFEBC, (char)0xFEBA, (char)0xFEB9, true, true), // Arabic
                                          new LetterDefinition((char)0x0636, (char)0xFEBF, (char)0xFEC0, (char)0xFEBE, (char)0xFEBD, true, true), // Arabic
                                          new LetterDefinition((char)0x0637, (char)0xFEC3, (char)0xFEC4, (char)0xFEC2, (char)0xFEC1, true, true), // Arabic
                                          new LetterDefinition((char)0x0638, (char)0xFEC7, (char)0xFEC8, (char)0xFEC6, (char)0xFEC5, true, true), // Arabic
                                          new LetterDefinition((char)0x0639, (char)0xFECB, (char)0xFECC, (char)0xFECA, (char)0xFEC9, true, true), // Arabic
                                          new LetterDefinition((char)0x063A, (char)0xFECF, (char)0xFED0, (char)0xFECE, (char)0xFECD, true, true), // Arabic
                                          new LetterDefinition((char)0x0640, (char)0x0640, (char)0x0640, (char)0x0640, (char)0x0640, true, true), // Arabic
                                          new LetterDefinition((char)0x0641, (char)0xFED3, (char)0xFED4, (char)0xFED2, (char)0xFED1, true, true), // Arabic
                                          new LetterDefinition((char)0x0642, (char)0xFED7, (char)0xFED8, (char)0xFED6, (char)0xFED5, true, true), // Arabic
                                          new LetterDefinition((char)0x0643, (char)0xFEDB, (char)0xFEDC, (char)0xFEDA, (char)0xFED9, true, true), // Arabic
                                          new LetterDefinition((char)0x0644, (char)0xFEDF, (char)0xFEE0, (char)0xFEDE, (char)0xFEDD, true, true), // Arabic
                                          new LetterDefinition((char)0x0645, (char)0xFEE3, (char)0xFEE4, (char)0xFEE2, (char)0xFEE1, true, true), // Arabic
                                          new LetterDefinition((char)0x0646, (char)0xFEE7, (char)0xFEE8, (char)0xFEE6, (char)0xFEE5, true, true), // Arabic
                                          new LetterDefinition((char)0x0647, (char)0xFEEB, (char)0xFEEC, (char)0xFEEA, (char)0xFEE9, true, true), // Arabic
                                          new LetterDefinition((char)0x0648, (char)0xFEED, (char)0xFEEE, (char)0xFEEE, (char)0xFEED, true), // Arabic
                                          new LetterDefinition((char)0x0649, (char)0xFEF3, (char)0xFEF4, (char)0xFEF0, (char)0xFEFF, true, true), // Arabic
                                          new LetterDefinition((char)0x064A, (char)0xFEF3, (char)0xFEF4, (char)0xFEF2, (char)0xFEF1, true, true), // Arabic
                                          new LetterDefinition((char)0x067E, (char)0xFB58, (char)0xFB59, (char)0xFB57, (char)0xFB56, true, true), // Farsi
                                          new LetterDefinition((char)0x0686, (char)0xFB7C, (char)0xFB7D, (char)0xFB7B, (char)0xFB7A, true, true), // Farsi
                                          new LetterDefinition((char)0x0698, (char)0xFB8A, (char)0xFB8B, (char)0xFB8B, (char)0xFB8A, true), // Farsi
                                          new LetterDefinition((char)0x06A9, (char)0xFB90, (char)0xFB91, (char)0xFB8F, (char)0xFB8E, true, true),
                                          // Farsi, Might not be 100% correct... 2 sources... 2 different values! >_<
                                          new LetterDefinition((char)0x06AF, (char)0xFB94, (char)0xFB95, (char)0xFB93, (char)0xFB92, true, true), // Farsi

                                          new LetterDefinition((char)0x06CC, (char)0xFBFE, (char)0xFBFF, (char)0xFBFD, (char)0xFBFC, true, true) // Farsi
                                      };

            #endregion
        }

        internal static LetterDefinition GetArabicDefinition(char id) { return ArabicDefinitions.FirstOrDefault(ld => ld.Id == id); }
    }
}