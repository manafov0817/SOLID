using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOLID.Models
{
    public enum Relationship
    {
        Parent,
        Child,
        Sibling
    }

    public class Person
    {
        public string Name;  // DoB and other useful properties here
    }

    //public class Relationships // low-level
    //{
    //    public List<(Person, Relationship, Person)> relations = new List<(Person, Relationship, Person)>();
    //    public void AddParentAndChild(Person parent, Person child)
    //    {
    //        relations.Add((parent, Relationship.Parent, child));
    //        relations.Add((child, Relationship.Child, parent));
    //    }
    //}

    //public class Research
    //{
    //    public Research(Relationships relationships)
    //    {
    //        // high-level: find all of John's children

    //        var relations = relationships.relations;

    //        foreach (var r in relations.Where(x => x.Item1.Name == "John" && x.Item2 == Relationship.Parent))
    //        {
    //            Console.WriteLine($"John has a child called {r.Item3.Name}");
    //        }
    //    }
    //}

    public interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
    }

    public class Relationships : IRelationshipBrowser // low-level
    {

        // no longer public!
        private List<(Person, Relationship, Person)> relations = new List<(Person, Relationship, Person)>();

        public IEnumerable<Person> FindAllChildrenOf(string name)
        {
            return relations.Where(x => x.Item1.Name == name &&
                                   x.Item2 == Relationship.Parent)
                            .Select(r => r.Item3);
        }
    }

}
