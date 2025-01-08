using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

[Table("mentions")]
public partial class Mention
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("company_id")]
    public int CompanyId { get; set; }

    [Column("conversation_id")]
    public int? ConversationId { get; set; }

    [Column("mention_type")]
    [StringLength(10)]
    [Unicode(false)]
    public string MentionType { get; set; } = null!;

    [Column("mention_id")]
    public int MentionId { get; set; }

    [ForeignKey("CompanyId")]
    [InverseProperty("Mentions")]
    public virtual Company Company { get; set; } = null!;

    [ForeignKey("ConversationId")]
    [InverseProperty("Mentions")]
    public virtual Conversation? Conversation { get; set; }
}
