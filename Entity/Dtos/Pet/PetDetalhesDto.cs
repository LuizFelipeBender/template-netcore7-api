namespace Entity.Dtos.Pet
{
    public class PetDetalhesDto
    {
        public string? Nome { get; set; }
        public string? Altura { get; set; }
        public string? Peso { get; set; }
        public int Idade { get; set; }
        public string? Raca { get; set; }
        public int TotalConsultas { get; set; }
        public string[]? Donos { get; set; }
    }
}