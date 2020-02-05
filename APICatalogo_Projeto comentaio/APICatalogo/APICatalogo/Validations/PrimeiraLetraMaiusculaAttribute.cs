using System.ComponentModel.DataAnnotations;

namespace ApiCatalogo.Validations
{
    public class PrimeiraLetraMaiusculaAttribute : ValidationAttribute
    {
        //atributo verificando se a primeira letra e maiuscula 
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //validação feita no required 
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            //pegando a primeira letra do nome 
            var primeiraLetra = value.ToString()[0].ToString();

            //verificando se a primeira letra e diferente de  maiuscula 
            if (primeiraLetra != primeiraLetra.ToUpper())
            {
                return new ValidationResult("A primeira letra deve ser maiuscula");
            }

            return ValidationResult.Success;
        }
    }
}
