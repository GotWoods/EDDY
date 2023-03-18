namespace EdiParser.x12.Models.Internals;

public interface IGroupable
{
    void AddChild(Group group);
}