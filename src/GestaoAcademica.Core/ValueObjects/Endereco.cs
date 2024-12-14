namespace GestaoAcademica.Core.ValueObjects
{
    public class Endereco
    {
        public string Logradouro { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Pais { get; private set; }
        public string Cep { get; private set; }
        public string Referencia { get; private set; }

        public Endereco(
            string logradouro,
            string bairro,
            string cidade,
            string pais,
            string cep,
            string referencia)
        {
            Logradouro = logradouro;
            Bairro = bairro;
            Cidade = cidade;
            Pais = pais;
            Cep = cep;
            Referencia = referencia;
        }
    }
}
