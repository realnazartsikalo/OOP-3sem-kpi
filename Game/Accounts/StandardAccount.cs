namespace Play.Accounts
{
      class StandardAccount : GameAccount
    {
        public StandardAccount(string userName, int initialRating = 100) : base(userName, initialRating)
        {

        }
        public override string AccountType { get; protected set; } = "Standard";
    }
}