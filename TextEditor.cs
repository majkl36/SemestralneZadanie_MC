using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace SemestralneZadanie_MC
{
    class TextEditor
    {
        private readonly string _data;

        public TextEditor(string vstupnySubor)
        {
            _data = NacitajSubor(vstupnySubor);

        }
        private string NacitajSubor(string openFileDialogFileName)
        {
            string obsahSuboru = File.ReadAllText(openFileDialogFileName);
            return obsahSuboru;
        }
        public string Data //prvá skúška použitia getteru
        {
            get { return _data; } }
    }
}
