using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace SemestralneZadanie_MC
{
    class TextEditor
    {
        private string _data;
        public string Data
        {
            get
            {
                return _data +
                    "\r\n\r\n-----------------------------\r\n" +
                    "Počet vykonaných zmien: " +
                    _changesCount;
            }
        }

        private string _changes;
        public string Changes
        { get { return _changes; } }

        private int _changesCount = 0;

        public TextEditor(string inputFile)
        {
            try
            {
                _data = NacitajSubor(inputFile);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Vstupný súbor nenájdený!\n");
                throw;
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Prístup do súboru je zamietnutý!\n");
            }
            catch (IOException)
            {
                Console.WriteLine("Chyba pri práci so súborom!\n");
                throw;
            }            
            catch (Exception)
            {
                Console.WriteLine("Nastala neočakávaná chyba!");
                throw;
            }            
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
            _changesCount++;
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
        public void toUppercase()
        {
            ArchiveChange("Zmena malých písmen na veľké:");
            StringBuilder changedString = new StringBuilder();
            char origChar, changedChar;
            for (int i = 0; i < _data.Length; i++)
            {
                origChar = _data[i];
                if (char.IsLower(origChar) && char.IsLetter(origChar))
                {
                    changedChar = char.ToUpper(_data[i]);
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
        public void sentencesStartsToUpper()
        {
            ArchiveChange("Prvé písmeno vety na veľké:");
            string changed;
            changed = Regex.Replace(_data.ToLower(), @"((?<=^\s*)\p{Ll}|(?<=\.\s+)\p{Ll})", m => m.Value.ToUpper());
            for (int i = 0; i < _data.Length; i++)
            {
                if (_data[i] != changed[i])
                    ArchiveChange(i, _data[i], changed[i]);
            }
            _data = changed;
        }
        public void wordsStartsToUpper()
        {
            ArchiveChange("Prvé písmeno slova na veľké:");
            string changed;
            changed = Regex.Replace(_data.ToLower(), @"\b\p{Ll}", m => m.Value.ToUpper());
            for (int i = 0; i < _data.Length; i++)
            {
                if (_data[i] != changed[i])
                    ArchiveChange(i, _data[i], changed[i]);
            }
            _data = changed;
        }
        public void removeDiacritic()
        {
            ArchiveChange("Odstránenie diakritiky:");
            string normalizedString = _data.Normalize(NormalizationForm.FormD);
            string changed = "";
            foreach (char c in normalizedString)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    changed += c;
            }
            for (int i = 0; i < _data.Length; i++)
            {
                if (_data[i] != changed[i])
                    ArchiveChange(i, _data[i], changed[i]);
            }
            _data = changed;
        }
        //end of class
    }
    //end of namespace
}

