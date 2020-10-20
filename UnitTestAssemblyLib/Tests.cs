using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AssemblyLib;
using AssemblyLib.AssemblyNode;

namespace UnitTestAssemblyLib
{
    [TestClass]
    public class Tests
    {
        private const string assemblyPath = "C:/Users/USER/Desktop/лб/спп/AssemblyBrowserApp/AssemblyBrowser/TestLibrary/bin/Debug/TestLibrary.dll";
        private List<IAssemblyNode> result;

        [TestInitialize]
        public void Initialize()
        {
            Assembly assembly = Assembly.LoadFrom(assemblyPath);
            result = new AssemblyStructure(assembly).GetAssemblyStructure();
        }

        /*

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
            Assert.AreEqual(1, result.Where(elem => elem.Name.Equals("System")).ToList()[0].Nodes.Count);
            Assert.AreEqual(1, result.Where(elem => elem.Name.Equals("System.Collections.Generic")).ToList()[0].Nodes.Count);
            Assert.AreEqual(1, result.Where(elem => elem.Name.Equals("TestLibrary")).ToList()[0].Nodes.Count);
            Assert.AreEqual(2, result.Where(elem => elem.Name.Equals("TestLibrary.Extension")).ToList()[0].Nodes.Count);
            Assert.AreEqual(1, result.Where(elem => elem.Name.Equals("TestLibrary.Reflection")).ToList()[0].Nodes.Count);
            Assert.AreEqual(1, result.Where(elem => elem.Name.Equals("TestLibrary.Tree")).ToList()[0].Nodes.Count);
            Assert.AreEqual(2, result.Where(elem => elem.Name.Equals("TestLibrary.Tree.TreeNode")).ToList()[0].Nodes.Count);
        }

        [TestMethod]
        public void TestExtensionMethod()
        {
            IAssemblyNode systemNamespace = result.Where(elem => elem.Name.Equals("System")).ToList()[0];
            Assert.AreEqual(1, systemNamespace.Nodes.Count);
            Assert.AreEqual(1, systemNamespace.Nodes[0].Nodes.Count);
            Assert.IsTrue(systemNamespace.Nodes[0].Nodes[0].Name.Equals("Int32 CharCount(String str)"));
            IAssemblyNode systemListNamespace = result.Where(elem => elem.Name.Equals("System.Collections.Generic")).ToList()[0];
            Assert.AreEqual(1, systemListNamespace.Nodes.Count);
            Assert.AreEqual(1, systemListNamespace.Nodes[0].Nodes.Count);
            Assert.IsTrue(systemListNamespace.Nodes[0].Nodes[0].Name.Equals("T GetOrAdd(List`1 list, T elem)"));
        }

        [TestMethod]
        public void TestFieldsAndPropertiesMethod()
        {
            IAssemblyNode treeNodespace = result.Where(elem => elem.Name.Equals("TestLibrary.Tree.TreeNode")).ToList()[0];
            IAssemblyNode nodeClass = treeNodespace.Nodes.Where(elem => elem.Name.Equals("Node")).ToList()[0];
            Assert.AreEqual(2, nodeClass.Nodes.Count);
            Assert.IsNotNull(nodeClass.Nodes.Count(elem => elem.Name.Equals("Object test")));
            Assert.IsNotNull(nodeClass.Nodes.Count(elem => elem.Name.Equals("Object Value")));
        }
        */
    }
}
