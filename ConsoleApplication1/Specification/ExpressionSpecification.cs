using System;

namespace ConsoleApplication1.Specification
{
    public class ExpressionSpecification<T> : Specification<T>
    {
        private readonly Func<T, bool> _expression;


        public ExpressionSpecification(Func<T, bool> expression)
        {
            _expression = expression;
        }


        public override bool IsSatisfiedBy(T o)
        {
            return _expression(o);
        }
    }
}