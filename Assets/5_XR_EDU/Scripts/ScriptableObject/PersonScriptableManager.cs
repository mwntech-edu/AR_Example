using System.IO;
using UnityEngine;

public class PersonScriptableManager : MonoBehaviour
{
    void Start()
    {
        TryPersonScriptableSave();
        TryPersonScriptableLoad();
    }

    public void TryPersonScriptableSave()
    {
        Person data = ScriptableObject.CreateInstance<Person>();
        data.age = 12;
        string jsonData = JsonUtility.ToJson(data);
        Debug.Log(Application.persistentDataPath);
        File.WriteAllText(Application.persistentDataPath + "\\MyFile.json", jsonData);
    }

    public void TryPersonScriptableLoad()
    {
        string jsonData = File.ReadAllText(Application.persistentDataPath + "\\MyFile.json");
        Debug.Log(jsonData);
        Person data = ScriptableObject.CreateInstance<Person>();
        JsonUtility.FromJsonOverwrite(jsonData, data);
        Debug.Log(data.age);
    }
}

[CreateAssetMenu(fileName = "Person", menuName = "SO/Person")]
public class Person : ScriptableObject
{
    public string name = "Joe the Infant";

    public int age = 5;

    public Person GetInstance()
    {
        return Instantiate(this);
    }

    public override string ToString()
    {
        return "My name is " + name + " and I'm " + age + " years old.";
    }
}