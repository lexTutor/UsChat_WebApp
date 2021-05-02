using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UsApplication.Core.Services
{
    public interface IImageService
    {
        Task<ImageUploadResult> UploadImage(IFormFile image);
    }
}
