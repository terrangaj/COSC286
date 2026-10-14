using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        Assert.IsTrue(root.Left.IsLeaf() );
        Assert.IsTrue(root.Right.Right.IsLeaf() ) ;
        string treeString = "Root L(Left) R(Right) L(RightLeft)R(RightRight))";
        Assert.AreEqual(treeString, root.ToString() );
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
        /*
         *          50
         *         /   \
         *        20    77
         *          \     \ 
         *           27     90
         *          /      /  \
         *        22      89   91
         * 
         */

        stuBST = new BST<Student>();
        stuBST.Add(new Student("Mandy", 501, "mandy@hotmail.com"));
        stuBST.Add(new Student("Hu", 133, "hu@gmail.com"));
        stuBST.Add(new Student("Nancy", 613, "nancy@saskpolytech.ca"));
        stuBST.Add(new Student("Ahmed", 189, "ahmed@saskpolytech.ca"));
        stuBST.Add(new Student("Jane", 648, "jane@outlook.ca"));



    }
    [Test]
    public void TestBSTFindSmallest()
    {
        Assert.AreEqual(91, iBST.FindLargest());
        Assert.AreEqual("Jane", stuBST.FindLargest().Name));
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
        Assert.Throws<ApplicationException> (() => iBST.Find(50));
        Assert.AreEqual(6, iBST.Count);
        Assert.AreEqual(27, iBST.Find(27));
        Assert.AreEqual(90, iBST.Find(90));
    }


    [Test]
    public void TestBSTFind()
    {
        Assert.AreEqual(50, iBST.Find(50));
        Assert.AreEqual(90, iBST.Find(90));
        //if i try to find something that isnt in the tree, i should get an 
        //applicationexception
        Assert.Throws<ApplicationException>(() => iBST.Find(9999));

        Student jane = stuBST.Find(new Student(null, 648, null));
        Assert.AreEqual("Jane", jane.Name);
        Assert.AreEqual(648, jane.StudentNumber);
        Assert.AreEqual("jane@outlook.com", jane.Email);

        Assert.Throws<ApplicationException>(() => stuBST.Find(new Student(null, 999, null)));
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
}
