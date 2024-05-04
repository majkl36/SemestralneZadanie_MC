using System.IO;
using System.Text;


namespace SemestralneZadanie_MC
{
    class TextEditor
    {
        private string _data;
        public string Data
        { get { return _data; } }

        private string _changes;
        public string Changes
        { get { return _changes; } }

        public TextEditor(string inputFile)
        {
            _data = NacitajSubor(inputFile);
        }
        private string NacitajSubor(string openFileDialogFileName)
        {
            string fileContent = File.ReadAllText(openFileDialogFileName);
            return fileContent;
        }
        private void ArchiveChange(string opName)
        {
            if (_changes == null)
            { _changes += opName + "\r\n\r\n"; }
            else
            { _changes += "\r\n" + opName + "\r\n\r\n"; }
        }
        private void ArchiveChange(int pos, char originalLetter, char changedLetter)
        {
            _changes += "[" + pos + "]: " + originalLetter + " -> " + changedLetter + "\r\n";
        }
        public char toLowercase(char inChar, int pos)
        {
            char outChar = char.ToLower(inChar);
            ArchiveChange(pos, outChar, inChar);
            return char.ToLower(outChar);
        }
        public void toLowercase()
        {
            ArchiveChange("Zmena veľkých písmen na malé:");
            StringBuilder changedString = new StringBuilder();
            char origChar, changedChar;
            for (int i = 0; i < _data.Length; i++)
            {
                origChar = _data[i];
                if (!char.IsLower(origChar) && char.IsLetter(origChar))
                {
                    changedChar = char.ToLower(_data[i]);
                    changedString.Append(changedChar);
                    ArchiveChange(i, origChar, changedChar);
                }
                else
                {
                    changedString.Append(origChar);
                }
            }
            _data = changedString.ToString();
        }
    }
}

