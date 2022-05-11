namespace BlurayDreamsAPI.Utilities
{
    public class RespostaGrafico
    {
        public string Categoria { get; set; }
        public List<Valor> Valores { get; set; }
    }
    public class Valor
    {        
        public DateTime Data { get; set; }
        public int Quantidade { get; set; }
    }

}
