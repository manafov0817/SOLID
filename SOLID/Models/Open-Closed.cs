using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Models
{
    public enum Color
    {
        Red,
        Green,
        Blue
    }

    public enum Size
    {
        Small,
        Medium,
        Large,
        Yuge
    }

    public class Product
    {
        public string Name;
        public Color Color;
        public Size Size;
        public Product(string name, Color color, Size size)
        {
            Name = name;
            Color = color;
            Size = size;
        }
    }

    public class ProductFilter
    {
        public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
        {
            foreach (var p in products)
                if (p.Color == color)
                    yield return p;
        }

        public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            foreach (var p in products)
                if (p.Size == size)
                    yield return p;
        }

        public IEnumerable<Product> FilterBySizeAndColor(IEnumerable<Product> products, Size size, Color color)
        {
            foreach (var p in products)
                if (p.Size == size && p.Color == color)
                    yield return p;
        }
    }

    //public interface ISpecification<T>
    //{
    //    bool IsSatisfied(T item);
    //}
    public abstract class ISpecification<T>
    {
        public abstract bool IsSatisfied(T p);
        public static ISpecification<T> operator &(ISpecification<T> first, ISpecification<T> second)
        {
            return new AndSpecification<T>(first, second);
        }
    }

    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }

    public class BetterFilter<T> : IFilter<T>
    {
        public IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec)
        {
            foreach (var i in items)
                if (spec.IsSatisfied(i))
                    yield return i;
        }
    }

    public class ColorSpecification : ISpecification<Product>
    {
        private Color color;
        public ColorSpecification(Color color)
        {
            this.color = color;
        }

        public override bool IsSatisfied(Product p)
        {
            return p.Color == color;
        }
        //public bool IsSatisfied(Product p)
        //{
        //    return p.Color == color;
        //}
    }

    public class SizeSpecification : ISpecification<Product>
    {
        private Size size;
        public SizeSpecification(Size size)
        {
            this.size = size;
        }

        public override bool IsSatisfied(Product p)
        {
            return p.Size == size;
        }
        //public bool IsSatisfied(Product p)
        //{
        //    return p.Size == size;
        //}

    }
    public class AndSpecification<T> : ISpecification<T>
    {
        private readonly ISpecification<T> first, second;
        public AndSpecification(ISpecification<T> first, ISpecification<T> second)
        {
            this.first = first;
            this.second = second;
        }
        //public bool IsSatisfied(T t)
        //{
        //    return first.IsSatisfied(t) && second.IsSatisfied(t);
        //}
        public override bool IsSatisfied(T p)
        {
            return first.IsSatisfied(p) && second.IsSatisfied(p);
        }
    }
    public static class CriteriaExtensions
    {
         public static AndSpecification<Product> And(this Color color,Size size)
        {           
            return new AndSpecification<Product>(new ColorSpecification(color), new SizeSpecification(size));
        } 
    }
}
