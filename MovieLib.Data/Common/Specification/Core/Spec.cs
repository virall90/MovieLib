using System;
using System.Linq.Expressions;

namespace MovieLib.Data.Common.Specification.Core
{
    public class Spec<T> where T : class
    {
        public Spec(Expression<Func<T, bool>> expression)
        {
            Expression = expression;
        }

        public Expression<Func<T, bool>> Expression { get; }

        public static bool operator false(Spec<T> spec) => false;
        public static bool operator true(Spec<T> spec) => true;

        public static Spec<T> operator &(Spec<T> spec1, Spec<T> spec2) =>
            new Spec<T>(spec1.Expression.And(spec2.Expression));

        public static Spec<T> operator |(Spec<T> spec1, Spec<T> spec2) =>
            new Spec<T>(spec1.Expression.Or(spec2.Expression));

        public static Spec<T> operator !(Spec<T> spec1) => new Spec<T>(spec1.Expression.Not());

        public static implicit operator Expression<Func<T, bool>>(Spec<T> spec) => spec.Expression;

        public static implicit operator Func<T, bool>(Spec<T> spec) => spec.IsSatisfiedBy;

        public bool IsSatisfiedBy(T obj) => CompiledExpressions<T, bool>.AsFunc(Expression)(obj);
    }
}