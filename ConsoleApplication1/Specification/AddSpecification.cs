namespace ConsoleApplication1.Specification
{
    public class AddSpecification<T> : Specification<T>
    {
        private readonly ISpecification<T> _left; 
        private readonly ISpecification<T> _right;


        public AddSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            _left = left;
            _right = right;
        }


        public override bool IsSatisfiedBy(T o)
        {
            return _left.IsSatisfiedBy(o) && _right.IsSatisfiedBy(o);
        }
    }
}