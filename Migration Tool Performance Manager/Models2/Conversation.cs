using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

public partial class Conversation
{
    [Key]
    public int Id { get; set; }

    [Column("Company_id")]
    public int? CompanyId { get; set; }

    [Column("Sender_id")]
    [StringLength(450)]
    public string SenderId { get; set; } = null!;

    [Column("Receiver_id")]
    [StringLength(450)]
    public string ReceiverId { get; set; } = null!;

    [Column("Date_sent", TypeName = "datetime")]
    public DateTime DateSent { get; set; }

    public string? Message { get; set; }

    public bool Read { get; set; }

    [ForeignKey("CompanyId")]
    [InverseProperty("Conversations")]
    public virtual Company? Company { get; set; }

    [InverseProperty("Conversation")]
    public virtual ICollection<Mention> Mentions { get; set; } = new List<Mention>();

    [ForeignKey("ReceiverId")]
    [InverseProperty("ConversationReceivers")]
    public virtual User Receiver { get; set; } = null!;

    [ForeignKey("SenderId")]
    [InverseProperty("ConversationSenders")]
    public virtual User Sender { get; set; } = null!;
}
