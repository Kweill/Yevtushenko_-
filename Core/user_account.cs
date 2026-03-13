namespace Core
{
    public class UserAccount
    {
        public string OwnerName { get; set; } = "";
        public double Balance { get; set; }
        public bool IsActive { get; set; }

        public override string ToString()
        {
            return $"Owner: {OwnerName}, Balance: {Balance}, Active: {IsActive}";
        }
    }
}