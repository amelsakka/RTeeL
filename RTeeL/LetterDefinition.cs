namespace RTeeL {
    internal class LetterDefinition {
        internal LetterDefinition(char id, char first, char mid, char final, char isolated, bool connectprevious = false, bool connectnext = false, LetterDefinition lamalef = null) {
            Id = id;
            First = first;
            Mid = mid;
            Final = final;
            Isolated = isolated;
            ConnectToPrevious = connectprevious;
            ConnectToNext = connectnext;
            LamAlef = lamalef;
        }

        public char Id { get; private set; }

        public char First { get; private set; }

        public char Mid { get; private set; }

        public char Final { get; private set; }

        public char Isolated { get; private set; }

        public bool ConnectToPrevious { get; private set; }

        public bool ConnectToNext { get; private set; }

        public LetterDefinition LamAlef { get; private set; }
    }
}