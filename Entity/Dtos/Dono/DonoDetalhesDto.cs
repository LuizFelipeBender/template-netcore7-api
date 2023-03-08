using Entity.Dtos.Pet;

namespace Entity.Dtos.Dono
{
    public class DonoDetalhesDto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Celular { get; set; }
        public List<PetDetalhesDto>? Pets { get; set; }

    }
}