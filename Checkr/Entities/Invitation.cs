namespace Checkr.Entities
{
    public class Invitation
    {
        public int Id { get; set; }

        public bool IsAccepted { get; set; }

        public DateTime CreatedAt { get; set; }

        public string SenderId { get; set; } = string.Empty;

        public User Sender { get; set; } = default!;

        public string RecipientId { get; set; } = string.Empty;

        public User Recipient { get; set; } = default!;

        public int BoardId { get; set; }

        public Board Board { get; set; } = default!;
    }
}
