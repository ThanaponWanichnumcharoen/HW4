class Tree<T>
{
    public TreeNode<T> root = null;
    public int length = 0;


    public void AddSibling(int index, string value)
    {
        TreeNode<T> node = new TreeNode<T>(value);
        TreeNode<T> ptr = this.GetTreeNode(index);
        node.SetNext(ptr.Next());
        ptr.SetNext(node);
        this.length++;
    }

    public void AddChild(int index, string value)
    {
        TreeNode<T> node = new TreeNode<T>(value);
        if (index == -1)
        {
            node.SetChild(this.root);
            this.root = node;
        }
        else
        {
            TreeNode<T> ptr = this.GetTreeNode(index);
            node.SetChild(ptr.Child());
            ptr.SetChild(node);
        }
        this.length++;
    }

    public int GetLength()
    {
        return this.length;
    }

    public TreeNode<T> getRoot()
    {
        return this.root;
    }


    public string Get(int index)
    {
        TreeNode<T> ptr = this.GetTreeNode(index);
        return ptr.GetValue();
    }

    public void FindAns(TreeNode<T> currentTreeNode, string name, ref Stack<string> ans, ref bool isFind)
    {

        TreeNode<T> ptr = currentTreeNode;
        Stack<string> list = ans;

        if (ptr.GetValue() == name)
        {
            while (list.GetLength() > 0)
            {
                Console.WriteLine(list.Pop());
            }
            isFind = true;
            return;
        }

        if (currentTreeNode.Child() != null && !isFind)
        {
            list.Push(ptr.GetValue());
            this.FindAns(currentTreeNode.Child(), name, ref list, ref isFind);
            if (list.GetLength() != 0)
            {
                list.Pop();
            }
        }

        if (currentTreeNode.Next() != null && !isFind)
        {
            this.FindAns(currentTreeNode.Next(), name, ref list, ref isFind);
        }

        return;
    }

    public void AddForTree(string name, int underMember)
    {
        int traverseStep = this.length;
        TreeNode<T> ptr = FindingNullNode(this.root, ref traverseStep);

        ptr.SetValue(name);
        int i = 1;
        while (i <= underMember)
        {
            TreeNode<T> node = new TreeNode<T>(null);
            if (i == 1)
            {
                ptr.SetChild(node);
                ptr = ptr.Child();
            }
            else
            {
                ptr.SetNext(node);
                ptr = ptr.Next();
            }
            this.length++;

            i++;
        }
    }

    public TreeNode<T> FindingNullNode(TreeNode<T> currentTreeNode, ref int traverseStep)
    {

        TreeNode<T> ptr = currentTreeNode;

        if (ptr.GetValue() == null) { traverseStep = 0; return ptr; }

        if (traverseStep > 0 && currentTreeNode.Child() != null)
        {
            traverseStep++;
            ptr = this.FindingNullNode(currentTreeNode.Child(), ref traverseStep);
        }

        if (traverseStep > 0 && currentTreeNode.Next() != null)
        {
            ptr = this.FindingNullNode(currentTreeNode.Next(), ref traverseStep);
        }

        return ptr;
    }





    public void addingRootNode()
    {
        TreeNode<T> node = new TreeNode<T>(null);
        this.root = node;
        this.length++;
    }

    public TreeNode<T> GetTreeNode(int index)
    {
        int traverseStep = index;
        return this.Traverse(this.root, ref traverseStep);
    }

    public TreeNode<T> Traverse(TreeNode<T> currentTreeNode, ref int traverseStep)
    {
        TreeNode<T> ptr = currentTreeNode;

        if (traverseStep > 0 && currentTreeNode.Child() != null)
        {
            traverseStep--;
            ptr = this.Traverse(currentTreeNode.Child(), ref traverseStep);
        }

        if (traverseStep > 0 && currentTreeNode.Next() != null)
        {
            traverseStep--;
            ptr = this.Traverse(currentTreeNode.Next(), ref traverseStep);
        }

        return ptr;
    }
}