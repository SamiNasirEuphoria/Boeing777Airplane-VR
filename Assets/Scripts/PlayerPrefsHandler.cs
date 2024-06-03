using UnityEngine;
public class PlayerPrefsHandler 
{
    public static string CutScene = "CutSceneCheck";
    public static string cutScene
    {
        get
        {
            return PlayerPrefs.GetString(CutScene);
        }
        set
        {
            PlayerPrefs.SetString(CutScene, value);
        }
    }
    public static string cutSceneFlag = "CutSceneFlag";
    public static int CutSceneFlag
    {
        get
        {
            return PlayerPrefs.GetInt(cutSceneFlag);
        }
        set
        {
            PlayerPrefs.SetInt(cutSceneFlag, value);
        }
    }
}
