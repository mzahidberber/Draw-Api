﻿using Draw.Entities.Concrete.Web;

namespace Draw.Core.DTOs.Concrete
{
    public class SubTitleDTO
    {
        public int Id { get; set; }
        public int IndexId { get; set; }
        public string? Explanation { get; set; }
        public string? TextUrl1 { get; set; }
        public string? TextUrl2 { get; set; }
        public string? TextUrl3 { get; set; }
        public string? ShortcutUrl1 { get; set; }
        public string? ShortcutUrl2 { get; set; }
        public string? ShortcutUrl3 { get; set; }
        public string? GifUrl { get; set; }
        public string? LogoUrl { get; set; }
        public string Title { get; set; }
        public string? ResponeseType { get; set; }
        public string? Return { get; set; }
        public string? Header { get; set; }
        public string? Body { get; set; }
        public BaseTitleDTO? BaseTitle { get; set; }
        public int BaseTitleId { get; set; }
    }
}
