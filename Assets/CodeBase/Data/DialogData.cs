using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Data
{
    [CreateAssetMenu(fileName = "NewDialog", menuName = "DialogSystem/Dialog")]
    public class DialogData : ScriptableObject
    {
        public Sprite charImage;
        public string charName;

        [TextArea(3, 10)] public List<string> EnTexts;
        [TextArea(3, 10)] public List<string> RuTexts;

        public List<string> GetLocalizedDialog()
        {
            if (Application.systemLanguage == SystemLanguage.English)
            {
                return EnTexts;
            }
            return RuTexts;
        }
    }
}