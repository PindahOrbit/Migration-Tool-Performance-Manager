using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

[Table("chatmessages")]
public partial class Chatmessage
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("date_sent", TypeName = "datetime")]
    public DateTime DateSent { get; set; }

    [Column("date_received", TypeName = "datetime")]
    public DateTime? DateReceived { get; set; }

    [Column("sender_id")]
    [StringLength(450)]
    public string SenderId { get; set; } = null!;

    [Column("receiver_id")]
    [StringLength(450)]
    public string ReceiverId { get; set; } = null!;

    [Column("message")]
    public string Message { get; set; } = null!;

    [Column("is_read")]
    public bool IsRead { get; set; }

    [ForeignKey("ReceiverId")]
    [InverseProperty("ChatmessageReceivers")]
    public virtual User Receiver { get; set; } = null!;

    [ForeignKey("SenderId")]
    [InverseProperty("ChatmessageSenders")]
    public virtual User Sender { get; set; } = null!;
}
