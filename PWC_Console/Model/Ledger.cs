namespace PWC_Model.Model
{
    public class Ledger
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        //public virtual Account Account { get; set; }
        public int AccountId { get; set; }
        //public virtual Entry Entry { get; set; }
        public int EntryId { get; set; }
    }

}
