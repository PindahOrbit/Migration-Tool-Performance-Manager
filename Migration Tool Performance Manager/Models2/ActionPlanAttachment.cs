using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Migration_Tool_Performance_Manager.Models2;

[Table("action_plan_attachments")]
public partial class ActionPlanAttachment
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("action_plan_id")]
    public int ActionPlanId { get; set; }

    [Column("attachment_url")]
    public string? AttachmentUrl { get; set; }

    [Column("date_attached", TypeName = "datetime")]
    public DateTime DateAttached { get; set; }

    [ForeignKey("ActionPlanId")]
    [InverseProperty("ActionPlanAttachments")]
    public virtual ActionPlan ActionPlan { get; set; } = null!;
}
