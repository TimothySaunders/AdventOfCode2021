namespace Day6.Models
{
    public class LanternFish
    {
        public int DaysUntilReplication { get; set; }
        
        public LanternFish(int days = 8)
        {
            DaysUntilReplication = days;
        }

        public LanternFish? PassDay()
        {
            if (DaysUntilReplication == 0)
            {
                DaysUntilReplication = 6;
                return new LanternFish();
            }
            DaysUntilReplication--;
            return null;
        }
    }
}