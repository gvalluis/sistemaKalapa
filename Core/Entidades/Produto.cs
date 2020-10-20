namespace Core.Entidades
{
    public class Produto : BaseEntidade
    {
        public string Name { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string UrlFoto { get; set; }
        public TipoProduto Tipo { get; set; }
        public int IdTipoDeProduto { get; set; }
        public CategoriaProduto Categoria { get; set; }
        public int IdCategoriaProduto { get; set; }
    }
}