using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.IO; 

public class InteractionManager : Singleton<InteractionManager>
{
    
    private const string JsonFilePath = "GameData/ObjectData.json"; // JSON 文件路径


    private List<InteractiveObjectInfo> interactiveObjectInfos; // 用于存储 JSON 数据
    protected override void Awake()
    {
        base.Awake(); 
        LoadJson(GetJsonFilePath()); // 加载 JSON 文件
    }
    private string GetJsonFilePath()
    {
        return Path.Combine(Application.dataPath, JsonFilePath);
    }



    /// 加载JSON 文件
    private void LoadJson(string filePath)
    {
        if (File.Exists(filePath))
        {
            string jsonContent = File.ReadAllText(filePath);

            // 使用 JsonUtility 解析 JSON 文件
            Wrapper wrapper = JsonUtility.FromJson<Wrapper>(jsonContent);
            if (wrapper != null && wrapper.infos != null)
            {
                interactiveObjectInfos = wrapper.infos;
                Debug.Log("JSON data loaded successfully.");
            }
            else
            {
                Debug.LogError("Failed to parse JSON data.");
            }
        }
        else
        {
            Debug.LogError($"JSON file not found at {filePath}");
        }
    }

  
    /// 根据 Io_name 获取对象信息

    private InteractiveObjectInfo GetInfoByName(string ioName)
    {
        if (interactiveObjectInfos == null)
        {
            Debug.LogError("JSON data not loaded.");
            return null;
        }

        return interactiveObjectInfos.Find(info => info.Io_name == ioName);
    }


    private void OnEnable()
    {
        InteractionEvents.OnMouseHover += HandleObjectEmission_ON;
        InteractionEvents.OnMouseExit += HandleObjectEmission_OFF;
        InteractionEvents.OnMouseClick += HandleMouseClick;
    }

    private void OnDisable()
    {
        InteractionEvents.OnMouseHover -= HandleObjectEmission_ON;
        InteractionEvents.OnMouseExit -= HandleObjectEmission_OFF;
        InteractionEvents.OnMouseClick -= HandleMouseClick;
    }
    
    //HandleObjectEmission_ON  HandleObjectEmission_OFF
    //这两个函数用来控制高光和描边 应该不用改了 ；有性能问题或者内存泄露的可能性
    private void HandleObjectEmission_ON(InteractiveObject obj)
    {
        if (obj == null || obj.materialsWithOutline == null || obj.materialsWithOutline.Length == 0)
        {
            Debug.LogError("Invalid InteractiveObject or materialsWithOutline is not set.");
            return;
        }

        Renderer renderer = obj.GetComponent<Renderer>();


        // 材质数组
        Material[] materials = renderer.materials;
        if (materials.Length <= 1)
        {
            Debug.LogError("Materials does not have enough slots.");
            return;
        }

        // 实例化
        Material materialInstance_emi = new Material(obj.emiMaterial);
        Material materialInstance_out = new Material(obj.outlineMaterial);
        // 设置高亮属性
        materialInstance_emi.SetFloat("_is_HighLighted", 1.0f);

        // 更新材质数组
        materials[0]  = materialInstance_emi;
        materials[1] = materialInstance_out;
        
        renderer.materials = materials;

        Debug.Log($"Mouse is hovering over: {obj.gameObject.name}, highlight and outline applied.");
    }

    private void HandleObjectEmission_OFF(InteractiveObject obj)
    {
        if (obj == null || obj.originalMaterials == null || obj.originalMaterials.Length == 0)
        {
            Debug.LogError("Invalid InteractiveObject or originalMaterials is not set.");
            return;
        }

        Renderer renderer = obj.GetComponent<Renderer>();


        // 还原原始材质
        renderer.materials = obj.originalMaterials;

        Debug.Log($"Mouse exited: {obj.gameObject.name}, highlight removed.");
    }
   
    private void HandleMouseClick(InteractiveObject obj)
    {
        if (obj == null)
        {
            Debug.LogError("InteractiveObject is null.");
            return;
        }

        // 从 JSON 数据中查找信息
        InteractiveObjectInfo info = GetInfoByName(obj.Io_name);

        if (info != null)
        {
            Debug.Log($"Name: {info.name}\nDescription: {info.description}\nDiscovered: {info.discovered}");
        }
        else
        {
            Debug.Log($"No information found for {obj.Io_name}");
        }
    }
    
    // 包装器类  JSON 列表反序列化
    [System.Serializable]
    private class Wrapper
    {
        public List<InteractiveObjectInfo> infos;
    }
}