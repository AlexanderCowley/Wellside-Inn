using System;
using UnityEngine;

namespace wellside
{
    public class TextFileDataGeneration : MonoBehaviour
    {
        [SerializeField] TextAsset _textData;
        string[] _textLines;

        public string[] TextData { get => _textLines; }

        private void OnValidate()
        {
            _textLines = SeperateDataString(_textData);
        }

        string[] SeperateDataString(TextAsset data)
        {
            string[] dataSplit = _textData ? _textData.text.Split
                (new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries)
                : null;

            return dataSplit;
        }

        /// <summary>
        /// For text file information - Neat alternative for later
        /// </summary>
        /*void InitAllExamineData(string[] data)
        {
            //Assign data based on position in array

            _actionTitle = data[0];
            for (int i = 0; i < data.Length; i++)
            {
                data[i].Split(',');
                print(data[i]);
            }
        }*/
    }
}