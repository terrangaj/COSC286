using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BinarySearchTrees;

namespace TreeTests;

public class NodeTests
{
    [Test]
    public void TestNode()
    {
        Node<string> root = new Node<string>("Root");
        root.Left = new Node<string>("Left");
        root.Right = new Node<string>("Right");
        root.Right.Left = new Node<string>("RightLeft");
        root.Right.Right = new Node<string>("RightRight");
        Assert.IsFalse(root.IsLeaf());
        Assert.IsTrue(root.Left.IsLeaf());
        Assert.IsTrue(root.Right.Right.IsLeaf());
        string treeString = "Root L(Left) R(Right L(RightLeft) R(RightRight))";
        Assert.AreEqual(treeString, root.ToString());
    }
}

public class BSTTests
{
    BST<int> iBST = new BST<int>();
    BST<Student> stuBST;

    [SetUp]
    public void BSTSetup()
    {
        iBST.Add(50);
        iBST.Add(20);
        iBST.Add(27);
        iBST.Add(77);
        iBST.Add(22);
        iBST.Add(90);
        iBST.Add(89);
        iBST.Add(91);

        stuBST = new BST<Student>();
        stuBST.Add(new Student("Mandy", 501, "mandy@hotmail.com"));
        stuBST.Add(new Student("Hu", 133, "hu@gmail.com"));
        stuBST.Add(new Student("Nancy", 613, "nancy@saskpolytech.ca"));
        stuBST.Add(new Student("Ahmed", 189, "ahmed@saskpolytech.ca"));
        stuBST.Add(new Student("Jane", 648, "jane@outlook.ca"));
    }

    [Test]
    public void TestBSTFindLargest()
    {
        Assert.AreEqual(91, iBST.FindLargest());
        Assert.AreEqual("Jane", stuBST.FindLargest().Name);
        BST<string> emptyBST = new BST<string>();
        Assert.Throws<ApplicationException>(() => emptyBST.FindLargest());
    }

    [Test]
    public void TestBSTRemove()
    {
        Assert.IsFalse(iBST.Remove(9999));
        Assert.IsTrue(iBST.Remove(91));
        Assert.AreEqual(7, iBST.Count);
        Assert.Throws<ApplicationException>(() => iBST.Find(91));
        Assert.IsTrue(iBST.Remove(50));
        Assert.Throws<ApplicationException>(() => iBST.Find(50));
        Assert.AreEqual(6, iBST.Count);
        Assert.AreEqual(27, iBST.Find(27));
        Assert.AreEqual(90, iBST.Find(90));
    }

    [Test]
    public void TestBSTFind()
    {
        Assert.AreEqual(50, iBST.Find(50));
        Assert.AreEqual(90, iBST.Find(90));
        Assert.Throws<ApplicationException>(() => iBST.Find(9999));

        Student jane = stuBST.Find(new Student(null, 648, null));
        Assert.AreEqual("Jane", jane.Name);
        Assert.AreEqual(648, jane.StudentNumber);
        Assert.AreEqual("jane@outlook.ca", jane.Email);

        Assert.Throws<ApplicationException>(() => stuBST.Find(new Student(null, 999, null)));
    }

    [Test]
    public void TestBSTBreadthFirstEnumerator()
    {
        IEnumerator<int> myEnum = iBST.GetBreadthFirstEnumerator();
        myEnum.Reset();
        Assert.IsTrue(myEnum.MoveNext());
        Assert.AreEqual(50, myEnum.Current);
        Assert.IsTrue(myEnum.MoveNext());
        Assert.AreEqual(20, myEnum.Current);
        Assert.IsTrue(myEnum.MoveNext());
        Assert.AreEqual(77, myEnum.Current);
        Assert.IsTrue(myEnum.MoveNext());
        Assert.AreEqual(27, myEnum.Current);
        Assert.IsTrue(myEnum.MoveNext());
        Assert.AreEqual(90, myEnum.Current);
        Assert.IsTrue(myEnum.MoveNext());
        Assert.AreEqual(22, myEnum.Current);
        Assert.IsTrue(myEnum.MoveNext());
        Assert.AreEqual(89, myEnum.Current);
        Assert.IsTrue(myEnum.MoveNext());
        Assert.AreEqual(91, myEnum.Current);
        Assert.IsFalse(myEnum.MoveNext());
        Assert.AreEqual(91, myEnum.Current);
        myEnum.Dispose();
    }

    [Test]
    public void TestAdd()
    {
        Assert.AreEqual(8, iBST.Count);
        string treeString = "Tree (50 L(20 R(27 L(22)) R(77 R(90 L(89) R(91))))";
        Assert.AreEqual(treeString, iBST.ToString());
    }

    [Test]
    public void TestHeight()
    {
        Assert.AreEqual(3, iBST.Height());
        BST<string> sTree = new BST<string>();
        Assert.AreEqual(-1, sTree.Height());
        sTree.Add("A");
        Assert.AreEqual(0, sTree.Height());
        sTree.Add("B");
        Assert.AreEqual(1, sTree.Height());
        sTree.Add("C");
        sTree.Add("D");
        sTree.Add("E");
        Assert.AreEqual(4, sTree.Height());
        sTree.Add("1");
        Assert.AreEqual(4, sTree.Height());
    }

    [Test]
    public void TestEqualTrees()
    {
        BST<int> bst1 = new BST<int>();
        BST<int> bst2 = new BST<int>();
        AVLT<int> avl1 = new AVLT<int>();
        AVLT<int> avl2 = new AVLT<int>();

        Assert.IsTrue(bst1 == bst2);
        Assert.IsTrue(avl1 == avl2);
        Assert.IsFalse(bst1 != bst2);

        int[] values = { 50, 30, 70, 20, 40, 60, 80 };
        foreach (int value in values)
        {
            bst1.Add(value);
            bst2.Add(value);
            avl1.Add(value);
            avl2.Add(value);
        }

        Assert.IsTrue(bst1 == bst2);
        Assert.IsFalse(bst1 != bst2);
        Assert.IsTrue(avl1 == avl2);
        Assert.IsFalse(avl1 != avl2);
        Assert.IsTrue(bst1 == avl1);
        Assert.IsTrue(bst1 == bst1);
    }

    [Test]
    public void TestNotEqualTrees()
    {
        BST<int> bst1 = new BST<int>();
        BST<int> bst2 = new BST<int>();
        AVLT<int> avl1 = new AVLT<int>();
        AVLT<int> avl2 = new AVLT<int>();
        BST<int> nullTree = null;

        bst1.Add(50);
        Assert.IsFalse(bst1 == bst2);
        Assert.IsTrue(bst1 != bst2);

        bst1.Add(30);
        bst2.Add(50);
        bst2.Add(20);
        Assert.IsFalse(bst1 == bst2);
        Assert.IsTrue(bst1 != bst2);

        avl1.Add(10);
        avl1.Add(20);
        avl1.Add(30);
        avl2.Add(10);
        avl2.Add(20);
        avl2.Add(30);
        avl2.Add(40);
        Assert.IsFalse(avl1 == avl2);
        Assert.IsTrue(avl1 != avl2);

        Assert.IsFalse(bst1 == nullTree);
        Assert.IsTrue(bst1 != nullTree);
        Assert.IsTrue(nullTree == null);
    }

    [Test]
    public void TestShapeMatters()
    {
        BST<int> bstChain = new BST<int>();
        BST<int> bstBalanced = new BST<int>();
        AVLT<int> avl1 = new AVLT<int>();
        AVLT<int> avl2 = new AVLT<int>();

        bstChain.Add(1);
        bstChain.Add(2);
        bstChain.Add(3);

        bstBalanced.Add(2);
        bstBalanced.Add(1);
        bstBalanced.Add(3);

        avl1.Add(1);
        avl1.Add(2);
        avl1.Add(3);

        avl2.Add(2);
        avl2.Add(1);
        avl2.Add(3);

        Assert.IsFalse(bstChain == bstBalanced);
        Assert.IsTrue(bstChain != bstBalanced);

        Assert.IsTrue(avl1 == avl2);
        Assert.IsFalse(avl1 != avl2);

        Assert.IsTrue(bstBalanced == avl1);
        Assert.IsFalse(bstChain == avl1);
    }
}

public class AVLTTests
{
    AVLT<int> iAVLT = new AVLT<int>();
    AVLT<Student> stuAVLT;

    [SetUp]
    public void AVLTSetup()
    {
        iAVLT.Add(50);
        iAVLT.Add(20);
        iAVLT.Add(27);
        iAVLT.Add(77);
        iAVLT.Add(22);
        iAVLT.Add(90);
        iAVLT.Add(89);
        iAVLT.Add(91);

        stuAVLT = new AVLT<Student>();
        stuAVLT.Add(new Student("Mandy", 501, "mandy@hotmail.com"));
        stuAVLT.Add(new Student("Hu", 133, "hu@gmail.com"));
        stuAVLT.Add(new Student("Nancy", 613, "nancy@saskpolytech.ca"));
        stuAVLT.Add(new Student("Ahmed", 189, "ahmed@saskpolytech.ca"));
        stuAVLT.Add(new Student("Jane", 648, "jane@outlook.ca"));
    }

    [Test]
    public void TestSingleLeft()
    {
        Node<string> root = new Node<string>("Root");
        root.Right = new Node<string>("Right");
        root.Left = new Node<string>("Left");
        root.Right.Right = new Node<string>("RightRight");
        root.Right.Left = new Node<string>("RightLeft");
        root.Left.Right = new Node<string>("LeftRight");
        root.Left.Left = new Node<string>("LeftLeft");
        root = AVLT<string>.SingleLeft(root);
        Assert.AreEqual("Right", root.Data);
        Assert.AreEqual("RightRight", root.Right.Data);
        Assert.AreEqual("Root", root.Left.Data);
        Assert.AreEqual("Left", root.Left.Left.Data);
        Assert.AreEqual("RightLeft", root.Left.Right.Data);
    }

    [Test]
    public void TestSingleRight()
    {
        Node<string> root = new Node<string>("Root");
        root.Right = new Node<string>("Right");
        root.Left = new Node<string>("Left");
        root.Right.Right = new Node<string>("RightRight");
        root.Right.Left = new Node<string>("RightLeft");
        root.Left.Right = new Node<string>("LeftRight");
        root.Left.Left = new Node<string>("LeftLeft");
        root = AVLT<string>.SingleRight(root);
        Assert.AreEqual("Left", root.Data);
        Assert.AreEqual("LeftLeft", root.Left.Data);
        Assert.AreEqual("Root", root.Right.Data);
        Assert.AreEqual("Right", root.Right.Right.Data);
        Assert.AreEqual("LeftRight", root.Right.Left.Data);
    }

    [Test]
    public void TestDoubleLeft()
    {
        Node<string> root = new Node<string>("Root");
        root.Right = new Node<string>("Right");
        root.Left = new Node<string>("Left");
        root.Right.Right = new Node<string>("RightRight");
        root.Right.Left = new Node<string>("RightLeft");
        root.Left.Right = new Node<string>("LeftRight");
        root.Left.Left = new Node<string>("LeftLeft");
        root = AVLT<string>.DoubleLeft(root);
        Assert.AreEqual("RightLeft", root.Data);
        Assert.AreEqual("Right", root.Right.Data);
        Assert.AreEqual("Root", root.Left.Data);
    }

    [Test]
    public void TestDoubleRight()
    {
        Node<string> root = new Node<string>("Root");
        root.Right = new Node<string>("Right");
        root.Left = new Node<string>("Left");
        root.Right.Right = new Node<string>("RightRight");
        root.Right.Left = new Node<string>("RightLeft");
        root.Left.Right = new Node<string>("LeftRight");
        root.Left.Left = new Node<string>("LeftLeft");
        root = AVLT<string>.DoubleRight(root);
        Assert.AreEqual("LeftRight", root.Data);
        Assert.AreEqual("Left", root.Left.Data);
        Assert.AreEqual("Root", root.Right.Data);
    }
    [Test]
    public void TestGetHeightDifference()
    {
        Node<string> root = new Node<string>("Root");
        Assert.AreEqual(0, AVLT<string>.GetHeightDifference(root));
        root.Right = new Node<string>("Right");
        Assert.AreEqual(1, AVLT<string>.GetHeightDifference(root));
        root.Left = new Node<string>("Left");
        Assert.AreEqual(0, AVLT<string>.GetHeightDifference(root));
        root.Left.Left = new Node<string>("LeftLeft");
        Assert.AreEqual(-1, AVLT<string>.GetHeightDifference(root));
        root.Left.Left.Right = new Node<string>("LeftLeftRight");
        Assert.AreEqual(-2, AVLT<string>.GetHeightDifference(root));
    }




    [Test]
    public void TestAVLTFindLargest()
    {
        Assert.AreEqual(91, iAVLT.FindLargest());
        Assert.AreEqual("Jane", stuAVLT.FindLargest().Name);
        AVLT<string> emptyAVLT = new AVLT<string>();
        Assert.Throws<ApplicationException>(() => emptyAVLT.FindLargest());
    }

    [Test]
    public void TestAVLTRemove()
    {
        Assert.IsFalse(iAVLT.Remove(9999));
        Assert.IsTrue(iAVLT.Remove(91));
        Assert.AreEqual(7, iAVLT.Count);
        Assert.Throws<ApplicationException>(() => iAVLT.Find(91));
        Assert.IsTrue(iAVLT.Remove(50));
        Assert.Throws<ApplicationException>(() => iAVLT.Find(50));
        Assert.AreEqual(6, iAVLT.Count);
        Assert.AreEqual(27, iAVLT.Find(27));
        Assert.AreEqual(90, iAVLT.Find(90));
    }

    [Test]
    public void TestAVLTFind()
    {
        Assert.AreEqual(50, iAVLT.Find(50));
        Assert.AreEqual(90, iAVLT.Find(90));
        Assert.Throws<ApplicationException>(() => iAVLT.Find(9999));

        Student jane = stuAVLT.Find(new Student(null, 648, null));
        Assert.AreEqual("Jane", jane.Name);
        Assert.AreEqual(648, jane.StudentNumber);
        Assert.AreEqual("jane@outlook.ca", jane.Email);

        Assert.Throws<ApplicationException>(() => stuAVLT.Find(new Student(null, 999, null)));
    }

    [Test]
    public void TestAVLTBreadthFirstEnumerator()
    {
        IEnumerator<int> myEnum = iAVLT.GetBreadthFirstEnumerator();
        myEnum.Reset();
        Assert.IsTrue(myEnum.MoveNext());
        Assert.AreEqual(50, myEnum.Current);
        Assert.IsTrue(myEnum.MoveNext());
        Assert.AreEqual(20, myEnum.Current);
        Assert.IsTrue(myEnum.MoveNext());
        Assert.AreEqual(77, myEnum.Current);
        Assert.IsTrue(myEnum.MoveNext());
        Assert.AreEqual(27, myEnum.Current);
        Assert.IsTrue(myEnum.MoveNext());
        Assert.AreEqual(90, myEnum.Current);
        Assert.IsTrue(myEnum.MoveNext());
        Assert.AreEqual(22, myEnum.Current);
        Assert.IsTrue(myEnum.MoveNext());
        Assert.AreEqual(89, myEnum.Current);
        Assert.IsTrue(myEnum.MoveNext());
        Assert.AreEqual(91, myEnum.Current);
        Assert.IsFalse(myEnum.MoveNext());
        Assert.AreEqual(91, myEnum.Current);
        myEnum.Dispose();
    }

    [Test]
    public void TestAVLTAdd()
    {
        Assert.AreEqual(8, iAVLT.Count);
        string treeString = "Tree (50 L(20 R(27 L(22)) R(77 R(90 L(89) R(91))))";
        Assert.AreEqual(treeString, iAVLT.ToString());
    }

    [Test]
    public void TestAVLTHeight()
    {
        Assert.AreEqual(3, iAVLT.Height());
        AVLT<string> sTree = new AVLT<string>();
        Assert.AreEqual(-1, sTree.Height());
        sTree.Add("A");
        Assert.AreEqual(0, sTree.Height());
        sTree.Add("B");
        Assert.AreEqual(1, sTree.Height());
        sTree.Add("C");
        sTree.Add("D");
        sTree.Add("E");
        Assert.AreEqual(4, sTree.Height());
        sTree.Add("1");
        Assert.AreEqual(4, sTree.Height());
    }
}