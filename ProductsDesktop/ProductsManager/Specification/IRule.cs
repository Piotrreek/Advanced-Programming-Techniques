namespace ProductsManager.Specification;

public interface IRule
{
    string ErrorMessage { get; }
    bool IsSatisfied();
}