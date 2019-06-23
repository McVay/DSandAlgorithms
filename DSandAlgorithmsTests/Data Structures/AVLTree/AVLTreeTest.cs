using DSandAlgorithms.Data_Structures.AVLTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSandAlgorithmsTests.Data_Structures.AVLTree
{
    [TestClass]
    public class AVLTreeTest
    {
        [TestMethod]
        public void AddTest()
        {
            AVLTree<int> AVL = new AVLTree<int>();
            Assert.AreEqual(0, AVL.Size());

            AVL.Insert(5);
            AVL.Insert(3);
            AVL.Insert(2);
            AVL.Insert(6);
            AVL.Insert(1);
            AVL.Insert(4);

            Assert.AreEqual(true, AVL.Contains(6));
            Assert.AreEqual(true, AVL.Contains(3));
            Assert.AreEqual(false, AVL.Contains(23));
            Assert.AreEqual(true, AVL.ValidateBSTInvariant());

            AVL.Insert(-6);
            Assert.AreEqual(true, AVL.ValidateBSTInvariant());
        }
    }
}