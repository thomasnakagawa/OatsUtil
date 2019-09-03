using UnityEngine;
using NUnit.Framework;
using OatsUtil;
using UnityEngine.TestTools;
using System.Text.RegularExpressions;

[TestFixture]
public class SceneUtilsTests
{
    [TearDown] public void Cleanup()
    {
        foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
        {
            Object.DestroyImmediate(o);
        }
    }

    public class ExampleUnityComponent : MonoBehaviour { }
    private static readonly Regex ANY_STRING = new Regex("");

    [Test(Description = "FindComponentInScene finds component when the component is attached to a top level GameObject")]
    public void FindComponentInScene_finds_top_level_component()
    {
        GameObject objectUnderTest = new GameObject("test obj");
        ExampleUnityComponent addedComponent = objectUnderTest.AddComponent<ExampleUnityComponent>();

        ExampleUnityComponent foundComponent = SceneUtils.FindComponentInScene<ExampleUnityComponent>();

        Assert.AreSame(addedComponent, foundComponent);
    }

    [Test(Description = "FindComponentInScene finds component when the component is attached to a child level GameObject")]
    public void FindComponentInScene_finds_child_level_component()
    {
        GameObject objectUnderTest = new GameObject("test obj");
        GameObject childobject = new GameObject("childObj");
        childobject.transform.parent = objectUnderTest.transform;
        ExampleUnityComponent addedComponent = childobject.AddComponent<ExampleUnityComponent>();

        ExampleUnityComponent foundComponent = SceneUtils.FindComponentInScene<ExampleUnityComponent>();

        Assert.AreSame(addedComponent, foundComponent);
    }

    [Test(Description = "FindComponentInScene returns null and logs when no component exists in scene")]
    public void FindComponentInScene_no_component_exists()
    {
        GameObject objectUnderTest = new GameObject("test obj");
        GameObject childobject = new GameObject("childObj");
        childobject.transform.parent = objectUnderTest.transform;

        ExampleUnityComponent foundComponent = SceneUtils.FindComponentInScene<ExampleUnityComponent>();

        LogAssert.Expect(LogType.Exception, ANY_STRING);
        Assert.IsNull(foundComponent);
    }

    [Test(Description = "FindComponentInScene(name) finds component when attached to game object with correct name")]
    public void FindComponentInScene_1arg_finds_component()
    {
        GameObject objectUnderTest = new GameObject("test obj");
        ExampleUnityComponent addedComponent = objectUnderTest.AddComponent<ExampleUnityComponent>();

        ExampleUnityComponent foundComponent = SceneUtils.FindComponentInScene<ExampleUnityComponent>("test obj");

        Assert.AreSame(addedComponent, foundComponent);
    }

    [Test(Description = "FindComponentInScene(name) returns null when component exists in scene but is attached to a different GO than the named one")]
    public void FindComponentInScene_1arg_null_when_wrong_name()
    {
        GameObject objectUnderTest = new GameObject("test obj");
        GameObject secondObject = new GameObject("secondObj");
        ExampleUnityComponent addedComponent = objectUnderTest.AddComponent<ExampleUnityComponent>();

        ExampleUnityComponent foundComponent = SceneUtils.FindComponentInScene<ExampleUnityComponent>("secondObj");

        LogAssert.Expect(LogType.Exception, ANY_STRING);
        Assert.IsNull(foundComponent);
    }

    [Test(Description = "FindComponentInScene(name) returns null when named object doesnt exist")]
    public void FindComponentInScene_1arg_null_when_object_doesnt_exist()
    {
        GameObject objectUnderTest = new GameObject("test obj");

        ExampleUnityComponent foundComponent = SceneUtils.FindComponentInScene<ExampleUnityComponent>("secondObj");

        LogAssert.Expect(LogType.Exception, ANY_STRING);
        Assert.IsNull(foundComponent);
    }

    [Test(Description = "FindObjectInScene finds top level object")]
    public void FindObjectInScene_finds_top_level_object()
    {
        GameObject objectUnderTest = new GameObject("test obj");

        GameObject foundObject = SceneUtils.FindObjectInScene("test obj");

        Assert.AreSame(objectUnderTest, foundObject);
    }

    [Test(Description = "FindObjectInScene finds child object")]
    public void FindObjectInScene_finds_child_object()
    {
        GameObject objectUnderTest = new GameObject("test obj");
        GameObject childobject = new GameObject("childObj");
        childobject.transform.parent = objectUnderTest.transform;

        GameObject foundObject = SceneUtils.FindObjectInScene("childObj");

        Assert.AreSame(childobject, foundObject);
    }

    [Test(Description = "FindObjectInScene returns null when object doesnt exist")]
    public void FindObjectInScene_null_when_doesnt_exist()
    {
        GameObject objectUnderTest = new GameObject("test obj");
        GameObject childobject = new GameObject("childObj");
        childobject.transform.parent = objectUnderTest.transform;

        GameObject foundObject = SceneUtils.FindObjectInScene("nonexist");

        LogAssert.Expect(LogType.Exception, ANY_STRING);
        Assert.IsNull(foundObject);
    }
}