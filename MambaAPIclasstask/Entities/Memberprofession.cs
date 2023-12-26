namespace MambaAPIclasstask.Entities
{
    public class Memberprofession:BaseEntity
    {
        public int MemberId { get; set; }
        public int ProfessionId { get; set; }
        public Member Member { get; set; }
        public Profession profession { get; set; }
    }
}
