var myValidator = new Validator(
    [ new IsNotNull(), new MinSize(8), new HasSpecialCharacters() ]
);
myValidator.Validate("banana");

public interface IValidation
{
    bool Validate(string texto);
}

public class IsEmail : IValidation
{
    public bool Validate(string texto)
        => texto.Contains('@') && texto.Length > 0;
}

public class HasSpecialCharacters : IValidation
{
    public bool Validate(string texto)
        => texto.Any(c => "@$!()[]{}&*%".Contains(c));
}

public class IsNotNull : IValidation
{
    public bool Validate(string texto)
        => texto is not null;
}

public class MaxSize(int size) : IValidation
{
    public bool Validate(string texto)
        => texto.Length <= size;
}

public class MinSize(int size) : IValidation
{
    public bool Validate(string texto)
        => texto.Length >= size;
}

public class Validator(List<IValidation> validations)
{
    public bool Validate(string text)
    {
        foreach (var validation in validations)
        {
            if (!validation.Validate(text))
                return false;
        }
        return true;
    }
}