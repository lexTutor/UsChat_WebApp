using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UsApplication.Core.Services;
using UsApplication.Models;
using Microsoft.Extensions.Configuration;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;

namespace UsApplication.Implementation.Services
{
    public class ImageService : IImageService
    {
        private readonly IConfiguration _appConfig;
        private readonly AccountSettings _accountSettings;
        private readonly Cloudinary cloudinary;

        public ImageService(IOptions<AccountSettings> accountSettings, IConfiguration configuration)
        {
            _appConfig = configuration;
            _accountSettings = accountSettings.Value;
            cloudinary = new Cloudinary(new Account(_accountSettings.CloudName, _accountSettings.ApiKey, _accountSettings.ApiSecret));
        }

        public async Task<ImageUploadResult> UploadImage(IFormFile image)
        {
            //object to return
            var uploadResult = new ImageUploadResult();
            var isFormatSupported = false;
            // validate the image size and extension type using settings from appsettings
            var listOfExtensions = new List<string> { ".jpg", ".jpeg", ".png", ".jfif" };
            for (int i = 0; i < listOfExtensions.Count; i++)
            {
                if (image.FileName.EndsWith(listOfExtensions[i]))
                {
                    isFormatSupported = true;
                    break;
                }
            }

            if (image == null || !isFormatSupported)
            {
                return null;
            }

            //fetch image as stream of data
            using (var imageStream = image.OpenReadStream())
            {
                string fileName = Guid.NewGuid().ToString() + "_" + image.Name;
                //upload to cloudinary
                uploadResult = await cloudinary.UploadAsync(new ImageUploadParams()
                {
                    File = new FileDescription(fileName, imageStream),
                    Transformation = new Transformation().Crop("thumb").Gravity("face").Width(1000)
                                                        .Height(1000).Radius(40)
                });
            }
            return uploadResult;
        }
    }
}
