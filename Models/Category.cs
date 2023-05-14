﻿namespace MusicApi.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Song> Songs { get; set; }

    }
}
