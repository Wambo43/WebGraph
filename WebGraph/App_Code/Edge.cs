using System;

/// <summary>
/// Zusammenfassungsbeschreibung für Edge
/// </summary>
public class Edge : IEquatable<Edge>, ICloneable
{
    public string id;
    public int from { get; set; }
    public int to { get; set; }
    public int value;
    public string label;
    public string color;
    public Font font;

    public Edge()
    { }
    public Edge(int _from, int _to, int _value, string _label)
    {
        //this.id     = _id;
        this.from = _from;
        this.to = _to;
        this.value = _value;
        this.label = _label;
        this.color = "blue";
        this.font = new Font("top");
    }
    public Edge(string _id, int _from, int _to, int _value, string _label, string _color)
    {
        this.id = _id;
        this.from = _from;
        this.to = _to;
        this.value = _value;
        this.label = _label;
        this.color = _color;
        this.font = new Font("top");
    }
    public Edge(Edge _e, string _color)
    {
        this.id = _e.id;
        this.from = _e.from;
        this.to = _e.to;
        this.value = _e.value;
        this.label = _e.label;
        this.color = _color;
        this.font = _e.font;
    }
    public bool Equals(Edge _other)
    {
        bool contains = false;
        if (to == _other.to && from == _other.from)
            contains = true;
        return contains;
    }
    public object Clone()
    {
        return this.MemberwiseClone();
    }
}
