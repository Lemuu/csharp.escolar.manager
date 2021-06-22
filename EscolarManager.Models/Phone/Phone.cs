namespace EscolarManager.Models.Phone
{
    public class Phone : IPhone
    {
        public string DDD { get; set; }
        public string Number { get; set; }

        public Phone(string DDD, string number)
        {
            this.DDD = DDD;
            Number = number;
        }
    }
}
