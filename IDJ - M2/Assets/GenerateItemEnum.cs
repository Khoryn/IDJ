#if UNITY_EDITOR
using UnityEditor;
using System.IO;

public class GenerateItemEnum
{
    [MenuItem("Tools/GenerateEnum")]
    public static void Go()
    {
        string enumName = "MyEnum";
        string[] enumEntries = { "Armor", "Weapon", "Food" };
        string filePathAndName = "Assets/" + enumName + ".cs";

        using (StreamWriter streamWriter = new StreamWriter(filePathAndName))
        {
            streamWriter.WriteLine("public enum " + enumName);
            streamWriter.WriteLine("{");
            for (int i = 0; i < enumEntries.Length; i++)
            {
                streamWriter.WriteLine("\t" + enumEntries[i] + ",");
            }
            streamWriter.WriteLine("}");
        }
        AssetDatabase.Refresh();
    }
}
#endif
