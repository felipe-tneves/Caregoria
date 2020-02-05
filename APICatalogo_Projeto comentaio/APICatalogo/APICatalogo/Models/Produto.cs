using ApiCatalogo.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICatalogo.Models
{
    [Table("Produtos")]
    public class Produto : IValidatableObject 
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage="O nome é obrigatorio")]
        [StringLength(20, ErrorMessage ="o nome deve ter entre 5 e 20 caracteres", MinimumLength = 5)]
        //[PrimeiraLetraMaiuscula]
        public string Nome { get; set; }

        [Required]
        [StringLength(30, ErrorMessage ="A descrição deve ter mo maximo {1} caracter")]
        public string Descricao { get; set; }

        [Required]
        [Range(1, 10000, ErrorMessage ="O preco deve estar entre {1} e {2}")]
        public decimal Preco { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 10)]
        public string ImagemUrl { get; set; }

        //Relacionamento entre as tabelas 
        public float Estoque { get; set; }
        public DateTime DataCadastro { get; set; }

        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //verifica se valor da propriedade e null ou vazio 
            if (!string.IsNullOrEmpty(this.Nome))
            {
                //pega o primeiro caracter do nome 
                var primeiraLetra = this.Nome[0].ToString();
                //varifica se o caracter nao esta em caixa alta 
                if (primeiraLetra != primeiraLetra.ToUpper())
                {
                    //retorna uma execessao e uma lista de menbros que possue erros de validação 
                    //Um método iterador usa a instrução yield return para retornar um elemento de cada vez
                    yield return new ValidationResult("A Primeira letra do produto deve ser maiuscula",
                    new[]
                    {
                        nameof(this.Nome)
                    });
                }
            }

            if (this.Estoque <= 0)
            {
                yield return new ValidationResult("O estoque deve ser maior que zero",
                    new[]
                    {
                        nameof(this.Estoque)
                    });
            }

        }
        }
    }

