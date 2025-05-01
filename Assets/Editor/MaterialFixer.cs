using UnityEngine;
using UnityEditor;

public class MaterialFixer
{
    [MenuItem("Tools/Fix Pink Materials")]
    static void FixPinkMaterials()
    {
        string[] guids = AssetDatabase.FindAssets("t:Material");
        int count = 0;

        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            Debug.Log("***path Fixed material: " + path);
            Material mat = AssetDatabase.LoadAssetAtPath<Material>(path);

            if (mat != null && mat.shader.name == "Hidden/InternalErrorShader")
            {
                mat.shader = Shader.Find("Standard");
                Debug.Log("Fixed material: " + mat.name);
                count++;
            }
        }

        Debug.Log(" Reparados: " + count + " materiales rosas.");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}
