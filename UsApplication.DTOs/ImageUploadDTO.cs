using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace UsApplication.DTOs
{
    public class ImageUploadDTO
    {
        public IFormFile image { get; set; }
    }
}
