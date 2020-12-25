namespace PblDAL.Models
{
    public class Controller : BaseEntity
    {
        public string Address { get; set; }
        public byte SlaveAddress { get; set; }
        public int Port { get; set; }
    }
}