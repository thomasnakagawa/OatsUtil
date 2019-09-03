using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using OatsUtil;
using UnityEngine.TestTools;
using System.Text.RegularExpressions;

public class ComponentExtensionTests
{
    private class ExampleUnityComponent : MonoBehaviour {}

    private static readonly Regex ANY_STRING = new Regex("");

    [Test(Description = "An attached component is returned by RequireComponent")]
    public void RequireComponent_AttachedComponent_Test()
    {
        GameObject objectUnderTest = new GameObject("test obj");
        ExampleUnityComponent addedComponent = objectUnderTest.AddComponent<ExampleUnityComponent>();
        ExampleUnityComponent returnedComponent = objectUnderTest.transform.RequireComponent<ExampleUnityComponent>();
        Assert.AreSame(addedComponent, returnedComponent);
    }

    [Test(Description = "RequireComponent returns null when the component is not attached")]
    public void RequireComponent_NoAttachedComponent_Test()
    {
        GameObject objectUnderTest = new GameObject("test obj");
        ExampleUnityComponent returnedComponent = objectUnderTest.transform.RequireComponent<ExampleUnityComponent>();
        LogAssert.Expect(LogType.Exception, ANY_STRING);
        Assert.IsNull(returnedComponent);
    }

    [Test(Description = "RequireComponent returns null and logs exception when the component is attached to a child object")]
    public void RequireComponent_AttachedComponentToChild_Test()
    {
        GameObject objectUnderTest = new GameObject("test obj");
        GameObject childObject = new GameObject("childobj");
        ExampleUnityComponent addedComponent = childObject.AddComponent<ExampleUnityComponent>();
        childObject.transform.parent = objectUnderTest.transform;

        ExampleUnityComponent returnedComponent = objectUnderTest.transform.RequireComponent<ExampleUnityComponent>();
        LogAssert.Expect(LogType.Exception, ANY_STRING);
        Assert.IsNull(returnedComponent);

        ExampleUnityComponent childReturnedComponent = childObject.transform.RequireComponent<ExampleUnityComponent>();
        Assert.AreSame(addedComponent, childReturnedComponent);
    }

    [Test(Description = "RequireChild returns child transform when child exists")]
    public void RequireChild_HasChild_Test()
    {
        GameObject objectUnderTest = new GameObject("test obj");
        GameObject childObject = new GameObject("childobj");
        childObject.transform.parent = objectUnderTest.transform;
        Transform returnedTransform = objectUnderTest.transform.RequireChildGameObject("childobj");
        Assert.AreSame(childObject.transform, returnedTransform);
    }

    [Test(Description = "RequireChild returns null and logs exception when child doesn't exist")]
    public void RequireChild_NoChild_Test()
    {
        GameObject objectUnderTest = new GameObject("test obj");
        GameObject childObject = new GameObject("childobj");
        // NOTE: childobj was not parented under objectUnderTest here
        
        Transform returnedTransform = objectUnderTest.transform.RequireChildGameObject("childobj");
        LogAssert.Expect(LogType.Exception, ANY_STRING);
        Assert.IsNull(returnedTransform);
    }
}
