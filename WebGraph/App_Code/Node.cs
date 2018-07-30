using System;

/// <summary>
/// Zusammenfassungsbeschreibung für Node
/// </summary>
public class Node : IEquatable<Node>, ICloneable
{
    public int id { get; set; }
    public string label;

    public Node()
    { }

    public Node(int _id)
    {
        this.id = _id;
        this.label = "Node:" + _id;
    }
    public Node(int _id, string _label)
    {
        this.id = _id;
        this.label = _label;
    }

    public bool Equals(Node _other)
    {
        if (this.id == _other.id)
            return true;
        return false;
    }
    public object Clone()
    {
        return this.MemberwiseClone();
    }
}