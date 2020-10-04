using System.Collections.Generic;

namespace LibraryTop
{
    internal class PDF
    {
        public string NFe { get; set; }
        public string EnderecoEmissao { get; set; }
        public string ChaveDeAcesso { get; set; }
        public string NaturazaOperacao { get; set; }
        public string ProtocoloDeAutorizacaoDeUso { get; set; }
        public string IncricaoEstadual { get; set; }
        public string CnpjEmitente { get; set; }
        public string RazaoSocial { get; set; }
        public string CnpjRemetente { get; set; }
        public string DataEmissao { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Municipio { get; set; }
        public string UF { get; set; }
        public string IncricaoEstadualRemetente { get; set; }
        public string BaseCalculoIcms { get; set; }
        public string ValorDoIcms { get; set; }
        public string BaseDeCalculoIcmsST { get; set; }
        public string ValorDoIcmsSubstituicao { get; set; }
        public string ValorTotalProdutos { get; set; }
        public string ValorDoFrete { get; set; }
        public string ValorDoSeguro { get; set; }
        public string Desconto { get; set; }
        public string OutrasDespesasAcessorias { get; set; }
        public string ValroTotalDoIPI { get; set; }
        public string ValorTotalDaNota { get; set; }
        public string Quantidade { get; set; }
        public string PesoBruto { get; set; }
        public string PesoLiquido { get; set; }
        public IList<string> ListaDeProdutos { get; set; }
        public string DadosAdicionais { get; set; }
    }
}
