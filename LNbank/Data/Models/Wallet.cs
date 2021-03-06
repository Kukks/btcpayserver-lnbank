using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using BTCPayServer.Lightning;

namespace LNbank.Data.Models
{
    public class Wallet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string WalletId { get; set; }
        public string UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Creation date")]
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public string AdminKey { get; set; }
        public string InvoiceKey { get; set; }
        public string ReadonlyKey { get; set; }

        public User User { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        public LightMoney Balance
        {
            get
            {
                return Transactions
                    .Where(t => t.AmountSettled != null)
                    .Aggregate(new LightMoney(0), (total, t) => total + t.AmountSettled);
            }
        }
    }
}
