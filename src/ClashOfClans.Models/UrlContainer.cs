﻿using System;

namespace ClashOfClans.Models
{
    public class UrlContainer
    {
        public Uri Small { get; set; } = default!;

        public Uri? Large { get; set; }

        public Uri? Medium { get; set; }

        public Uri? Tiny { get; set; }
    }
}
