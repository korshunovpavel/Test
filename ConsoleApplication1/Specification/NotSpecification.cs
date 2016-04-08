namespace ConsoleApplication1.Specification
{
    public class NotSpecification<T> : Specification<T>
    {
        private readonly ISpecification<T> _specification; 


        public NotSpecification(ISpecification<T> specification)
        {
            _specification = specification;
        }


        public override bool IsSatisfiedBy(T o)
        {
            return !_specification.IsSatisfiedBy(o);
        }
    }
}