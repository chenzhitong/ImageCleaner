﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ImageCleaner.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Chinese Title")]
        public string ChineseTitle { get; set; }

        [Required]
        [Display(Name = "English Title")]
        public string EnglishTitle { get; set; }

        [Display(Name = "Chinese Cover")]
        public string ChineseCover { get; set; }

        [Display(Name = "English Cover")]
        public string EnglishCover { get; set; }

        [Required]
        public string Link { get; set; }

        [Display(Name = "Chinese Tags")]
        public string ChineseTags { get; set; }

        [Display(Name = "English Tags")]
        public string EnglishTags { get; set; }

        public DateTime Time { get; set; }
    }
}
