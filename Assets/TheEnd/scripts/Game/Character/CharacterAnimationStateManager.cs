using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace TheEnd
{
    public enum CharacterAnimationState { None, Walk_Front, Stand_Front, Walk_Left, Stand_Left, Walk_Right, Stand_Right, Walk_Back, Stand_Back };

    public class Constant
    {
        public static float th = Mathf.Sin(22.5f * Mathf.PI / 180);
    }
    
    public class CharacterAnimationStateManager :Singleton<CharacterAnimationStateManager>
    {
        

         Dictionary<CharacterAnimationState, string> characterStateDict;

        public string getAnimationStateString(CharacterAnimationState state)
        {
            if(characterStateDict!=null)
            {
                if(characterStateDict.ContainsKey(state))
                return characterStateDict[state];
                else 
                return null;    
            }
            else
            return null;
            
        }
        // Use this for initialization
        void Awake()
        {
            characterStateDict = new Dictionary<CharacterAnimationState, string>();
            characterStateDict.Add(CharacterAnimationState.Stand_Back, "stand_back");
            characterStateDict.Add(CharacterAnimationState.Stand_Front, "stand_front");
            characterStateDict.Add(CharacterAnimationState.Stand_Left, "stand_left");
            characterStateDict.Add(CharacterAnimationState.Stand_Right, "stand_right");
            characterStateDict.Add(CharacterAnimationState.Walk_Back, "walk_back");
            characterStateDict.Add(CharacterAnimationState.Walk_Left, "walk_left");
            characterStateDict.Add(CharacterAnimationState.Walk_Front, "walk_front");
            characterStateDict.Add(CharacterAnimationState.Walk_Right, "walk_right");
        }


    }
}
