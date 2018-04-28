namespace CheckDigitAlg
{
    public interface ICheckDigitAlgorithm
    {
        int CreateCheckDigit(string input);
        bool IsValid(string input, int checkDigit);
    }
}