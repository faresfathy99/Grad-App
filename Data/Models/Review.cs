﻿namespace MizanGraduationProject.Data.Models
{
    public class Review
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string UserId { get; set; } = null!;
        public string LawyerId { get; set; } = null!;
        public string Comment { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public User User { get; set; } = null!;
        public Lawyer Lawyer { get; set; } = null!;
    }
}
