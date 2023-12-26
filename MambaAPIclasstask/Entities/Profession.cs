namespace MambaAPIclasstask.Entities
{
    public class Profession:BaseEntity
    {
        public string Name { get; set; }
        public List<Memberprofession> Memberprofessions { get; set; }
    }
}
