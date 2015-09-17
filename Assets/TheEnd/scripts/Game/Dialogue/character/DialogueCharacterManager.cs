using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace TheEnd
{
    public enum MainCharacterEnum { Moshiue};

    public class DialogueCharacterManager : MonoBehaviour
    {
        public static DialogueCharacterManager instance;
        
        public DialogueCharacter moshiue;
        Dictionary<MainCharacterEnum,DialogueCharacter> charDict;
        void Awake()
        {
            instance = this;
            charDict = new Dictionary<MainCharacterEnum, DialogueCharacter>();
            charDict.Add(MainCharacterEnum.Moshiue, moshiue);
        }
        public DialogueCharacter getCharacter(MainCharacterEnum ch)
        {
            return charDict[ch];
        }

    }
}