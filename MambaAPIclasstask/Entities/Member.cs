namespace MambaAPIclasstask.Entities
{
    public class Member:BaseEntity
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string RedirectUrl { get; set; }
        public List<Memberprofession> Memberprofessions { get; set; }
    }
}
