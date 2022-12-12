class Program
{
    static void Main(string[] args)
    {
        Tree<string> Tree = new Tree<string>();
        Stack<string> Finding = new Stack<string>();
        bool Met = false;

        Tree.addingRootNode();
        int count = 0;

        do
        {
            string Name = Console.ReadLine();
            int Node = int.Parse(Console.ReadLine());
            Tree.AddForTree(Name, Node);
            count++;

        } while (Tree.GetLength() != count);

        string vacationName = Console.ReadLine();
        Tree.FindAns(Tree.getRoot(), vacationName, ref Finding, ref Met);


    }
}