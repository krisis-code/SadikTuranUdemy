﻿using Microsoft.AspNetCore.Identity;

namespace BlogApp.Entity
{
    public enum TagColors
    {
        primary , danger , warning , success , secondary
    }
    public class Tag
    {
        public int TagId { get; set; }

        public String? Text { get; set; }

        public TagColors? Color { get; set; }

        public string? Url { get; set; }

        public List<Post> Posts { get; set; } = new List<Post>();
    }
}
