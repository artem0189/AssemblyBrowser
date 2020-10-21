using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AssemblyLib;
using AssemblyLib.Node;

namespace UnitTestAssemblyLib
{
    [TestClass]
    public class Tests
    {
        private const string assemblyPath = "C:/Users/USER/Desktop/лб/спп/AssemblyBrowserApp/AssemblyBrowser/TestLibrary/bin/Debug/TestLibrary.dll";
        private List<AssemblyNode> result;

        [TestInitialize]
        public void Initialize()
        {
            result = new AssemblyStructure(assemblyPath).GetAssemblyStructure();
        }

        [TestMethod]
        public void TestNamespaces()
        {
            Assert.AreEqual(7, result.Count);
            Assert.IsNotNull(result.Count(elem => elem.Name.Equals("System")));
            Assert.IsNotNull(result.Count(elem => elem.Name.Equals("System.Collections.Generic")));
            Assert.IsNotNull(result.Count(elem => elem.Name.Equals("TestLibrary")));
            Assert.IsNotNull(result.Count(elem => elem.Name.Equals("TestLibrary.Extension")));
            Assert.IsNotNull(result.Count(elem => elem.Name.Equals("TestLibrary.Reflection")));
            Assert.IsNotNull(result.Count(elem => elem.Name.Equals("TestLibrary.Tree")));
            Assert.IsNotNull(result.Count(elem => elem.Name.Equals("TestLibrary.Tree.TreeNode")));
        }

        [TestMethod]
        public void TestType()
        {
            Assert.AreEqual(1, result.Where(elem => elem.Name.Equals("System")).ToList()[0].Childrens.Count);
            Assert.AreEqual(1, result.Where(elem => elem.Name.Equals("System.Collections.Generic")).ToList()[0].Childrens.Count);
            Assert.AreEqual(2, result.Where(elem => elem.Name.Equals("TestLibrary")).ToList()[0].Childrens.Count);
            Assert.AreEqual(2, result.Where(elem => elem.Name.Equals("TestLibrary.Extension")).ToList()[0].Childrens.Count);
            Assert.AreEqual(1, result.Where(elem => elem.Name.Equals("TestLibrary.Reflection")).ToList()[0].Childrens.Count);
            Assert.AreEqual(1, result.Where(elem => elem.Name.Equals("TestLibrary.Tree")).ToList()[0].Childrens.Count);
            Assert.AreEqual(2, result.Where(elem => elem.Name.Equals("TestLibrary.Tree.TreeNode")).ToList()[0].Childrens.Count);
        }

        [TestMethod]
        public void TestExtensionMethod()
        {
            AssemblyNode systemNamespace = result.Where(elem => elem.Name.Equals("System")).ToList()[0];
            Assert.AreEqual(1, systemNamespace.Childrens.Count);
            Assert.AreEqual(1, systemNamespace.Childrens[0].Childrens.Count);
            Assert.IsTrue(systemNamespace.Childrens[0].Childrens[0].Name.Equals("Int32 CharCount(String str)"));
            AssemblyNode systemListNamespace = result.Where(elem => elem.Name.Equals("System.Collections.Generic")).ToList()[0];
            Assert.AreEqual(1, systemListNamespace.Childrens.Count);
            Assert.AreEqual(1, systemListNamespace.Childrens[0].Childrens.Count);
            Assert.IsTrue(systemListNamespace.Childrens[0].Childrens[0].Name.Equals("T GetOrAdd<T>(List<T> list, T elem)"));
        }

        [TestMethod]
        public void TestFieldsAndPropertiesMethod()
        {
            AssemblyNode treeNodespace = result.Where(elem => elem.Name.Equals("TestLibrary.Tree.TreeNode")).ToList()[0];
            AssemblyNode nodeClass = treeNodespace.Childrens.Where(elem => elem.Name.Equals("Node")).ToList()[0];
            Assert.AreEqual(2, nodeClass.Childrens.Count);
            Assert.IsNotNull(nodeClass.Childrens.Count(elem => elem.Name.Equals("Object test")));
            Assert.IsNotNull(nodeClass.Childrens.Count(elem => elem.Name.Equals("Object Value")));
        }

        [TestMethod]
        public void CheckCustomNameFunc()
        {
            AssemblyStructure assemblyStructure = new AssemblyStructure(assemblyPath);
            assemblyStructure.SetCustomNameFunc(TypeNode.Namespace, CustomNamespaceName);
            result = assemblyStructure.GetAssemblyStructure();
            Assert.AreEqual(7, result.Count);
            for (int i = 0; i < result.Count; i++)
            {
                Assert.IsTrue(result[i].Name.EndsWith(" done"));
            }
        }

        public static string CustomNamespaceName(object objectType)
        {
            return (objectType as Type).Namespace + " done";
        }
    }
}
