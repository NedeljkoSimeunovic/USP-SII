namespace USP.Aplication.Common.Exceptions;

public class UspValidationException(IDictionary<string, string[]> failuers)
    : BaseException("One or more vaidation failures have occured.", failuers);